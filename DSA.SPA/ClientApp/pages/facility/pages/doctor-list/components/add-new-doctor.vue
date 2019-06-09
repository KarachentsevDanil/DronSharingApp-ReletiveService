<template>
  <!-- Primary modal -->
  <div id="addDoctor" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Doctor</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <input v-model="firstName" class="form-control" placeholder="First Name...">
          </div>
          <div class="form-group">
            <input v-model="lastName" class="form-control" placeholder="Last Name...">
          </div>
          <div class="form-group">
            <input v-model="phone" class="form-control" placeholder="Phone...">
          </div>
          <div class="form-group">
            <input v-model="email" type="email" class="form-control" placeholder="Email...">
          </div>
          <div class="form-group">
            <input
              v-model="password"
              type="password"
              class="form-control"
              placeholder="Password..."
            >
          </div>
          <div class="form-group">
            <label>Birth Date:</label>
            <datetime input-class="form-control" v-model="birthDate"></datetime>
          </div>
          <div class="form-group">
            <textarea
              cols="5"
              rows="5"
              v-model="description"
              placeholder="Description..."
              class="form-control"
            ></textarea>
          </div>
          <div class="form-group">
            <label>Department:</label>
            <select2
              style="width: 100%;"
              :configuration="departmentSelectConfiguration"
              :options="departments"
              v-model="departmentId"
            ></select2>
          </div>
          <div class="form-group">
            <label>Specialization:</label>
            <select2
              style="width: 100%;"
              :configuration="specializationSelectConfiguration"
              :options="specializations"
              v-model="doctorSpecializationId"
            ></select2>
          </div>
        </div>

        <div class="modal-footer">
          <button
            @click="addDoctor"
            type="button"
            :disabled="!firstName || !lastName || !phone || !description"
            class="btn btn-primary"
          >Add</button>
          <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
  <!-- /primary modal -->
</template>

<script>
import * as doctorService from "../../../api/doctor-service";
import * as departmentService from "../../../api/department-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      user: {},
      firstName: "",
      lastName: "",
      description: "",
      email: "",
      phone: "",
      birthDate: "",
      password: "",
      doctorSpecializationId: 0,
      departmentId: 0,
      departments: [],
      specializations: [],
      departmentSelectConfiguration: {
        placeholder: "Select a department...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      specializationSelectConfiguration: {
        placeholder: "Select a specialization...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    this.user = JSON.parse(localStorage.getItem("user"));

    let departments = (await departmentService.getDepartmentsByTerm("")).data
      .Data;
    let specializations = (await doctorService.getDoctorSpecializationsByTerm(
      ""
    )).data.Data;

    this.departments = departments.map(el => ({
      id: el.Id,
      text: el.Name
    }));

    this.specializations = specializations.map(el => ({
      id: el.DoctorSpecializationId,
      text: el.Name
    }));

    this.departmentId = this.departments[0].id;
    this.doctorSpecializationId = this.specializations[0].id;
  },
  methods: {
    clearForm() {
      this.firstName = "";
      this.lastName = "";
      this.description = "";
      this.email = "";
      this.phone = "";
      this.password = "";
      this.birthDate = "";
      this.doctorSpecializationId = 0;
      this.departmentId = 0;
    },
    async addDoctor() {
      let data = {
        firstName: this.firstName,
        lastName: this.lastName,
        description: this.description,
        email: this.email,
        phone: this.phone,
        birthDate: this.birthDate,
        departmentId: this.departmentId,
        doctorSpecializationId: this.doctorSpecializationId,
        password: this.password,
        facilityId: this.user.FacilityId
      };

      await doctorService.addDoctor(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Doctor was successfully added.");

      this.refreshList();
    }
  },
  props: {
    refreshList: {
      type: Function
    }
  }
};
</script>

<style>
#addNewAppointment .modal-footer {
  padding: 15px;
}
</style>
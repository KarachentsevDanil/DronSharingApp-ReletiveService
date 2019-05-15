<template>
  <!-- Primary modal -->
  <div id="addDepartment" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Department</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <input v-model="name" class="form-control" placeholder="Name...">
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
            <label>Facility:</label>
            <select2
              style="width: 100%;"
              :configuration="facilitySelectConfiguration"
              :options="facilities"
              v-model="facilityId"
            ></select2>
          </div>
        </div>

        <div class="modal-footer">
          <button
            @click="addDepartment"
            type="button"
            :disabled="!name || !facilityId"
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
import * as departmentService from "../../../api/department-service";
import * as facilityService from "../../../api/facility-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      name: "",
      description: "",
      facilityId: 0,
      facilities: [],
      facilitySelectConfiguration: {
        placeholder: "Select a facility...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let facilities = (await facilityService.getFacilitiesByTerm("")).data.Data;

    this.facilities = facilities.map(el => ({
      id: el.FacilityId,
      text: el.Name
    }));

    this.facilityId = this.facilities[0].id;
  },
  methods: {
    clearForm() {
      this.name = "";
      this.description = "";
      this.facilityId = 0;
    },
    async addDepartment() {
      let data = {
        name: this.name,
        description: this.description,
        facilityId: this.facilityId
      };

      await departmentService.addDepartment(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Department was successfully added.");

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
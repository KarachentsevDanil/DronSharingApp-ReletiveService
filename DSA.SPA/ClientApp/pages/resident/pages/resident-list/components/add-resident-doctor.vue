<template>
    <!-- Primary modal -->
    <div id="addResidentDoctor" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Doctor to resident</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                        <label>Resident: </label>
                        <span> {{resident.ResidentId}} - {{resident.FirstName}} {{resident.LastName}} </span>
                    </div>
                    <div class="form-group">
                      <label>Doctor: </label>
                      <select2 style="width: 100%;"
                             :configuration="doctorSelectConfiguration"
                             :options="doctors"
                             v-model="doctorId"></select2>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addResidentDoctor" type="button" :disabled="doctorId == 0" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as residentService from "../../../api/resident-service";
import * as doctorService from "../../../../facility/api/doctor-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      doctorId: 0,
      doctors: [],
      doctorSelectConfiguration: {
        placeholder: "Select a doctor...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let doctors = (await doctorService.getDoctorsByTerm("")).data.Data;

    this.doctors = doctors.map(el => ({
      id: el.DoctorId,
      text: el.FullName
    }));
  },
  methods: {
    clearForm() {
      this.doctorId = 0;
    },
    async addResidentDoctor() {
      let data = {
        residentId: this.resident.ResidentId,
        doctorId: this.doctorId,
      };

      await residentService.addResidentDoctor(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Doctor was successfully added to resident.");
    }
  },
  watch:{
      resident(){
          console.log(this.resident);
      }
  },
  props: {
    resident: {
      type: Object
    }
  }
};
</script>

<style>
#addNewAppointment .modal-footer {
  padding: 15px;
}
</style>
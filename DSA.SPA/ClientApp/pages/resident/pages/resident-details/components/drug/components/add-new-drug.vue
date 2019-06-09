<template>
  <!-- Primary modal -->
  <div id="addResidentDrug" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Resident Drug</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <label>Drug:</label>
            <select2
              style="width: 100%;"
              :configuration="drugSelectConfiguration"
              :options="drugs"
              v-model="drugId"
            ></select2>
          </div>
          <div class="form-group">
            <label>Start Date:</label>
            <datetime input-class="form-control" v-model="startDate"></datetime>
          </div>
          <div class="form-group">
            <label>End Date:</label>
            <datetime input-class="form-control" v-model="endDate"></datetime>
          </div>
          <div class="form-group">
            <label>Dosage:</label>
            <input type="number" class="form-control" v-model="dosage"/>
          </div>
          <div class="form-group">
            <label>Unit:</label>
            <input type="text" class="form-control" v-model="unit"/>
          </div>
        </div>

        <div class="modal-footer">
          <button
            @click="addResidentDrug"
            type="button"
            :disabled="!startDate || !endDate || dosage == 0 || !unit || drugId == 0"
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
import * as residentService from "../../../../../api/resident-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      drugId: 0,
      startDate: "",
      endDate: "",
      dosage: 0,
      unit: "",
      drugs: [],
      drugSelectConfiguration: {
        placeholder: "Select a drug...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let drugs = (await residentService.getDrugs()).data.Data;

    this.drugs = drugs.map(el => ({
      id: el.Id,
      text: el.Name
    }));

    this.drugId = this.drugs[0].id;
  },
  methods: {
    clearForm() {
      this.startDate = "";
      this.endDate = "";
      this.dosage = 0;
      this.unit = "";
      this.drugId = 0;
    },
    async addResidentDrug() {
      let data = {
        residentId: this.residentId,
        drugId: this.drugId,
        startDate: this.startDate,
        endDate: this.endDate,
        dosage: this.dosage,
        unit: this.unit
      };

      await residentService.addResidentDrug(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Resident drug was successfully added.");

      this.refreshList();
    }
  },
  props: {
    refreshList: {
      type: Function
    },
    residentId: {}
  }
};
</script>

<style>
#addNewAppointment .modal-footer {
  padding: 15px;
}
</style>
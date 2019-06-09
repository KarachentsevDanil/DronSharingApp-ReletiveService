<template>
  <!-- Primary modal -->
  <div id="addResidentAnalyze" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Resident Analyze</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <label>Analyze:</label>
            <select2
              style="width: 100%;"
              :configuration="analyzeSelectConfiguration"
              :options="analyzes"
              v-model="analyzeId"
            ></select2>
          </div>
          <div class="form-group">
            <label>Date:</label>
            <datetime input-class="form-control" v-model="date" type="datetime"></datetime>
          </div>
        </div>

        <div class="modal-footer">
          <button
            @click="addResidentAnalyze"
            type="button"
            :disabled="!date || analyzeId == 0"
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
      analyzeId: 0,
      date: "",
      analyzes: [],
      analyzeSelectConfiguration: {
        placeholder: "Select a analyze...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let analyzes = (await residentService.getAnalyzes()).data.Data;

    this.analyzes = analyzes.map(el => ({
      id: el.Id,
      text: el.Name
    }));

    this.analyzeId = this.analyzes[0].id;
  },
  methods: {
    clearForm() {
      this.date = "";
      this.analyzeId = 0;
    },
    async addResidentAnalyze() {
      let data = {
        residentId: this.residentId,
        analyzesId: this.analyzeId,
        date: this.date
      };

      await residentService.addResidentAnalyze(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Resident analyze was successfully added.");

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
<template>
  <!-- Primary modal -->
  <div id="addResidentManipulation" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Resident Manipulation</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <label>Manipulation:</label>
            <select2
              style="width: 100%;"
              :configuration="manipulationSelectConfiguration"
              :options="manipulations"
              v-model="manipulationId"
            ></select2>
          </div>
          <div class="form-group">
            <label>Date:</label>
            <datetime input-class="form-control" v-model="date" type="datetime"></datetime>
          </div>
          <div class="form-group">
            <label>Duration:</label>
            <input type="text" class="form-control" v-model="duration"/>
          </div>
        </div>

        <div class="modal-footer">
          <button
            @click="addResidentManipulation"
            type="button"
            :disabled="!date || manipulationId == 0 || !duration"
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
      manipulationId: 0,
      date: "",
      duration: "",
      manipulations: [],
      manipulationSelectConfiguration: {
        placeholder: "Select a manipulation...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let manipulations = (await residentService.getManipulations()).data.Data;

    this.manipulations = manipulations.map(el => ({
      id: el.Id,
      text: el.Name
    }));

    this.manipulationId = this.manipulations[0].id;
  },
  methods: {
    clearForm() {
      this.date = "";
      this.duration = "";
      this.manipulationId = 0;
    },
    async addResidentManipulation() {
      let data = {
        residentId: this.residentId,
        manipulationId: this.manipulationId,
        duration: this.duration,
        date: this.date
      };

      await residentService.addResidentManipulation(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Resident manipulation was successfully added.");

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
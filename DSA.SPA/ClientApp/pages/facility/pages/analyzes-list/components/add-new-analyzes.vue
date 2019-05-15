<template>
  <!-- Primary modal -->
  <div id="addAnalyzes" class="modal fade">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header bg-primary">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Analyzes</h4>
        </div>

        <div class="modal-body">
          <div class="form-group">
            <input v-model="name" class="form-control" placeholder="Name...">
          </div>
          <div class="form-group">
            <input v-model="roomNumber" class="form-control" placeholder="Room Number...">
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
        </div>

        <div class="modal-footer">
          <button
            @click="addAnalyzes"
            type="button"
            :disabled="!name || !roomNumber || !description"
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
import * as analyzesService from "../../../api/analyzes-service";
import * as departmentService from "../../../api/department-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      name: "",
      roomNumber: "",
      description: "",
      departmentId: 0,
      departments: [],
      departmentSelectConfiguration: {
        placeholder: "Select a department...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  async beforeMount() {
    let departments = (await departmentService.getDepartmentsByTerm("")).data.Data;

    this.departments = departments.map(el => ({
      id: el.Id,
      text: el.Name
    }));

    this.departmentId = this.departments[0].id;
  },
  methods: {
    clearForm() {
      this.name = "";
      this.roomNumber = "";
      this.description = "";
      this.departmentId = 0;
    },
    async addAnalyzes() {
      let data = {
        name: this.name,
        roomNumber: this.roomNumber,
        description: this.description,
        departmentId: this.departmentId
      };

      await analyzesService.addAnalyzes(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Analyzes was successfully added.");

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
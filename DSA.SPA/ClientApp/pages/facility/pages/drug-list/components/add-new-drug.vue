<template>
    <!-- Primary modal -->
    <div id="addDrug" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Drug</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                        <input v-model="name" class="form-control" placeholder="Name..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="type" class="form-control" placeholder="Type..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="provider" class="form-control" placeholder="Provider..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="atxCode" class="form-control" placeholder="ATX Code..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="unit" class="form-control" placeholder="Unit..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="value" class="form-control" placeholder="Dosage..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="price" class="form-control" placeholder="Price..."/>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addDrug" type="button" :disabled="!name || !type || !provider || !atxCode || !unit || !value || !price" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as drugService from "../../../api/drug-service";

export default {
  data() {
    return {
      unit: "",
      name: "",
      atxCode: "",
      type: "",
      value: "",
      price: "",
      provider: ""
    };
  },
  methods: {
    clearForm() {
      this.name = "";
      this.unit = "";
      this.atxCode = "";
      this.type = "";
      this.provider = "";
      this.value = "";
      this.price = "";
    },
    async addDrug() {
      let data = {
        name: this.name,
        unit: this.unit,
        atxCode: this.atxCode,
        type: this.type,
        provider: this.provider,
        value: this.value,
        price: this.price
      };

      await drugService.addDrug(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Drug was successfully added.");

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
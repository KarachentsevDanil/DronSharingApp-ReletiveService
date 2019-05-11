<template>
    <!-- Primary modal -->
    <div id="addFacility" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Facility</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                        <input v-model="city" class="form-control" placeholder="City..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="name" class="form-control" placeholder="Name..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="email" class="form-control" placeholder="Email..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="phone" class="form-control" placeholder="Phone..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="address" class="form-control" placeholder="Address..."/>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addFacility" type="button" :disabled="!name || !email || !phone || !address || !city" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as facilityService from "../../../api/facility-service";

export default {
  data() {
    return {
      city: "",
      name: "",
      address: "",
      email: "",
      phone: ""
    };
  },
  methods: {
    clearForm() {
      this.name = "";
      this.city = "";
      this.address = "";
      this.email = "";
      this.phone = "";
    },
    async addFacility() {
      let data = {
        name: this.name,
        city: this.city,
        address: this.address,
        email: this.email,
        phone: this.phone,
      };

      await facilityService.addFacility(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Facility was successfully added.");

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
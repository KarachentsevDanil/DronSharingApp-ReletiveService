<template>
    <!-- Primary modal -->
    <div id="addDoctor" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add User</h4>
                </div>

                <div class="modal-body">
                   <div class="form-group">
                        <input type="email" v-model="email" class="form-control" placeholder="Email..."/>
                    </div>
                    <div class="form-group">
                        <input type="password" v-model="password" class="form-control" placeholder="Password..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="firstName" class="form-control" placeholder="First Name..."/>
                    </div>
                    <div class="form-group">
                        <input v-model="lastName" class="form-control" placeholder="Last Name..."/>
                    </div>
                    <div class="form-group">
                      <label>Facility: </label>
                      <select2 style="width: 100%;"
                             :configuration="facilitySelectConfiguration"
                             :options="facilities"
                             v-model="facilityId"></select2>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addUser" type="button" :disabled="!email || !password || !firstName || !lastName" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as userService from "../../../api/user-service";
import * as facilityService from "../../../../facility/api/facility-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
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
      this.firstName = "";
      this.lastName = "";
      this.password = "";
      this.email = "";
      this.facilityId = 0;
    },
    async addUser() {
      let data = {
        firstName: this.firstName,
        lastName: this.lastName,
        facilityId: this.facilityId,
        email: this.email,
        password: this.password,
        role: 1
      };

      await userService.addUser(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("User was successfully added.");

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
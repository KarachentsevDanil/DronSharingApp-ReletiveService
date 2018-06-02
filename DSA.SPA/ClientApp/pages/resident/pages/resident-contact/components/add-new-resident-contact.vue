<template>
    <!-- Primary modal -->
    <div id="addResident" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Contact to Resident</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                      <label>Relative:</label>
                      <p>{{currentUser.FullName}}</p>
                    </div>
                    <div class="form-group">
                      <label>Resident: </label>
                      <select2 style="width: 100%;"
                             :configuration="residentSelectConfiguration"
                             :options="residents"
                             v-model="residentId"></select2>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addResident" type="button" :disabled="residentId == 0" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as authGetters from "../../../../auth/store/types/getter-types";
import * as authResources from "../../../../auth/store/resources";

import { mapGetters } from "vuex";

import * as residentService from "../../../api/resident-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      residentId: 0,
      residents: [],
      residentSelectConfiguration: {
        placeholder: "Select a resident...",
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      }
    };
  },
  computed: {
    ...mapGetters({
      currentUser: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    })
  },
  async beforeMount() {
    let residents = (await residentService.getResidentsByTerm("")).data.Data;

    this.residents = residents.map(el => ({
      id: el.ResidentId,
      text: el.FirstName + " " + el.LastName
    }));

    this.residentId = this.residents[0].id;
  },
  methods: {
    clearForm() {
      this.residentId = 0;
    },
    async addResident() {
      let data = {
        residentId: this.residentId,
        userId: this.currentUser.UserId
      };

      await residentService.addResidentContact(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Resident contact was successfully added.");

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
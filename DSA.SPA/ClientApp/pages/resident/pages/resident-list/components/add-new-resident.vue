<template>
    <!-- Primary modal -->
    <div id="addResident" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Resident</h4>
                </div>

                <div class="modal-body">
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
                    <div class="form-group">
                      <label>Birthdate: </label>
                      <datetime input-class="form-control" v-model="birthDate"></datetime>
                    </div>
                    <div class="form-group">
                      <label>Admission Date: </label>
                      <datetime input-class="form-control" v-model="admissionDate"></datetime>
                    </div>
                    <div class="form-group">
                        <p>Photo: </p>
                        <vue-dropzone @vdropzone-success="photoSuccessfullyAdded" id="iconDropzone" :options="dropzoneOptions">
                        </vue-dropzone>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addResident" type="button" :disabled="!firstName || !lastName" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as residentService from "../../../api/resident-service";
import * as facilityService from "../../../api/facility-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      firstName: "",
      lastName: "",
      facilityId: 0,
      photo: "",
      birthDate: "",
      admissionDate: "",
      facilities: [],
      dropzoneOptions: {
        url: "https://httpbin.org/post",
        thumbnailWidth: 200,
        addRemoveLinks: true,
        dictDefaultMessage:
          "<span class='upload-text'><i class='fal fa-cloud-upload'></i> Photo</span>"
      },
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
    photoSuccessfullyAdded(file, response) {
      this.photo = this.getFileData(file);
    },
    getFileData(file) {
      let fileData = file.dataURL.split("base64,")[1];
      return fileData;
    },
    clearForm() {
      this.firstName = "";
      this.lastName = "";
      this.admissionDate = "";
      this.facilityId = 0;
      this.photo = "";
      this.birthDate = "";
    },
    async addResident() {
      let data = {
        firstName: this.firstName,
        lastName: this.lastName,
        admissionDate: this.admissionDate,
        facilityId: this.facilityId,
        birthDay: this.birthDate,
        photo: this.photo
      };

      await residentService.addResident(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Resident was successfully added.");

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
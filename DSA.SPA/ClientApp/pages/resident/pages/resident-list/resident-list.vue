<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
          <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addResident">
                                <b><i class="icon-plus2"></i></b> Add Resident
                            </a>         </div>
            </div>
        </div>

        <div class="content">
            <div class="panel panel-flat without-header">
                <datatable v-bind="$data" :HeaderSettings="false" />
            </div>
        </div>
        <add-new-resident :refreshList="getResidents"/>
        <add-resident-doctor :resident="xprops.selectedResident"></add-resident-doctor>
    </div>
</template>

<script>
import * as residentService from "../../api/resident-service";

import addNewResident from "./components/add-new-resident";
import addResidentDoctor from "./components/add-resident-doctor";
import residentActionCell from "./components/resident-action-cell";

import Vue from "Vue";

export default {
  components: {
    addNewResident: addNewResident,
    residentActionCell: residentActionCell,
    addResidentDoctor: addResidentDoctor
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "ResidentId",
        sortable: false
      },
      {
        title: "Name",
        field: "FullName",
        sortable: false
      },
      {
        title: "Facility",
        field: "FacilityName",
        sortable: false
      },
      {
        title: "BirthDay",
        field: "FormattedDate",
        sortable: false
      },
      {
        title: "Actions",
        tdComp: "residentActionCell",
        thStyle: { textAlign: "center" }
      }
    ],
    data: [],
    total: 0,
    query: {},
    xprops: {
      selectedResident: {}
    }
  }),
  watch: {
    query: {
      async handler() {
        await this.getResidents();
      },
      deep: true
    },
    xprops: {
      eventbus: {
        selectedResident() {
          console.log(this.xprops.eventbus.selectedResident);
        },
        deep: true
      }
    }
  },
  methods: {
    async getResidents() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await residentService.getResidents(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
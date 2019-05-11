<template>
  <div>
    <div class="page-header">
      <div class="page-header-content">
        <div class="page-title">
          <h4 class="grid-title">
            <i class="icon-user3 position-left"></i>
            <span class="text-semibold">Resident List</span>
          </h4>
          <a class="heading-elements-toggle">
            <i class="icon-more"></i>
          </a>
        </div>

        <div class="heading-elements">
          <div class="heading-btn-group">
            <a
              href="#"
              class="btn bg-blue btn-labeled heading-btn legitRipple"
              data-toggle="modal"
              data-target="#addResident"
            >
              <b>
                <i class="icon-plus2"></i>
              </b> Add Resident
            </a>
          </div>
        </div>
      </div>

      <div class="breadcrumb-line breadcrumb-line-component">
        <a class="breadcrumb-elements-toggle">
          <i class="icon-menu-open"></i>
        </a>
        <ul class="breadcrumb">
          <li>
            <a href="/home">
              <i class="icon-home2 position-left"></i> Home
            </a>
          </li>
          <li>
            <a class="active">Residents</a>
          </li>
        </ul>
      </div>
    </div>

    <div class="content">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
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
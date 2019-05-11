<template>
  <div>
    <div class="page-header">
      <div class="page-header-content">
        <div class="page-title">
          <h4 class="grid-title">
            <i class="icon-user3 position-left"></i>
            <span class="text-semibold">Doctor List</span>
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
              data-target="#addDoctor"
            >
              <b>
                <i class="icon-plus2"></i>
              </b> Add Doctor
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
            <a class="active">Doctors</a>
          </li>
        </ul>
      </div>
    </div>

    <div class="content">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-doctor :refreshList="getDoctors"/>
  </div>
</template>

<script>
import * as doctorService from "../../api/doctor-service";

import addNewDoctor from "./components/add-new-doctor";

import Vue from "Vue";

export default {
  components: {
    addNewDoctor: addNewDoctor
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "DoctorId",
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
        title: "Specialization",
        field: "Specialization",
        sortable: false
      },
      {
        title: "Phone",
        field: "Phone",
        sortable: false
      },
      {
        title: "Email",
        field: "Email",
        sortable: false
      }
    ],
    data: [],
    total: 0,
    query: {},
    xprops: {
      eventbus: new Vue()
    }
  }),
  watch: {
    query: {
      async handler() {
        await this.getDoctors();
      },
      deep: true
    }
  },
  methods: {
    async getDoctors() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await doctorService.getDoctors(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
      <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addDoctor">
                                <b><i class="icon-plus2"></i></b> Add Doctor
                            </a>          </div>
            </div>
        </div>

        <div class="content">
            <div class="panel panel-flat without-header">
                <datatable v-bind="$data" :HeaderSettings="false" />
            </div>
        </div>
        <add-new-doctor :refreshList="getDoctors"/>
    </div>
</template>

<script>
import * as doctorService from "../../api/doctor-service";

import addNewDoctor from './components/add-new-doctor';

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
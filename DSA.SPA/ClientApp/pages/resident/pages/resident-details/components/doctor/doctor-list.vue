<template>
        <div class="panel panel-flat without-header">
            <datatable v-bind="$data" :HeaderSettings="false" />
        </div>
</template>

<script>
import * as doctorService from "../../../../../facility/api/doctor-service";

import Vue from "Vue";

export default {
  props: {
    residentId: {}
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
        title: "Phone",
        field: "Phone",
        sortable: false
      },
      {
        title: "Email",
        field: "Email",
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
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await doctorService.getDoctors(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
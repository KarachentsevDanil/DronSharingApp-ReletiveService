<template>
        <div class="panel panel-flat without-header">
            <datatable v-bind="$data" :HeaderSettings="false" />
        </div>
</template>

<script>
import * as appointmentService from "../../../../api/appointment-service";

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
        field: "AppointmentId",
        sortable: false
      },
      {
        title: "Relative",
        field: "UserName",
        sortable: false
      },
      {
        title: "Date",
        field: "DateValue",
        sortable: false
      },
      {
        title: "Period",
        field: "Period",
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
        await this.getAppointments();
      },
      deep: true
    }
  },
  methods: {
    async getAppointments() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await appointmentService.getAppointments(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
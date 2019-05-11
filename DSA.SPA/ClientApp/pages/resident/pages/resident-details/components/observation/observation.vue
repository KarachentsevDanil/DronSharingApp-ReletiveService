<template>
        <div class="panel panel-flat without-header">
            <datatable v-bind="$data" :HeaderSettings="false" />
        </div>
</template>

<script>
import * as observationService from "../../../../api/observation-service";

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
        title: "Type",
        field: "TypeValue",
        sortable: false
      },
      {
        title: "Value",
        field: "OutputValue",
        sortable: false
      },
      {
        title: "Units",
        field: "Unit",
        sortable: false
      },
      {
        title: "Recorded Date",
        field: "RecordedDate",
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
        await this.getObservations();
      },
      deep: true
    }
  },
  methods: {
    async getObservations() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await observationService.getObservations(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
<template>
  <div>
    <div class="row">
      <a
        href="#"
        class="btn pull-right mb-15 bg-blue btn-labeled heading-btn legitRipple"
        data-toggle="modal"
        data-target="#addResidentAnalyze"
      >
        <b>
          <i class="icon-plus2"></i>
        </b> Add Resident Analyze
      </a>
    </div>

    <div class="row">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-analyze :residentId="residentId" :refreshList="getAnalyzes"/>
  </div>
</template>

<script>
import * as residentService from "../../../../api/resident-service";
import addNewAnalyze from "./components/add-new-analyze";

import Vue from "Vue";

export default {
  props: {
    residentId: {}
  },
  components: {
    addNewAnalyze: addNewAnalyze
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Doctor",
        field: "Doctor",
        sortable: false
      },
      {
        title: "Date",
        field: "Date",
        sortable: false
      },
      {
        title: "Analyze",
        field: "Analyzes",
        sortable: false
      },
      {
        title: "Room Number",
        field: "RoomNumber",
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
        await this.getAnalyzes();
      },
      deep: true
    }
  },
  methods: {
    async getAnalyzes() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await residentService.getResidentAnalyzes(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
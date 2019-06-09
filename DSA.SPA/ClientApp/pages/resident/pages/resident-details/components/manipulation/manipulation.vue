<template>
  <div>
    <div class="row">
      <a
        href="#"
        class="btn pull-right mb-15 bg-blue btn-labeled heading-btn legitRipple"
        data-toggle="modal"
        data-target="#addResidentManipulation"
      >
        <b>
          <i class="icon-plus2"></i>
        </b> Add Resident Manipulation
      </a>
    </div>

    <div class="row">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-manipulation :residentId="residentId" :refreshList="getManipulations"/>
  </div>
</template>

<script>
import * as residentService from "../../../../api/resident-service";
import addNewManipulation from "./components/add-new-manipulation";

import Vue from "Vue";

export default {
  props: {
    residentId: {}
  },
  components: {
    addNewManipulation: addNewManipulation
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
        title: "Manipulation",
        field: "Manipulation",
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
        await this.getManipulations();
      },
      deep: true
    }
  },
  methods: {
    async getManipulations() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await residentService.getResidentManipulations(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
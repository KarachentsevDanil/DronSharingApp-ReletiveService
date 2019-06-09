<template>
  <div>
    <div class="row">
      <a
        href="#"
        class="btn pull-right mb-15 bg-blue btn-labeled heading-btn legitRipple"
        data-toggle="modal"
        data-target="#addResidentDrug"
      >
        <b>
          <i class="icon-plus2"></i>
        </b> Add Resident Drug
      </a>
    </div>

    <div class="row">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-drug :residentId="residentId" :refreshList="getDrugs"/>
  </div>
</template>

<script>
import * as residentService from "../../../../api/resident-service";
import addNewDrug from "./components/add-new-drug";

import Vue from "Vue";

export default {
  props: {
    residentId: {}
  },
  components: {
    addNewDrug: addNewDrug
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
        title: "Start Date",
        field: "StartDate",
        sortable: false
      },
      {
        title: "End Date",
        field: "EndDate",
        sortable: false
      },
      {
        title: "Drug",
        field: "Drug",
        sortable: false
      },
      {
        title: "Unit",
        field: "Unit",
        sortable: false
      },
      {
        title: "Dosage",
        field: "Dosage",
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
        await this.getDrugs();
      },
      deep: true
    }
  },
  methods: {
    async getDrugs() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        residentId: this.residentId
      };

      let data = (await residentService.getResidentDrugs(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
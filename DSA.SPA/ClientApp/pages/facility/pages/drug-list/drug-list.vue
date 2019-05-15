<template>
  <div>
    <div class="page-header">
      <div class="page-header-content">
        <div class="page-title">
          <h4 class="grid-title">
            <i class="icon-home position-left"></i>
            <span class="text-semibold">Drug List</span>
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
              data-target="#addDrug"
            >
              <b>
                <i class="icon-plus2"></i>
              </b> Add Drug
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
            <a class="active">Drugs</a>
          </li>
        </ul>
      </div>
    </div>

    <div class="content">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-drug :refreshList="getDrugs"/>
  </div>
</template>

<script>
import * as drugService from "../../api/drug-service";

import addNewDrug from "./components/add-new-drug";

import Vue from "Vue";

export default {
  components: {
    addNewDrug: addNewDrug
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "Id",
        sortable: false
      },
      {
        title: "Name",
        field: "Name",
        sortable: false
      },
      {
        title: "Provider",
        field: "Provider",
        sortable: false
      },
      {
        title: "Unit",
        field: "Unit"
      },
      {
        title: "Dosage",
        field: "Value"
      },
      {
        title: "Price",
        field: "Price"
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
        take: this.query.limit
      };

      let data = (await drugService.getDrugs(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
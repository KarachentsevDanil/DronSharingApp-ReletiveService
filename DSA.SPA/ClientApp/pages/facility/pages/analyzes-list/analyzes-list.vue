<template>
  <div>
    <div class="page-header">
      <div class="page-header-content">
        <div class="page-title">
          <h4 class="grid-title">
            <i class="icon-user3 position-left"></i>
            <span class="text-semibold">Analyzes List</span>
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
              data-target="#addAnalyzes"
            >
              <b>
                <i class="icon-plus2"></i>
              </b> Add Analyzes
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
            <a class="active">Analyzes</a>
          </li>
        </ul>
      </div>
    </div>

    <div class="content">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-analyzes :refreshList="getAnalyzes"/>
  </div>
</template>

<script>
import * as analyzesService from "../../api/analyzes-service";

import addNewAnalyzes from "./components/add-new-analyzes";

import Vue from "Vue";

export default {
  components: {
    addNewAnalyzes: addNewAnalyzes
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
        title: "Department",
        field: "DepartmentName",
        sortable: false
      },
      {
        title: "RoomNumber",
        field: "RoomNumber",
        sortable: false
      },
      {
        title: "Description",
        field: "Description",
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
        take: this.query.limit
      };

      let data = (await analyzesService.getAnalyzes(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
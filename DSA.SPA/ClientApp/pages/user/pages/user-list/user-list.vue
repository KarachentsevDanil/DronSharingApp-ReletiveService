<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                
                        <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addDoctor">
                                <b><i class="icon-plus2"></i></b> Add User
                            </a>
                </div>
            </div>
        </div>

        <div class="content">
            <div class="panel panel-flat without-header">
                <datatable v-bind="$data" :HeaderSettings="false" />
            </div>
        </div>
        <add-new-user :refreshList="getUsers"/>
    </div>
</template>

<script>
import * as userService from "../../api/user-service";

import addNewUser from "./components/add-new-user";

import Vue from "Vue";

export default {
  components: {
    addNewUser: addNewUser
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Email",
        field: "Email",
        sortable: false
      },
      {
        title: "Full Name",
        field: "FullName",
        sortable: false
      },
      {
        title: "Facility",
        field: "FacilityName",
        sortable: false
      },
      {
        title: "Role",
        field: "Role",
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
        await this.getUsers();
      },
      deep: true
    }
  },
  methods: {
    async getUsers() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit,
        onlyWithFacility: true
      };

      let data = (await userService.getUsers(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
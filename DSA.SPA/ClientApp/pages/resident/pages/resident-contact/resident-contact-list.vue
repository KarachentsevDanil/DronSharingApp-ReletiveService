<template>
  <div>
    <div class="page-header">
      <div class="page-header-content">
        <div class="page-title">
          <h4 class="grid-title">
            <i class="icon-user3 position-left"></i>
            <span class="text-semibold">Resident Contact List</span>
          </h4>
          <a class="heading-elements-toggle">
            <i class="icon-more"></i>
          </a>
        </div>

        <div class="heading-elements">
          <div class="heading-btn-group">
            <a
              href="#"
              v-if="this.currentUser.Role == 'User'"
              class="btn bg-blue btn-labeled heading-btn legitRipple"
              data-toggle="modal"
              data-target="#addResident"
            >
              <b>
                <i class="icon-plus2"></i>
              </b> Add Relative
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
            <a class="active">Resident Contacts</a>
          </li>
        </ul>
      </div>
    </div>

    <div class="content">
      <div class="panel panel-flat without-header">
        <datatable v-bind="$data" :HeaderSettings="false"/>
      </div>
    </div>
    <add-new-resident-contact :refreshList="getResidents"/>
  </div>
</template>

<script>
import * as residentService from "../../api/resident-service";

import addNewResidentContact from "./components/add-new-resident-contact";
import residentActionCell from "./components/resident-action-cell";
import * as authGetters from "../../../auth/store/types/getter-types";
import * as authResources from "../../../auth/store/resources";

import { mapGetters } from "vuex";

import Vue from "Vue";

export default {
  components: {
    addNewResidentContact: addNewResidentContact,
    residentActionCell: residentActionCell
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Relative",
        field: "UserName",
        sortable: false
      },
      {
        title: "Resident",
        field: "ResidentName",
        sortable: false
      },
      {
        title: "Status",
        field: "StatusValue",
        sortable: false
      },
      {
        title: "Actions",
        tdComp: "residentActionCell",
        thStyle: { textAlign: "center" }
      }
    ],
    data: [],
    total: 0,
    query: {},
    xprops: {
      selectedResident: {}
    }
  }),
  watch: {
    query: {
      async handler() {
        await this.getResidents();
      },
      deep: true
    }
  },
  computed: {
    ...mapGetters({
      currentUser: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    })
  },
  methods: {
    async getResidents() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      if (this.currentUser.Role == "User") {
        params.userId = this.currentUser.UserId;
      }

      let data = (await residentService.getResidentContacts(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>
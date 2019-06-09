<template>
  <div class="navbar navbar-inverse bg-teal">
    <div class="navbar-boxed">
      <div class="navbar-header">
        <router-link class="navbar-brand" to="home">
          <img src="../../assets/limitless/images/logo_light.png" alt>
        </router-link>
        <ul class="nav navbar-nav visible-xs-block">
          <li>
            <a data-toggle="collapse" data-target="#navbar-mobile" class="legitRipple">
              <i class="icon-paragraph-justify3"></i>
            </a>
          </li>
        </ul>
      </div>
      <div class="navbar-collapse collapse" id="navbar-mobile">
        <ul class="nav navbar-nav navbar-right">
          <li class="dropdown dropdown-user">
            <a class="dropdown-toggle legitRipple" data-toggle="dropdown">
              <i class="icon-user"></i>
              <span>{{user.FirstName}} {{user.LastName}}</span>
              <i class="caret"></i>
            </a>
            <ul class="dropdown-menu dropdown-menu-right">
              <li v-for="(item, index) in getNavigationItems" :key="index">
                <router-link active-class="active" class="legitRipple" :to="item.path">
                  <div class="resident-icon-holder">
                    <i v-if="!item.p_Photo" :class="[item.iconClass, 'resident-icon']"></i>
                    <img v-else :src="item.p_Photo" class="img-circle img-xs">
                  </div>
                  <span>{{item.display}}</span>
                </router-link>
              </li>
              <li class="divider"></li>
              <li>
                <a href="#" class="legitRipple" v-on:click="logout">
                  <i class="icon-exit"></i>
                  Logout
                </a>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import * as httpService from "../../api/http-service";
import * as authGetters from "../auth/store/types/getter-types";
import * as authActions from "../auth/store/types/action-types";
import * as authResources from "../auth/store/resources";
import { mapGetters } from "vuex";

import * as mainStoreGetters from "../../store/types/action-types";

export default {
  data() {
    return {
      userNavigationItems: [
        {
          name: "home",
          path: "/home",
          display: "Home",
          iconClass: "icon-home2"
        },
        {
          name: "enrollment",
          path: "/resident-contacts",
          display: "My Relative",
          iconClass: "icon-user2"
        }
      ],
      facilityAdminNavigationItems: [
        {
          name: "home",
          path: "/home",
          display: "Home",
          iconClass: "icon-home2"
        },

        {
          name: "departments",
          path: "/departments",
          display: "Department List",
          iconClass: "icon-home3"
        },
        {
          name: "doctors",
          path: "/doctors",
          display: "Doctor List",
          iconClass: "icon-user3"
        },
        {
          name: "analyzes",
          path: "/analyzes",
          display: "Analyzes List",
          iconClass: "icon-user3"
        },
        {
          name: "manipulation",
          path: "/manipulations",
          display: "Manipulation List",
          iconClass: "icon-user3"
        },
        {
          name: "residents",
          path: "/resident-list",
          display: "Resident List",
          iconClass: "icon-user"
        },
        {
          name: "residentContacts",
          path: "/resident-contacts",
          display: "Resident Contact List",
          iconClass: "icon-user2"
        }
      ],
      doctorNavigationItems: [
        {
          name: "home",
          path: "/home",
          display: "Home",
          iconClass: "icon-home2"
        },
        {
          name: "residents",
          path: "/resident-list",
          display: "Resident List",
          iconClass: "icon-user"
        }
      ],
      globalNavigationItems: [
        {
          name: "home",
          path: "/home",
          display: "Home",
          iconClass: "icon-home2"
        },
        {
          name: "users",
          path: "/user-list",
          display: "User List",
          iconClass: "icon-user"
        },
        {
          name: "facilities",
          path: "/facilities",
          display: "Facility List",
          iconClass: "icon-home3"
        },
        {
          name: "drugs",
          path: "/drugs",
          display: "Drug List",
          iconClass: "icon-home3"
        }
      ]
    };
  },
  async beforeMount() {
    if (this.user.Role == "User") {
      let params = {
        url: `/api/account/getMyContacts?userId=${this.user.UserId}`
      };

      let residentsNavItems = (await httpService.getData(params)).data.Data
        .Collection;

      residentsNavItems.map(el => {
        el.display = el.ResidentName;
        el.path = "/resident-details/" + el.ResidentId;
        el.iconClass = "icon-user";
      });

      this.userNavigationItems = this.userNavigationItems.concat(
        residentsNavItems
      );
    }
  },
  computed: {
    ...mapGetters({
      user: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    }),
    getNavigationItems() {
      let userRole = this.user.Role;

      switch (userRole) {
        case "User":
          return this.userNavigationItems;
        case "Admin":
          return this.facilityAdminNavigationItems;
        case "GlobalAdmin":
          return this.globalNavigationItems;
        case "FacilityDoctor":
          return this.doctorNavigationItems;
      }
    }
  },
  methods: {
    logout() {
      this.$store.dispatch(
        authResources.AUTH_STORE_NAMESPACE.concat(authActions.LOGOUT_ACTION)
      );

      this.$router.push("/login");
    }
  }
};
</script>

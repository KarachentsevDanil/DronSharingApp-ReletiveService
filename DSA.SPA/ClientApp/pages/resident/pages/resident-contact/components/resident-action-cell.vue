<template>
    <div class="text-center">
        <ul class="icons-list" v-if="currentUser.Role != 'User'">
            <li class="dropdown dropup">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    <i class="icon-menu7"></i>
                </a>
                <ul class="dropdown-menu dropdown-menu-right">
                    <li>
                        <a href="#" @click="updateContactRecord(1)">
                            Approve
                        </a>
                    </li>
                     <li>
                        <a href="#" @click="updateContactRecord(2)">
                            Decline
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>

<script>
import { mapGetters } from "vuex";
import * as residentService from "../../../api/resident-service";
export default {
  props: ["row", "xprops"],
  methods: {
    updateContactRecord(status) {
      this.row.Status = status;
      residentService.updateResidentContact(this.row);
    }
  },
  computed: {
    ...mapGetters({
      currentUser: "authStore/getUser"
    })
  },
};
</script>
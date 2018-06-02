<template>
    <div>
        <div class="panel">
            <div class="panel-body text-center">
                <div class="icon-object border-success text-success">
                    <i class="far fa-calendar-alt"></i>
                </div>
                <h5 class="text-semibold">Schedule an Appointment</h5>
                <a href="#" class="btn bg-success-400 legitRipple" data-toggle="modal" data-target="#addNewAppointment">Select Date</a>

            </div>

        </div>
          <div id="addNewAppointment" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Schedule An Appointment</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                      <label>Date: </label>
                      <datetime type="datetime" input-class="form-control" v-model="date"></datetime>
                    </div>
                    <div class="form-group">
                        <label>Duration: </label>
                        <select class="form-control" v-model="duration">
                          <option value="0:30">0:30</option>
                          <option value="1:00">1:00</option>
                          <option value="1:30">1:30</option>
                          <option value="2:00">2:00</option>
                          <option value="2:30">2:30</option>
                          <option value="3:00">3:00</option>
                        </select>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addAppointment" type="button" :disabled="!date || !duration" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    </div>
</template>

<script>
import * as appointmentService from "../../../../api/appointment-service";
import { mapGetters } from "vuex";


export default {
  data() {
    return {
      date: "",
      duration: ""
    };
  },
  props: {
    residentDetails: {
      type: Object
    }
  },
  computed: {
    ...mapGetters({
      currentUser: "authStore/getUser"
    })
  },
  methods: {
    async addAppointment() {
      let params = {
        residentId: this.residentDetails.ResidentId,
        userId: this.currentUser.UserId,
        date: this.date,
        duration: this.duration
      };

      await appointmentService.addAppointment(params);

      this.$noty.success("Appointment was successfully scheduled.");
      $(".close").click();
    }
  }
};
</script>

<style scoped>
.event-details-block {
  margin-bottom: 20px;
  height: 220px;
  border-width: 0;
  color: #333;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
  background: #fff;
}

.event-details-block .icon-wrap {
  text-align: center;
}

.event-details-block .text-wrap {
  text-align: center;
  margin-top: 20px;
  font-weight: 800;
}

.event-details-block i {
  font-size: 32px;
  padding: 20px 22px;
  color: #4caf50;
  border: 3px solid #4caf50;
  border-radius: 50%;
  left: 50%;
}

div.dialog__container {
  width: 100%;
}

.schedule-button {
  width: 250px;
}

.schedule-btn-group {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.date-pick {
  height: 392px !important;
}

#schedule {
  margin-top: 20px;
  margin-left: -60px;
  left: 50%;
  width: 120px;
  background-color: #66bb6a;
  border-color: #66bb6a;
  color: #fff;
  font-weight: 500;
  font-size: 13px;
}
</style>

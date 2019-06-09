<template>
  <div id="profile" class="content">
    <div
      id="profile-block"
      class="panel profile-cover bg-blue-400 has-bg-image position-relative no-border-radius"
    >
      <profile-details :residentDetails="residentDetails" :fullDetails="fullDetails"></profile-details>
    </div>
    <div class="tabbable">
      <ul class="nav nav-tabs nav-tabs-highlight">
        <li class="active">
          <a href="#home" data-toggle="tab" class="legitRipple">Home</a>
        </li>
        <li>
          <a href="#doctors" data-toggle="tab" class="legitRipple">Doctors</a>
        </li>
        <li>
          <a href="#analyzes" data-toggle="tab" class="legitRipple">Analyzes</a>
        </li>
        <li>
          <a href="#drugs" data-toggle="tab" class="legitRipple">Drugs</a>
        </li>
        <li>
          <a href="#manipulations" data-toggle="tab" class="legitRipple">Manipulations</a>
        </li>
        <li>
          <a href="#appointments" data-toggle="tab" class="legitRipple">Appointments</a>
        </li>
        <li>
          <a href="#observations" data-toggle="tab" class="legitRipple">Observations</a>
        </li>
      </ul>

      <div class="tab-content">
        <div class="tab-pane active" id="home">
          <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
            <patient-schedule :residentDetails="residentDetails"></patient-schedule>
            <facility-details :residentDetails="residentDetails"></facility-details>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-4 col-xs-12">
            <bloodpressure-observation :residentId="id"></bloodpressure-observation>
            <heartrate-observation :residentId="id"></heartrate-observation>
            <temperature-observation :residentId="id"></temperature-observation>
            <activities :residentId="id"></activities>
          </div>
          <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
            <birthday-notification :residentDetails="residentDetails"></birthday-notification>
          </div>
        </div>
        <div class="tab-pane" id="doctors">
          <doctor-list :residentId="id"></doctor-list>
        </div>
        <div class="tab-pane" id="analyzes">
          <analyze-list :residentId="id"></analyze-list>
        </div>
        <div class="tab-pane" id="drugs">
          <drug-list :residentId="id"></drug-list>
        </div>
        <div class="tab-pane" id="manipulations">
          <manipulation-list :residentId="id"></manipulation-list>
        </div>
        <div class="tab-pane" id="appointments">
          <appointment-list :residentId="id"></appointment-list>
        </div>
        <div class="tab-pane" id="observations">
          <observation-list :residentId="id"></observation-list>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import profileDetails from "./components/profile/profile";
import birthdayNotification from "./components/timeline/birthday-notification";
import facilityDetails from "./components/timeline/facility-details";
import patientSchedule from "./components/timeline/patient-schedule";
import doctorList from "./components/doctor/doctor-list";
import observationList from "./components/observation/observation";
import appointmentList from "./components/appointment/appointment";
import analyzeList from "./components/analyze/analyze";
import drugList from "./components/drug/drug";
import manipulationList from "./components/manipulation/manipulation";
import bloodpressureObservation from "./components/timeline/observations/bloodpressure-observation";
import heartrateObservation from "./components/timeline/observations/heartrate-observation";
import temperatureObservation from "./components/timeline/observations/temperature-observation";
import activities from "./components/timeline/activities";

import * as residentService from "../../api/resident-service";

export default {
  props: {
    id: {
      required: true
    }
  },
  components: {
    profileDetails: profileDetails,
    birthdayNotification: birthdayNotification,
    facilityDetails: facilityDetails,
    patientSchedule: patientSchedule,
    doctorList: doctorList,
    analyzeList: analyzeList,
    drugList: drugList,
    manipulationList: manipulationList,
    appointmentList: appointmentList,
    bloodpressureObservation: bloodpressureObservation,
    heartrateObservation: heartrateObservation,
    temperatureObservation: temperatureObservation,
    observationList: observationList,
    activities: activities
  },
  data() {
    return {
      residentDetails: {},
      fullDetails: {}
    };
  },
  methods: {
    async getResidentPage() {
      let response = (await residentService.getResidentById(this.id)).data.Data;

      this.fullDetails = response;
      this.residentDetails = response.Resident;
    }
  },
  watch: {
    $route(to, from) {
      this.getResidentPage();
    }
  },
  beforeMount() {
    this.getResidentPage();
  }
};
</script>

<style>
.profile-nav-bar {
  z-index: 1;
}

#profile-block {
  margin-bottom: 0px !important;
}
</style>

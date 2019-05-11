<template>
  <div class="panel bg-blue-400">
    <div class="panel-body position-relative">
      <div class="media no-margin">
        <div class="media-body text-left">
          <h3
            class="media-heading text-semibold"
          >{{temperatureInfo.Value +' '+ temperatureInfo.Unit}}</h3>
          <span class="text-uppercase">Temperature</span>
          <div
            class="text-size-small"
            v-html="'New measurement as of '+ temperatureInfo.RecordedDate"
          ></div>
        </div>
      </div>
      <div class="observation-icon">
        <i class="icon-temperature"></i>
      </div>
    </div>

    <div id="chart_area_temp" style="height:50px;"></div>
  </div>
</template>

<script>
import { renderAreaChart } from "../../../../../../plugins/observation-charts";
import * as observationService from "../../../../../api/observation-service";
import * as moment from "moment";
import d3 from "d3";
import d3Tip from "d3-tip";
d3.tip = d3Tip;

export default {
  data() {
    return {
      temperatureInfo: {}
    };
  },
  props: {
    residentId: {}
  },
  async beforeMount() {
    let params = {
      residentId: this.residentId,
      type: 5,
      take: 7
    };

    let observations = (await observationService.getObservationsByType(params))
      .data.Observations;

    this.temperatureInfo = {
      ...observations[0]
    };

    renderAreaChart(
      "#chart_area_temp",
      observations,
      "",
      50,
      "rgba(255,255,255,0.75)"
    );
  }
};
</script>


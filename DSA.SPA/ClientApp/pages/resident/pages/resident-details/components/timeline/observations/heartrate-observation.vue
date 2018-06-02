<template>
    <div class="panel bg-danger-400">
        <div class="panel-body position-relative">
            <div class="media no-margin">
                <div class="media-body text-left">
                    <h3 class="media-heading text-semibold">{{heartrateInfo.Value}} {{heartrateInfo.Unit}}</h3>
                    <span class="text-uppercase">Heart rate</span>
                    <div class="text-size-small" v-html="'New measurement as of '+ heartrateInfo.RecordedDate"></div>
                </div>
            </div>
            <div class="observation-icon">
                <i class="icon-pulse"></i>
            </div>
        </div>
        <div class="container-graph">
        </div>
    </div>
</template>

<script>
import { renderBarChart } from "../../../../../../plugins/observation-charts";
import * as observationService from "../../../../../api/observation-service";
import * as moment from "moment";
import d3 from "d3";
import d3Tip from "d3-tip";
d3.tip = d3Tip;

export default {
  data() {
    return {
      heartrateInfo: {},
      observations: {}
    };
  },
  props: {
    residentId: {}
  },
  async beforeMount() {
    let params = {
      residentId: this.residentId,
      type: 2,
      take: 30
    };

    let observations = (await observationService.getObservationsByType(params))
      .data.Observations;

    this.heartrateInfo = {
      ...observations[observations.length - 1]
    };
    renderBarChart(
      ".container-graph",
      observations,
      observations.length,
      50,
      true,
      "elastic",
      1200,
      50,
      "rgba(255,255,255,0.75)",
      "BPM"
    );
  }
};
</script>


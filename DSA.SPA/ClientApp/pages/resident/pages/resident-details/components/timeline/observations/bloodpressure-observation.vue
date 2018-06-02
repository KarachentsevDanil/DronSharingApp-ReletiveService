<template>
    <div class="panel">
        <div class="panel-body position-relative">
            <div class="media no-margin">
                <div class="media-body text-left">
                    <h3 class="media-heading text-semibold">{{bloodpressureInfo.SystolicValue +'/'+ bloodpressureInfo.DiastolicValue +' '+ bloodpressureInfo.Unit}}</h3>
                    <span class="text-muted text-uppercase ">Blood Pressure</span>
                    <div class="text-muted text-size-small" v-html="'New measurement as of '+ bloodpressureInfo.RecordedDate"></div>
                </div>
            </div>
            <div class="observation-icon">
                <i class="icon-blood-pressure-control-tool"></i>
            </div>
        </div>
        <div id="line_chart_simple"></div>
    </div>
</template>

<script>
import { renderTwoLineGraph } from "../../../../../../plugins/observation-charts";
import * as observationService from "../../../../../api/observation-service";
import * as moment from "moment";
import d3 from "d3";
import d3Tip from "d3-tip";
d3.tip = d3Tip;

export default {
  data() {
    return {
      bloodpressureInfo: {}
    };
  },
  props: {
    residentId: {}
  },
  async beforeMount() {
    let params = {
      residentId: this.residentId,
      type: 1,
      take: 30
    };

    let observations = (await observationService.getObservationsByType(params))
      .data.Observations;

    this.bloodpressureInfo = observations[observations.length - 1];

    renderTwoLineGraph(
      "#line_chart_simple",
      observations,
      "",
      80,
      "#2196F3",
      "#ef5350",
      "rgba(33,150,243,0.5)",
      "#2196F3",
      "#fff",
      "#ef5350",
      "#fff"
    );
  }
};
</script>


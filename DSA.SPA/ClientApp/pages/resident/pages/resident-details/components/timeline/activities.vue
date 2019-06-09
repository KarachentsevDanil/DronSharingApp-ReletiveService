<template>
  <div>
    <activity-item v-for="(timelineItem, index) in timeline" :key="index" :item="timelineItem"/>
  </div>
</template>

<script>
import * as residentService from "../../../../api/resident-service";
import activity from "./activity";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      timeline: []
    };
  },
  components: {
    activityItem: activity
  },
  async beforeMount() {
    let timeline = (await residentService.getResidentTimeline(this.residentId))
      .data.Data;
    console.log(timeline);
    this.timeline = timeline;
  },
  props: {
    residentId: {}
  }
};
</script>
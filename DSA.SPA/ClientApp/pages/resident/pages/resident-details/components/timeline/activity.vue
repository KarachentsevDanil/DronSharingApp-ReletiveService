<template>
  <div>
    <div class="panel bg-violet-400 timeline-item" v-if="item.Type == 2">
      <div class="panel-body position-relative">
        <div class="media no-margin">
          <div class="media-body text-left">
            <h3 class="media-heading text-semibold">Resident Drug</h3>
            <h5 class="text-semibold media-heading">{{item.Item.Drug}}</h5>
            <h6 class="text-semibold media-heading">Appointed By: {{item.Item.Doctor}}</h6>
            <span class="text-uppercase">Dosage - {{item.Item.Dosage}} {{item.Item.Unit}}</span>
            <div class>From: {{item.Item.StartDate}} To: {{item.Item.EndDate}}</div>
          </div>
        </div>
        <div class="observation-icon">
          <i class="icon-pill"></i>
        </div>
      </div>
    </div>
    <div class="panel bg-teal-400 timeline-item" v-if="item.Type == 1">
      <div class="panel-body position-relative">
        <div class="media no-margin">
          <div class="media-body text-left">
            <h3 class="media-heading text-semibold">Resident Analyze</h3>
            <h5 class="text-semibold media-heading">{{item.Item.Analyzes}}</h5>
            <h6 class="text-semibold media-heading">Appointed By: {{item.Item.Doctor}}</h6>
            <span class="text-uppercase">Room: {{item.Item.RoomNumber}}</span>
            <div class>Date: {{item.Item.Date}}</div>
          </div>
        </div>
        <div class="observation-icon">
          <i class="icon-lab"></i>
        </div>
      </div>
    </div>
    <div class="panel bg-info-600 timeline-item" v-if="item.Type == 3">
      <div class="panel-body position-relative">
        <div class="media no-margin">
          <div class="media-body text-left">
            <h3 class="media-heading text-semibold">Resident Manipulation</h3>
            <h5 class="text-semibold media-heading">{{item.Item.Manipulation}}</h5>
            <h6 class="text-semibold media-heading">Appointed By: {{item.Item.Doctor}}</h6>
            <span class="text-uppercase">Room - {{item.Item.RoomNumber}}</span>
            <div class>Date: {{item.Item.Date}}</div>
          </div>
        </div>
        <div class="observation-icon">
          <i class="icon-power2"></i>
        </div>
      </div>
    </div>
    <div class="panel bg-success-600 timeline-item" v-if="item.Type == 4">
      <div class="panel-body position-relative">
        <div class="media no-margin">
          <div class="media-body text-left">
            <h3 class="media-heading text-semibold media-heading">Resident Appointment</h3>
            <h5 class="text-semibold media-heading">Visitor: {{item.Item.UserName}}</h5>
            <div class>Date: {{item.Item.DateValue}} - {{item.Item.Period}}</div>
          </div>
        </div>
        <div class="observation-icon">
          <i class="icon-calendar2"></i>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    item: {}
  }
};
</script>

<style>
.timeline-item {
  height: 165px;
}
</style>

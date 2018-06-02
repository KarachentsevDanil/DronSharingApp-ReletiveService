<template>
    <div class="panel panel-flat facility-contact">
        <div class="panel-body">
            <h6 class="no-margin-top"><a>{{ residentDetails.FacilityName }}</a></h6>
        </div>
        <div class="facility-map">
            <iframe width="100%"
                    height="200"
                    frameborder="0" style="border:0"
                    :src="mapUrl"></iframe>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label class="control-label no-margin text-semibold"><i class="icon-phone2"></i> Phone:</label>
                <div class="pull-right"> + 380 66 295 22 22</div>
            </div>
            <div class="form-group">
                <label class="control-label no-margin text-semibold"><i class="icon-envelop"></i> Email:</label>
                <div class="pull-right">test-email@gmail.com</div>
            </div>
        </div>
        <div class="panel-body text-center alpha-grey">
            <h6 class="">Visitor Hours</h6>

            <ul class="timer-weekdays mb-10">
                <li 
                     v-for="(day, index) in workingDays"
                     :class="{ active: day.isActive, day }"
                     :key="day.day"
                    >
                    <a :class="[ day.isActive?'label-danger':'label-default', 'label' ]" @click="activateDay(index)">
                        {{ day.day }}
                    </a>
                </li>
            </ul>

            <ul class="timer mb-10">
                {{ workingHours }}
            </ul>

        </div>
       
    </div>
</template>

<script>
    export default {
        data() {
            return {
                workingDays: [
                    {
                        day: 'Mon',
                        hours: '09:00 am - 02:00 pm',
                        isActive: true
                    },
                    {
                        day: 'Tue',
                        hours: '11:00 am - 02:00 pm',
                        isActive: false
                    },
                    {
                        day: 'Wed',
                        hours: '09:00 am - 06:00 pm',
                        isActive: false
                    },
                    {
                        day: 'Thu',
                        hours: '10:00 am - 02:00 pm',
                        isActive: false
                    },
                    {
                        day: 'Fri',
                        hours: '09:00 am - 02:00 pm',
                        isActive: false
                    },
                    {
                        day: 'Sat',
                        hours: '09:00 am - 01:00 pm',
                        isActive: false
                    },
                    {
                        day: 'Sun',
                        hours: 'Closed',
                        isActive: false
                    },
                ],
                workingHours: '09:00 am - 02:00 pm',
                mapUrl: "https://www.google.com/maps/embed/v1/place?key=AIzaSyBP2LMWhQWgru1NtX5o20oScy5g0twDWH8&q=Ukraine"
            };
        },
        props: {
            residentDetails: {
                type: Object
            }
        },
        methods: {
            activateDay(dayIndex) {
                this.workingDays.map((el) => { el.isActive = false; });
                this.workingDays[dayIndex].isActive = true;
                this.workingHours = this.workingDays[dayIndex].hours;
            }
        }
    };
</script>

<style>
    .facility-info .font-weight-bold {
        font-weight: bold;
    }

    .facility-info {
        border-width: 0;
        color: #333;
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
        padding: 15px 0 25px;
        background: #fff;
    }

        .facility-info .facility-name {
            padding: 5px 0 10px 20px;
        }

            .facility-info .facility-name a {
                color: #1E88E5;
                font-size: 15px;
            }

        .facility-info .facility-address {
            padding: 5px 20px 10px;
            font-size: 12px;
        }

        .facility-info .facility-map {
            margin: 10px auto;
        }

        .facility-info .contact-item {
            padding: 10px 20px;
            font-size: 13px;
        }

            .facility-info .contact-item .contact-value {
                float: right;
            }

            .facility-info .contact-item .contact-title {
                font-weight: 500;
            }

        .facility-info .working-hours {
            text-align: center;
        }

            .facility-info .working-hours .working-title {
                font-weight: 400;
                font-size: 15px;
            }

            .facility-info .working-hours .working-time {
                font-size: 22px;
                color: #555;
                font-weight: 300;
            }

            .facility-info .working-hours .working-days {
                margin: 10px 0;
            }

            .facility-info .working-hours .day-wrap {
                display: inline-block;
            }

            .facility-info .working-hours .working-days .day {
                display: inline-block;
                text-transform: uppercase;
                font-size: 10px;
                border-radius: 1px;
                background: #ccc;
                padding: 2px 2px 1px 2px;
                margin: 0 3px;
                font-weight: 500;
                color: #fff;
                cursor: pointer;
                transition: all .3s;
            }

                .facility-info .working-hours .working-days .day:hover {
                    background: #999;
                }

                .facility-info .working-hours .working-days .day.active {
                    background: #F44336;
                }
</style>

<template>
    <div class="birthsday-block">
        <h2 class="no-margin bitrhsday-header">
            It is {{residentDetails.FirstName}}`s birthday
            <div>
                in <span class="days-number">{{residentDetails.DaysToBirthday}}</span> DAYS!
            </div>
        </h2>
        <!--<div class="send-gift-block">
            <v-btn>Send Greeting</v-btn>
        </div>-->
    </div>
</template>

<script>
    export default {
        props: {
            residentDetails: {
                type: Object
            }
        }
    };
</script>


<style>
    .birthsday-block {
        background-color: #7e57c2;
        border-color: #7e57c2;
        color: #fff;
        margin-bottom: 25px;
        padding: 20px;
        text-align: center;
        border-radius: 3px;
        background-image: url(http://www.engagesnf.com/sample/v1/assets/images/backgrounds/party-cake.png);
        background-position-x: center;
        box-shadow: 0 1px 3px rgba(0, 0, 0, 0.12), 0 1px 2px rgba(0, 0, 0, 0.24);
        font-family: "Roboto", Helvetica Neue, Helvetica, Arial, sans-serif;
    }

        .birthsday-block .bitrhsday-header {
            font-size: 23px;
            line-height: 50px;
            font-weight: 100;
        }

        .birthsday-block .send-gift-block {
            margin-top: 10px;
            text-align: center;
        }

        .birthsday-block .bitrhsday-header .days-number {
            font-size: 65px;
            font-weight: normal;
        }
</style>

<template>
    <div id="home" class="content">
        <div class="row">
          <div class="col-lg-12">
              
        <div class="panel profile-cover has-bg-image home-panel">
            <div class="text-center">
                <div class="panel-body">
                    <h3 class="home-header">Welcome to the Family Portal</h3>
                    <span class="subheading">From now on, on our Website through the family portal that has been prepared exclusively for you, who have joined the Family Portal will be able to follow the latest news of their family members and obtain detailed information on the spot.</span>
                    <hr class="divider">
                </div>
            </div>
        </div>
          </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                gradient: 'to top, #aba, #009688'
            }
        },
        methods: {
            redirect() {
                this.$router.replace('/add-relative');
            }
        }
    }
</script>

<style scoped>
    .home-panel {
        background: linear-gradient(to top, rgb(170, 187, 170), rgb(0, 150, 136));
        color:white;
    }
    .home-header {
        font-size: 56px !important;
        font-weight: 400;
        line-height: 1.35 !important;
        letter-spacing: -0.02em !important;
    }
</style>

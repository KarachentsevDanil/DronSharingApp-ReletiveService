import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import pagination from './assets/vue-pagination/vue-pagination'
import vueSlider from 'vue-slider-component';
import BlockUI from 'vue-blockui'
import StarRating from 'vue-star-rating'
import vue2Dropzone from 'vue2-dropzone'
import VueNoty from 'vuejs-noty'
import Datetime from 'vue-datetime'

import Datatable from 'vue2-datatable-component';
import grid from './pages/plugins/datatable/datatable';
import select2 from './pages/plugins/select2/select2'

import App from './pages/layout/app-root'

import 'vue2-dropzone/dist/vue2Dropzone.css'
import 'vuejs-noty/dist/vuejs-noty.css'
import 'vue-datetime/dist/vue-datetime.css'

Vue.prototype.$http = axios;

sync(store, router);

Vue.use(VueNoty);
Vue.use(BlockUI);
Vue.use(Datatable);
Vue.use(Datetime);

Vue.component('pagination', pagination);
Vue.component('vueDropzone', vue2Dropzone);
Vue.component('vueSlider', vueSlider);
Vue.component('starRating', StarRating);
Vue.component('grid', grid);
Vue.component('select2', select2);

const app = new Vue({
    store,
    router,
    ...App
});

export {
    app,
    router,
    store
}

// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import 'cxlt-vue2-toastr/dist/css/cxlt-vue2-toastr.css'
import CxltToastr from 'cxlt-vue2-toastr'
import Axios from 'axios'
import StoreAuthConstants from '@/store/constants/auth'
import store from '@/store/store'

Vue.use(CxltToastr, {
  position: 'bottom right',
  showDuration: 500,
  hideDuration: 2000,
  timeOut: 2000,
  progressBar: true,
  showMethod: 'zoomIn',
  hideMethod: 'bounceOutLeft',
  colseButton: true
})
Vue.use(Vuetify, {
  theme: {
    primary: '#283593',
    secondary: '#303F9F',
    accent: '#0277BD',
    error: '#D50000',
    warning: '#ffeb3b',
    info: '#2196f3',
    success: '#4caf50'
  }
})
Axios.defaults.baseURL = process.env.API_ENDPOINT
if (store.getters[StoreAuthConstants.GETTERS.IS_AUTH]) {
  Axios.defaults.headers.common[StoreAuthConstants.STATES.TOKEN] = store.getters[StoreAuthConstants.GETTERS.TOKEN]
}
Vue.config.productionTip = false

/* eslint-disable no-new */
let instance = new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})

window.Toast = instance.$toast

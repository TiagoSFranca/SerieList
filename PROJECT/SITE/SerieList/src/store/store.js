import Vue from 'vue'
import Vuex from 'vuex'
import auth from '@/store/modules/auth'
import general from '@/store/modules/general'
import serie from '@/store/modules/serie'
import productStatus from '@/store/modules/product-status'
import visibility from '@/store/modules/visibility'
Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    auth,
    general,
    serie,
    productStatus,
    visibility
  }
})

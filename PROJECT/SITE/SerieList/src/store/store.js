import Vue from 'vue'
import Vuex from 'vuex'
import auth from '@/store/modules/auth'
import general from '@/store/modules/general'
Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    auth,
    general
  }
})

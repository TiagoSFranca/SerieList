import Vue from 'vue'
import Vuex from 'vuex'
import auth from '@/store/modules/auth'
import general from '@/store/modules/general'
import serie from '@/store/modules/serie'
Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    auth,
    general,
    serie
  }
})

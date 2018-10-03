import AUTH from '@/store/constants/auth'
const module = {
  state: {
    [AUTH.STATES.TOKEN]: '',
    [AUTH.STATES.IS_AUTH]: false
  },
  getters: {
    [AUTH.GETTERS.TOKEN]: state => {
      return state[AUTH.STATES.TOKEN]
    },
    [AUTH.GETTERS.IS_AUTH]: state => {
      return state[AUTH.STATES.IS_AUTH]
    }
  },
  mutations: {
    [AUTH.MUTATIONS.SET_TOKEN] (state, pageTitle) {
      state.pageTitle = pageTitle
    },
    [AUTH.MUTATIONS.REMOVE_TOKEN]: (state) => {
      state.token = ''
    }
  }
}
export default module

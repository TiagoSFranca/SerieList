import AUTH from '@/store/constants/auth'
const module = {
  state: {
    [AUTH.STATES.TOKEN]: 'nv8OTbkr1oit3BXngxq8Q63m33UyDf5XCwAAAAEAMQAAAJ7/Dk25K9aIrKmwRzoAY0SiASMwS3G2ug==',
    [AUTH.STATES.IS_AUTH]: true,
    [AUTH.STATES.SHOW_LOGOUT_MODAL]: false
  },
  getters: {
    [AUTH.GETTERS.TOKEN]: state => {
      return state[AUTH.STATES.TOKEN]
    },
    [AUTH.GETTERS.IS_AUTH]: state => {
      return state[AUTH.STATES.IS_AUTH]
    },
    [AUTH.GETTERS.SHOW_LOGOUT_MODAL]: state => {
      return state[AUTH.STATES.SHOW_LOGOUT_MODAL]
    }
  },
  mutations: {
    [AUTH.MUTATIONS.SET_TOKEN] (state, token) {
      state[AUTH.STATES.TOKEN] = token
      state[AUTH.STATES.IS_AUTH] = true
    },
    [AUTH.MUTATIONS.REMOVE_TOKEN]: (state) => {
      state[AUTH.STATES.TOKEN] = ''
      state[AUTH.STATES.IS_AUTH] = false
    },
    [AUTH.MUTATIONS.SHOW_LOGOUT_MODAL]: (state, show) => {
      state[AUTH.STATES.SHOW_LOGOUT_MODAL] = show
    }
  },
  actions: {
    [AUTH.ACTIONS.SET_TOKEN] (context, token) {
      context.commit(AUTH.MUTATIONS.SET_TOKEN, token)
    },
    [AUTH.ACTIONS.REMOVE_TOKEN] (context) {
      context.commit(AUTH.MUTATIONS.REMOVE_TOKEN)
    },
    [AUTH.ACTIONS.SHOW_LOGOUT_MODAL] (context, show) {
      context.commit(AUTH.MUTATIONS.SHOW_LOGOUT_MODAL, show)
    }
  }
}
export default module

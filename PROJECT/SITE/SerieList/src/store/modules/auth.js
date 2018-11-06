import AUTH from '@/store/constants/auth'
const module = {
  state: {
    [AUTH.STATES.TOKEN]: 'jBjFkQRE1oit3BXngxq8Q63m33UyDf5XCwAAAAEBSgAAAGVoxZEERNaITQvUFU3Phki/JRC1eB4YIg==',
    [AUTH.STATES.IS_AUTH]: true,
    [AUTH.STATES.SHOW_LOGOUT_MODAL]: false,
    [AUTH.STATES.USER_DATA]: {
      CreatedAt: '2018-08-29T10:38:15',
      Excluded: false,
      IdProfile: 1,
      IdUser: 11,
      IdUserStatus: 1
    }
  },
  getters: {
    [AUTH.GETTERS.TOKEN]: state => {
      return state[AUTH.STATES.TOKEN]
    },
    [AUTH.GETTERS.USER_DATA]: state => {
      return state[AUTH.STATES.USER_DATA]
    },
    [AUTH.GETTERS.IS_AUTH]: state => {
      return state[AUTH.STATES.IS_AUTH]
    },
    [AUTH.GETTERS.SHOW_LOGOUT_MODAL]: state => {
      return state[AUTH.STATES.SHOW_LOGOUT_MODAL]
    }
  },
  mutations: {
    [AUTH.MUTATIONS.SET_TOKEN] (state, data) {
      state[AUTH.STATES.TOKEN] = data.Token
      state[AUTH.STATES.USER_DATA] = data.User
      state[AUTH.STATES.IS_AUTH] = true
    },
    [AUTH.MUTATIONS.REMOVE_TOKEN]: (state) => {
      state[AUTH.STATES.TOKEN] = ''
      state[AUTH.STATES.USER_DATA] = null
      state[AUTH.STATES.IS_AUTH] = false
    },
    [AUTH.MUTATIONS.SHOW_LOGOUT_MODAL]: (state, show) => {
      state[AUTH.STATES.SHOW_LOGOUT_MODAL] = show
    }
  },
  actions: {
    [AUTH.ACTIONS.SET_TOKEN] (context, data) {
      context.commit(AUTH.MUTATIONS.SET_TOKEN, data)
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

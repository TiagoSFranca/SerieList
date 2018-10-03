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
    [AUTH.MUTATIONS.SET_TOKEN] (state, token) {
      state[AUTH.STATES.TOKEN] = token
      state[AUTH.STATES.IS_AUTH] = true
      console.log(state[AUTH.STATES.TOKEN])
    },
    [AUTH.MUTATIONS.REMOVE_TOKEN]: (state) => {
      state[AUTH.STATES.REMOVE_TOKEN] = ''
      state[AUTH.STATES.IS_AUTH] = false
    }
  },
  actions: {
    [AUTH.ACTIONS.SET_TOKEN] (context, token) {
      context.commit(AUTH.MUTATIONS.SET_TOKEN, token)
    },
    [AUTH.ACTIONS.REMOVE_TOKEN] (context) {
      context.commit(AUTH.MUTATIONS.REMOVE_TOKEN)
    }
  }
}
export default module

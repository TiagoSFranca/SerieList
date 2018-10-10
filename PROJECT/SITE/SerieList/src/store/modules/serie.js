import SERIE from '@/store/constants/serie'
const module = {
  state: {
    [SERIE.STATES.RESULT]: {
      Items: []
    }
  },
  getters: {
    [SERIE.GETTERS.GET_RESULT]: state => {
      return state[SERIE.STATES.RESULT]
    }
  },
  mutations: {
    [SERIE.MUTATIONS.ADD_RESULT] (state, items) {
      state[SERIE.STATES.RESULT] = items
    }
  },
  actions: {
    [SERIE.ACTIONS.ADD_RESULT] (context, items) {
      context.commit(SERIE.MUTATIONS.ADD_RESULT, items)
    }
  }
}
export default module

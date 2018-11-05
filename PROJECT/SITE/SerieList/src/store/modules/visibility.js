import VISIBILITY from '@/store/constants/visibility'
const module = {
  state: {
    [VISIBILITY.STATES.RESULT]: {
      Items: []
    }
  },
  getters: {
    [VISIBILITY.GETTERS.GET_RESULT]: state => {
      return state[VISIBILITY.STATES.RESULT]
    }
  },
  mutations: {
    [VISIBILITY.MUTATIONS.ADD_RESULT] (state, items) {
      state[VISIBILITY.STATES.RESULT] = items
    }
  },
  actions: {
    [VISIBILITY.ACTIONS.ADD_RESULT] (context, items) {
      context.commit(VISIBILITY.MUTATIONS.ADD_RESULT, items)
    }
  }
}
export default module

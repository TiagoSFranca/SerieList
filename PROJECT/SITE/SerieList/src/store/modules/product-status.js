import PRODUCT_STATUS from '@/store/constants/product-status'
const module = {
  state: {
    [PRODUCT_STATUS.STATES.RESULT]: {
      Items: []
    }
  },
  getters: {
    [PRODUCT_STATUS.GETTERS.GET_RESULT]: state => {
      return state[PRODUCT_STATUS.STATES.RESULT]
    }
  },
  mutations: {
    [PRODUCT_STATUS.MUTATIONS.ADD_RESULT] (state, items) {
      state[PRODUCT_STATUS.STATES.RESULT] = items
    }
  },
  actions: {
    [PRODUCT_STATUS.ACTIONS.ADD_RESULT] (context, items) {
      context.commit(PRODUCT_STATUS.MUTATIONS.ADD_RESULT, items)
    }
  }
}
export default module

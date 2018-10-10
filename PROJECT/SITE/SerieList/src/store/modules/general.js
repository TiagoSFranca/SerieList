import GENERAL from '@/store/constants/general'
const module = {
  state: {
    [GENERAL.STATES.SHOW_DRAWER]: false,
    [GENERAL.STATES.SHOW_PROGRESS_BAR]: false,
    [GENERAL.STATES.SHOW_PROGRESS_CIRCULAR]: false
  },
  getters: {
    [GENERAL.GETTERS.SHOW_DRAWER]: state => {
      return state[GENERAL.STATES.SHOW_DRAWER]
    },
    [GENERAL.GETTERS.SHOW_PROGRESS_BAR]: state => {
      return state[GENERAL.STATES.SHOW_PROGRESS_BAR]
    },
    [GENERAL.GETTERS.SHOW_PROGRESS_CIRCULAR]: state => {
      return state[GENERAL.STATES.SHOW_PROGRESS_CIRCULAR]
    }
  },
  mutations: {
    [GENERAL.MUTATIONS.CHANGE_SHOW_DRAWER] (state, showDrawer) {
      state[GENERAL.STATES.SHOW_DRAWER] = showDrawer
    },
    [GENERAL.MUTATIONS.CHANGE_SHOW_PROGRESS_BAR] (state, showProgressBar) {
      state[GENERAL.STATES.SHOW_PROGRESS_BAR] = showProgressBar
    },
    [GENERAL.MUTATIONS.CHANGE_SHOW_PROGRESS_CIRCULAR] (state, showProgressCircular) {
      state[GENERAL.STATES.SHOW_PROGRESS_CIRCULAR] = showProgressCircular
    }
  },
  actions: {
    [GENERAL.ACTIONS.CHANGE_SHOW_DRAWER] (context, showDrawer) {
      context.commit(GENERAL.MUTATIONS.CHANGE_SHOW_DRAWER, showDrawer)
    },
    [GENERAL.ACTIONS.CHANGE_SHOW_PROGRESS_BAR] (context, showProgressBar) {
      context.commit(GENERAL.MUTATIONS.CHANGE_SHOW_PROGRESS_BAR, showProgressBar)
    },
    [GENERAL.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR] (context, showProgressCircular) {
      context.commit(GENERAL.MUTATIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, showProgressCircular)
    }
  }
}
export default module

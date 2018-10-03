import GENERAL from '@/store/constants/general'
const module = {
  state: {
    [GENERAL.STATES.PAGE_TITLE]: 'TESTE',
    [GENERAL.STATES.SHOW_DRAWER]: false,
    [GENERAL.STATES.SHOW_LOADER]: false
  },
  getters: {
    [GENERAL.GETTERS.PAGE_TITLE]: state => {
      return state[GENERAL.STATES.PAGE_TITLE]
    },
    [GENERAL.GETTERS.SHOW_DRAWER]: state => {
      return state[GENERAL.STATES.SHOW_DRAWER]
    },
    [GENERAL.GETTERS.SHOW_LOADER]: state => {
      return state[GENERAL.STATES.SHOW_LOADER]
    }
  },
  mutations: {
    [GENERAL.MUTATIONS.CHANGE_PAGE_TITLE] (state, pageTitle) {
      state[GENERAL.STATES.PAGE_TITLE] = pageTitle
    },
    [GENERAL.MUTATIONS.CHANGE_SHOW_DRAWER] (state, showDrawer) {
      state[GENERAL.STATES.SHOW_DRAWER] = showDrawer
    },
    [GENERAL.MUTATIONS.CHANGE_SHOW_LOADER] (state, showLoader) {
      state[GENERAL.STATES.SHOW_LOADER] = showLoader
    }
  },
  actions: {
    [GENERAL.ACTIONS.CHANGE_PAGE_TITLE] (context, pageTitle) {
      context.commit(GENERAL.MUTATIONS.CHANGE_PAGE_TITLE, pageTitle)
    },
    [GENERAL.ACTIONS.CHANGE_SHOW_DRAWER] (context, showDrawer) {
      context.commit(GENERAL.MUTATIONS.CHANGE_SHOW_DRAWER, showDrawer)
    },
    [GENERAL.ACTIONS.CHANGE_SHOW_LOADER] (context, showLoader) {
      context.commit(GENERAL.MUTATIONS.CHANGE_SHOW_LOADER, showLoader)
    }
  }
}
export default module

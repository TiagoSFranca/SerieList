const AUTH = {
  MUTATIONS: {
    SET_TOKEN: 'SET_TOKEN',
    REMOVE_TOKEN: 'REMOVE_TOKEN',
    IS_AUTH: 'IS_AUTH',
    SHOW_LOGOUT_MODAL: 'SHOW_LOGOUT_MODAL'
  },
  GETTERS: {
    TOKEN: 'getToken',
    USER_DATA: 'getUserData',
    IS_AUTH: 'isAuth',
    SHOW_LOGOUT_MODAL: 'getShowLogoutModal'
  },
  STATES: {
    TOKEN: 'token',
    USER_DATA: 'userData',
    IS_AUTH: 'isAuth',
    SHOW_LOGOUT_MODAL: 'showLogoutModal'
  },
  ACTIONS: {
    SET_TOKEN: 'setToken',
    REMOVE_TOKEN: 'removeToken',
    SHOW_LOGOUT_MODAL: 'showLogoutModal'
  }
}
export default AUTH

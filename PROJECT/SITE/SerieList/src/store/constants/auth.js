const AUTH = {
  MUTATIONS: {
    SET_TOKEN: 'SET_TOKEN',
    REMOVE_TOKEN: 'REMOVE_TOKEN',
    IS_AUTH: 'IS_AUTH'
  },
  GETTERS: {
    TOKEN: 'getToken',
    IS_AUTH: 'isAuth'
  },
  STATES: {
    TOKEN: 'token',
    IS_AUTH: false
  },
  ACTIONS: {
    SET_TOKEN: 'setToken',
    REMOVE_TOKEN: 'removeToken'
  }
}
export default AUTH

export default {
  getToken () {
    return localStorage.getItem(this.constants.tokenName)
  },
  setToken (token) {
    localStorage.setItem(this.constants.tokenName, token)
  },
  removeToken () {
    localStorage.removeItem(this.constants.tokenName)
  },
  constants: {
    loginPage: 'Login',
    tokenName: 'Token'
  }
}

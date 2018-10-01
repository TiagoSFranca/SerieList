import Axios from 'axios'
import Constants from '@/helpers/constants'
import qs from 'qs'
const RESOURCE_NAME = '/AccessControl'
export default {
  Auth (username, password) {
    let obj = {
      Login: username,
      Password: password,
      ApplicationType: Constants.ApplicationType
    }
    return Axios.post(RESOURCE_NAME + '/authenticate', qs.stringify(obj))
  },
  Unauth () {
    return Axios.post(RESOURCE_NAME + '/unauthenticate', {})
  }
}

import Axios from 'axios'
import Constants from '@/helpers/constants'
const RESOURCE_NAME = '/AccessControl'
export default {
  Auth (username, password) {
    var headers = {
      'Content-Type': 'application/json',
      'Authorization': 'JWT fefege...'
    }
    let obj = {
      Login: username,
      Password: password,
      ApplicationType: Constants.ApplicationType
    }
    var t = JSON.stringify(obj)
    return Axios.post(RESOURCE_NAME + '/authenticate', t, headers)
  }
}

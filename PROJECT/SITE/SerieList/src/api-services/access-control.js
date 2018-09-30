import Axios from 'axios'
const RESOURCE_NAME = '/AccessControl'
export default {
  Auth (credentials) {
    return Axios.post(RESOURCE_NAME + '/authenticate', credentials)
  }
}

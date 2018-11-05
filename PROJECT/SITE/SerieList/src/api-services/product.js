import qs from 'qs'
import Axios from 'axios'
const RESOURCE_NAME = '/product'
export default {
  search (params) {
    return Axios.post(RESOURCE_NAME + '/search', qs.stringify(params))
  },
  get (id) {
    return Axios.get(RESOURCE_NAME + '/' + id)
  },
  add (data) {
    return Axios.post(RESOURCE_NAME, qs.stringify(data))
  }
}

import Axios from 'axios'
const RESOURCE_NAME = '/productStatus'
export default {
  search () {
    return Axios.post(RESOURCE_NAME + '/search')
  },
  get (id) {
    return Axios.get(RESOURCE_NAME + '/' + id)
      .then((response) => {
        console.log(response.data.Success)
        console.log(response.data)
      }).catch((error) => {
        console.log(error.response.data)
      })
  }
//   create (data) { return Axios.post(RESOURCE_NAME, data) },
//   update (id, data) { return Axios.put(RESOURCE_NAME/id, data) },
//   delete (id) { return Axios.delete(RESOURCE_NAME/id) }
}

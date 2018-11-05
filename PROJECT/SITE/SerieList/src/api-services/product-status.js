import Axios from 'axios'
import store from '@/store/store'
import StoreGeneralConstants from '@/store/constants/general'
import StoreProductStatusConstants from '@/store/constants/product-status'
import NotificationMessages from '@/helpers/notification-messages'
import qs from 'qs'

const RESOURCE_NAME = '/productStatus'
export default {
  search (params) {
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, true)
    Axios.post(RESOURCE_NAME + '/search', qs.stringify(params))
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, false)
        if (data.Success === true) {
          store.dispatch(StoreProductStatusConstants.ACTIONS.ADD_RESULT, data.ResultPaged)
        } else {
          window.Toast.error({
            title: data.Method,
            message: data.Exception.ErrorMessage
          })
        }
      }).catch(error => {
        console.log(error)
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, false)
        window.Toast.error(NotificationMessages.Error())
      })
  },
  get (id) {
    return Axios.get(RESOURCE_NAME + '/' + id)
  }
}

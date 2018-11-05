import Axios from 'axios'
import store from '@/store/store'
import StoreGeneralConstants from '@/store/constants/general'
import StoreVisibilityConstants from '@/store/constants/visibility'
import NotificationMessages from '@/helpers/notification-messages'
import qs from 'qs'

const RESOURCE_NAME = '/visibility'
export default {
  search (params, showLoader) {
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, true)
    Axios.post(RESOURCE_NAME + '/search', qs.stringify(params))
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, false)
        if (data.Success === true) {
          store.dispatch(StoreVisibilityConstants.ACTIONS.ADD_RESULT, data.ResultPaged)
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
  }
}

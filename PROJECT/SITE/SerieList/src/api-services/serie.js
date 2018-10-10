import store from '@/store/store'
// import Constants from '@/helpers/constants'
import StoreGeneralConstants from '@/store/constants/general'
import StoreSerieConstants from '@/store/constants/serie'
import NotificationMessages from '@/helpers/notification-messages'
// import router from '@/router'
import ProductService from '@/api-services/product'
export default {
  search () {
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, true)
    ProductService.search()
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_CIRCULAR, false)
        if (data.Success === true) {
          store.dispatch(StoreSerieConstants.ACTIONS.ADD_RESULT, data.ResultPaged)
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

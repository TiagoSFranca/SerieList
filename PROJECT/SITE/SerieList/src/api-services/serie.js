import store from '@/store/store'
import Constants from '@/helpers/constants'
import StoreGeneralConstants from '@/store/constants/general'
import StoreSerieConstants from '@/store/constants/serie'
import NotificationMessages from '@/helpers/notification-messages'
import ProductService from '@/api-services/product'
import router from '@/router'

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
  },
  add (data) {
    let obj = {
      IdProductStatus: data.IdProductStatus,
      IdProductType: Constants.ProductType.Serie,
      IdVisibility: data.IdVisibility,
      Title: data.Title,
      Description: data.Description,
      BeginAt: data.BeginAt,
      EndAt: data.EndAt
    }
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, true)
    ProductService.add(obj)
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
        if (data.Success === true) {
          window.Toast.success({
            title: data.Method,
            message: data.Message
          })
          router.push({name: 'serie.add'})
        } else {
          window.Toast.error({
            title: data.Method,
            message: data.Exception.ErrorMessage
          })
        }
      }).catch(error => {
        console.log(error)
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
        window.Toast.error(NotificationMessages.Error())
      })
  }
}

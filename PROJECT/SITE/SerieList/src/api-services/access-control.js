import qs from 'qs'
import Axios from 'axios'
import store from '@/store/store'
import Constants from '@/helpers/constants'
import StoreGeneralConstants from '@/store/constants/general'
import StoreAuthConstants from '@/store/constants/auth'
import NotificationMessages from '@/helpers/notification-messages'
import router from '@/router'

const RESOURCE_NAME = '/AccessControl'

export default {
  Auth (username, password) {
    let obj = {
      Login: username,
      Password: password,
      ApplicationType: Constants.ApplicationType
    }
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, true)
    Axios.post(RESOURCE_NAME + '/authenticate', qs.stringify(obj))
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, false)
        if (data.Success === true) {
          store.dispatch(StoreAuthConstants.ACTIONS.SET_TOKEN, data.Result)
          window.Toast.success({
            title: data.Method,
            message: data.Message
          })
          router.push('Home')
        } else {
          window.Toast.error({
            title: data.Method,
            message: data.Exception.ErrorMessage
          })
        }
      }).catch(error => {
        console.log(error)
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, false)
        window.Toast.error(NotificationMessages.Error())
      })
  },
  Unauth () {
    let token = store.getters[StoreAuthConstants.GETTERS.TOKEN]
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, true)
    console.log(token)
    Axios.post(RESOURCE_NAME + '/unauthenticate', {token})
      .then((response) => {
        var data = response.data
        console.log(data)
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, false)
        if (data.Success === true) {
          store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
          window.Toast.success({
            title: data.Method,
            message: data.Message
          })
          router.push('Home')
        } else {
          window.Toast.error({
            title: data.Method,
            message: data.Exception.ErrorMessage
          })
        }
      }).catch(error => {
        console.log(error)
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_LOADER, false)
        window.Toast.error(NotificationMessages.Error())
      })
  },
  CheckToken () {
    console.log('CHECAR TOKEN')
  }
}

import qs from 'qs'
import Axios from 'axios'
import store from '@/store/store'
import Constants from '@/helpers/constants'
import StoreGeneralConstants from '@/store/constants/general'
import StoreAuthConstants from '@/store/constants/auth'
import NotificationMessages from '@/helpers/notification-messages'

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
        console.log(data)
        if (data.Success === true) {
          store.dispatch(StoreAuthConstants.ACTIONS.SET_TOKEN, data.Result)
          window.Toast.success({
            title: data.Method,
            message: data.Message
          })
          // this.$router.push('Home')
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
    return Axios.post(RESOURCE_NAME + '/unauthenticate', {})
  }
}

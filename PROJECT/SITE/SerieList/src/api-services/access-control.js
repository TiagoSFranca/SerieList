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
  Auth (username, password, keep) {
    let obj = {
      Login: username,
      Password: password,
      KeepConnected: keep,
      ApplicationType: Constants.ApplicationType
    }
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, true)
    Axios.post(RESOURCE_NAME + '/authenticate', qs.stringify(obj))
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
        if (data.Success === true) {
          console.log(data)
          store.dispatch(StoreAuthConstants.ACTIONS.SET_TOKEN, {Token: data.Result.Token, User: data.Result.User})
          window.Toast.success({
            title: data.Method,
            message: data.Message
          })
          router.push({name: 'home.index'})
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
  },
  Unauth () {
    store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, true)
    Axios.post(RESOURCE_NAME + '/unauthenticate', {})
      .then((response) => {
        var data = response.data
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
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
        store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
        store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
        window.Toast.error(NotificationMessages.Error())
      })
  },
  CheckIsGuest (from, next) {
    if (store.getters[StoreAuthConstants.GETTERS.IS_AUTH] === false) {
      store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, true)
      Axios.post(RESOURCE_NAME + '/validtoken', {})
        .then((response) => {
          store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
          var data = response.data
          if (data.Success === true) {
            if (data.Result.Valid === false) {
              store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
              next()
            }
          } else {
            let redirect = from.name
            if (!redirect) {
              redirect = 'home.index'
            }
            return router.push({name: redirect})
          }
        }).catch(error => {
          console.log(error)
          store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
          store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
          next()
        })
    } else {
      let redirect = from.name
      if (!redirect) {
        redirect = 'home.index'
      }
      return router.push({name: redirect})
    }
  },
  CheckIsAuth (next) {
    let redirect = 'account.login'
    if (store.getters[StoreAuthConstants.GETTERS.IS_AUTH] === true) {
      store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, true)
      Axios.post(RESOURCE_NAME + '/validtoken', {})
        .then((response) => {
          store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
          var data = response.data
          if (data.Success === true && data.Result.Valid === true) {
            next()
          } else {
            store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
            return router.push({name: redirect})
          }
        }).catch(error => {
          console.log(error)
          store.dispatch(StoreGeneralConstants.ACTIONS.CHANGE_SHOW_PROGRESS_BAR, false)
          store.dispatch(StoreAuthConstants.ACTIONS.REMOVE_TOKEN)
          return router.push({name: redirect})
        })
    } else {
      return router.push({name: redirect})
    }
  }
}

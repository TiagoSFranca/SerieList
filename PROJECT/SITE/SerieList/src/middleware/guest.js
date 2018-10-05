import store from '@/store/store'
import StoreAuthConstants from '@/store/constants/auth'
import AccessControlService from '@/api-services/access-control'
export default function guest ({from, next, router, to}) {
  AccessControlService.CheckToken()
  if (store.getters[StoreAuthConstants.GETTERS.IS_AUTH] === false) {
    next()
  } else {
    let redirect = from.name
    if (!redirect) {
      redirect = 'home.index'
    }
    return router.push({name: redirect})
  }
}

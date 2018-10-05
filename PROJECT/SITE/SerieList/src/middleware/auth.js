import store from '@/store/store'
import StoreAuthConstants from '@/store/constants/auth'
import AccessControlService from '@/api-services/access-control'
export default function auth ({next, router}) {
  AccessControlService.CheckToken()
  if (store.getters[StoreAuthConstants.GETTERS.IS_AUTH]) {
    next()
  } else {
    return router.push({name: 'account.login'})
  }
}

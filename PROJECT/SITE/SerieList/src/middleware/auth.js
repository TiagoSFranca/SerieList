import store from '@/store/store'
export default function auth ({next, router}) {
  console.log('afs')
  console.log(store.getters.getToken)
  console.log(store.getters.pageTitle)
  // if (!AuthHelper.getToken()) {
  //   return router.push({name: AuthHelper.constants.loginPage})
  // }
  // return next()
}

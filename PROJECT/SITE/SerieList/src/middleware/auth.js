import AuthHelper from '@/helpers/auth'
export default function auth ({next, router}) {
  if (!AuthHelper.getToken()) {
    return router.push({name: AuthHelper.constants.loginPage})
  }
  return next()
}

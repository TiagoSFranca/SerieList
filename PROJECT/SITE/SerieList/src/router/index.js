import Vue from 'vue'
import Router from 'vue-router'
import guest from '@/middleware/guest'
import HomeIndex from '@/components/Home/Index'
import Login from '@/components/Account/Login'
import serieRouter from '@/router/serie-router'

Vue.use(Router)

const baseRoutes = [
  {
    path: '/',
    name: 'home.index',
    component: HomeIndex,
    meta: {
      title: 'Início'
    }
  },
  {
    path: '/Login',
    name: 'account.login',
    component: Login,
    meta: {
      title: 'Entrar',
      middleware: guest
    }
  }
]

let routes = baseRoutes.concat(serieRouter)

const router = new Router({
  routes
})

function nextFactory (context, middleware, index) {
  const subsequentMiddleware = middleware[index]
  if (!subsequentMiddleware) return context.next

  return (...parameters) => {
    context.next(...parameters)
    const nextMiddleware = nextFactory(context, middleware, index + 1)
    subsequentMiddleware({ ...context, next: nextMiddleware })
  }
}

router.beforeEach((to, from, next) => {
  document.title = to.meta.title + ' - SerieList'
  next()
  if (to.meta.middleware) {
    const middleware = Array.isArray(to.meta.middleware)
      ? to.meta.middleware
      : [to.meta.middleware]

    const context = {
      from,
      next,
      router,
      to
    }
    const nextMiddleware = nextFactory(context, middleware, 1)

    return middleware[0]({ ...context, next: nextMiddleware })
  }

  return next()
})

export default router

import Vue from 'vue'
import Router from 'vue-router'
import auth from '@/middleware/auth'
import guest from '@/middleware/guest'
import HomeIndex from '@/components/Home/Index'
import ProductIndex from '@/components/Product/Index'
import Login from '@/components/Account/Login'

Vue.use(Router)

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'home.index',
      component: HomeIndex,
      meta: {
        title: 'Início'
      }
    },
    {
      path: '/Product',
      name: 'product.index',
      component: ProductIndex,
      meta: {
        title: 'Produtos',
        middleware: auth
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

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
      path: '/Home',
      name: 'HomeIndex',
      component: HomeIndex
    },
    {
      path: '/Product',
      name: 'ProductIndex',
      component: ProductIndex,
      meta: {
        middleware: auth
      }
    },
    {
      path: '/ProductStatus',
      redirect: 'http://localhost:2055/api/productstatus/search',
      name: 'ProductStatus'
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login,
      meta: {
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

import Vue from 'vue'
import Router from 'vue-router'
import HomeIndex from '@/components/Home/Index'
import ProductIndex from '@/components/Product/Index'
import Login from '@/components/Account/Login'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Home',
      name: 'HomeIndex',
      component: HomeIndex
    },
    {
      path: '/Product',
      name: 'ProductIndex',
      component: ProductIndex
    },
    {
      path: '/ProductStatus',
      redirect: 'http://localhost:2055/api/productstatus/search',
      name: 'ProductStatus'
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login
    }
  ]
})

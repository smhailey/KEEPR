import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Keep from './components/Keep.vue'
// @ts-ignore
import Vault from './components/Vault.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/keep/:keepId',
      name: 'keep',
      props: true,
      component: Keep
    },
    {
      path: '/vault/:vaultId',
      name: 'vault',
      props: true,
      component: Vault
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})

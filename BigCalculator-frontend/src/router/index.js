import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/basic',
    name: 'basic',
    component: () => import('../views/BasicCalculator.vue')
  },
  {
    path: '/expression',
    name: 'expression',
    component: () => import('../views/ExpressionCalculator.vue')
  },
  {
    path: '/import',
    name: 'import',
    component: () => import('../views/ImportCalculator.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router

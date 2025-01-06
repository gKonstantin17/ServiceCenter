import { createRouter, createWebHistory } from 'vue-router'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: () => import('@/views/HomeView.vue')
    },
    {
      path: '/shop',
      name: 'Shop',
      component: () => import('@/views/ShopView.vue')
    },
    {
      path: '/authorization',
      name: 'Authorization',
      component: () => import('@/views/AuthorizationView.vue')
    },
    {
      path: '/registration',
      name: 'Registration',
      component: () => import('@/views/RegistrationView.vue')
    },
    {
      path: '/lk',
      name: 'Lk',
      component: () => import('@/views/LkView.vue')
    }
  ]
})

export default router

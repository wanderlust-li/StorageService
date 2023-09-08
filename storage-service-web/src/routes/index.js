
import { createRouter, createWebHistory} from 'vue-router'

const routes = [
    {
        path: '/',
        component: ()=> import('../pages/HomePage.vue'),
    },
    {
        path: '/announcement/:id',
        component: () => import('../pages/AnnouncementPage.vue')
    },

]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
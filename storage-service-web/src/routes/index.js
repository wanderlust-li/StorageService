
import { createRouter, createWebHistory} from 'vue-router'

const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: ()=> import('../pages/HomePage.vue'),
    },
    {
        path: '/announcement/:id',
        name: 'AnnouncementPage',
        component: () => import('../pages/AnnouncementPage.vue')
    },
    {
        path: '/create-announcement',
        name: 'CreateAnnouncementPage',
        component: () => import('../pages/CreateAnnouncementPage.vue')
    }
]


const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
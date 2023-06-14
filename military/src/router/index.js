import { createRouter, createWebHistory } from "vue-router";
import HomeView from '../views/HomeView.vue';
import SoldierView from '../views/SoldierView.vue';
import WeaponView from '../views/WeaponView.vue';
import AdminView from '../views/AdminView.vue';
import EditSoldier from '../components/admin/EditSoldier.vue'
import EditWeapon from '../components/admin/EditWeapon.vue'

const routes = [
    {
        path: '/',
        name: 'home',
        component: HomeView
    },
    {
        path: '/soldier',
        name: 'soldier',
        component: SoldierView
    },
    {
        path: '/weapon',
        name:'weapon',
        component: WeaponView
    },
    {
        path: '/admin',
        name: 'admin',
        component: AdminView   
    },
    {
        path: '/edit-soldier',
        name:'editSoldier',
        component: EditSoldier
    },
    {
        path: '/edit-weapon',
        name: 'editWeapon',
        component: EditWeapon
    }
];

const router = createRouter(
    {
        history:createWebHistory(),
        routes
    }
)

export default router
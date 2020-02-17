import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home'
import Order from "./views/Order";

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/order',
            name: 'order',
            component: Order
        }
    ]
})

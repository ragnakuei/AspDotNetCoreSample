import Vue from 'vue'
import App from './App.vue'
import router from './router'

Vue.config.productionTip = false;

// Vue Material
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default-dark.css'
Vue.use(VueMaterial);

const linkActiveClass = 'my-link-active-class';
Vue.material.router.linkActiveClass = linkActiveClass;

new Vue({
  router,
  linkActiveClass,         // Vue Material,
  render: h => h(App)
}).$mount('#app');

// import './assets/main.css'
import { createApp } from 'vue'
import App from './App.vue'

import axios from 'axios'
import VueAxios from "vue-axios";

// axios.defaults.baseURL = 'http://localhost:5120/api/';
axios.defaults.baseURL = 'https://www.fernando.somee.com/api/';

createApp(App).mount('#app')


const app = createApp(App);
app.use(VueAxios, axios);
import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import VueAxios from "vue-axios";

import categoryState from "./category";
import productsState from "./products";
import productState from "./product";
import userState from "./user";
import cartState from "./cart";
import cartHistoryState from "./cartHistory";

Vue.use(Vuex);
Vue.use(VueAxios, axios);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    categoryState,
    productsState,
    productState,
    userState,
    cartState,
    cartHistoryState,
  },
});

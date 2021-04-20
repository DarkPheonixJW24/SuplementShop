import axios from "axios";

const BASE_URL =
  "https://0i691shtxb.execute-api.us-east-1.amazonaws.com/prod/api";

export default {
  state: () => ({
    products: [],
    loading: true,
    error: undefined,
    category: undefined,
    mannufacturer: undefined,
    searchTerm: undefined,
  }),
  mutations: {
    SET_PRODUCTS_LOADING(state) {
      state.products = [];
      state.loading = false;
      state.error = undefined;
      state.category = undefined;
      state.mannufacturer = undefined;
      state.searchTerm = undefined;
    },
    SET_PRODUCTS(state, { products, category, searchTerm, mannufacturer }) {
      state.products = products;
      state.loading = false;
      state.error = undefined;
      state.category = category;
      state.searchTerm = searchTerm;
      state.mannufacturer = mannufacturer;
    },
    SET_PRODUCTS_ERROR(state, error) {
      state.error = error;
      state.products = [];
      state.loading = false;
      state.category = undefined;
      state.mannufacturer = undefined;
      state.searchTerm = undefined;
    },
  },
  actions: {
    loadProducts({ commit, state }, category) {
      if (state.category !== category) {
        commit("SET_PRODUCTS_LOADING");
        axios
          .get(`${BASE_URL}/category/${category}`)
          .then((r) => r.data)
          .then((products) => commit("SET_PRODUCTS", { products, category }))
          .catch((error) => commit("SET_PRODUCTS_ERROR", error));
      }
    },
    loadProductsByMannufacturer({ commit, state }, mannufacturer) {
      if (state.mannufacturer !== mannufacturer) {
        commit("SET_PRODUCTS_LOADING");
        axios
          .get(`${BASE_URL}/product/mannufacturer/${mannufacturer}`)
          .then((r) => r.data)
          .then((products) =>
            commit("SET_PRODUCTS", { products, mannufacturer })
          )
          .catch((error) => commit("SET_PRODUCTS_ERROR", error));
      }
    },
    searchProducts({ commit, state }, searchTerm) {
      if (state.searchTerm !== searchTerm) {
        commit("SET_PRODUCTS_LOADING");
        axios
          .get(`${BASE_URL}/product/search/${searchTerm}`)
          .then((r) => r.data)
          .then((products) => commit("SET_PRODUCTS", { products, searchTerm }))
          .catch((error) => commit("SET_PRODUCTS_ERROR", error));
      }
    },
  },
  getters: {},
};

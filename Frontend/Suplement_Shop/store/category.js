import axios from "axios";

const BASE_URL =
  "https://0i691shtxb.execute-api.us-east-1.amazonaws.com/prod/api";

export default {
  state: () => ({
    categories: [],
    loading: true,
    error: undefined,
  }),
  mutations: {
    SET_CATEGORIES_LOADING(state) {
      state.categories = [];
      state.loading = true;
      state.error = undefined;
    },
    SET_CATEGORIES(state, categories) {
      state.categories = categories;
      state.loading = false;
      state.error = undefined;
    },
    SET_CATEGORIES_ERROR(state, error) {
      state.error = error;
      state.categories = [];
      state.loading = false;
    },
  },
  actions: {
    loadCategories({ commit }) {
      commit("SET_CATEGORIES_LOADING");
      axios
        .get(`${BASE_URL}/category`)
        .then((r) => r.data)
        .then((categories) => commit("SET_CATEGORIES", categories))
        .catch((error) => commit("SET_CATEGORIES_ERROR", error));
    },
  },
  getters: {},
};

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
      this.$axios
        .get(`category`)
        .then((r) => r.data)
        .then((categories) => commit("SET_CATEGORIES", categories))
        .catch((error) => commit("SET_CATEGORIES_ERROR", error));
    },
  },
  getters: {},
};

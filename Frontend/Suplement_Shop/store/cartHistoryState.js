export default {
  state: () => ({
    carts: [],
    loading: true,
    error: undefined
  }),
  mutations: {
    SET_CARTS_LOADING(state) {
      state.carts = [];
      state.loading = true;
      state.error = undefined;
    },
    SET_CARTS(state, carts) {
      state.carts = carts;
      state.loading = false;
      state.error = undefined;
    },
    SET_CARTS_ERROR(state, error) {
      state.carts = [];
      state.loading = false;
      state.error = error;
    }
  },
  actions: {
    loadCartHistory({ commit }) {
      commit("SET_CARTS_LOADING");
      this.$axios
        .get(`cart/list`)
        .then(r => r.data)
        .then(carts => commit("SET_CARTS", carts))
        .catch(error => commit("SET_CART_ERRORS", error));
    }
  },
  getters: {}
};

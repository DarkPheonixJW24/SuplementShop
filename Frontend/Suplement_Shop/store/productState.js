export default {
  state: () => ({
    product: undefined,
    loading: true,
    error: undefined,
  }),
  mutations: {
    SET_PRODUCT_LOADING(state) {
      state.loading = true;
      state.product = undefined;
      state.error = undefined;
    },
    SET_PRODUCT_STATE(state, product) {
      state.loading = false;
      state.product = product;
      state.error = undefined;
    },
    SET_PROUDCT_ERROR(state, error) {
      state.loading = false;
      state.product = undefined;
      state.error = error;
    },
  },
  actions: {
    loadProduct({ commit, rootState }, productId) {
      const maybeProduct = rootState.productsState.products.find(
        (el) => el.id === productId
      );
      if (maybeProduct) {
        commit("SET_PRODUCT_STATE", maybeProduct);
        return;
      }
      this.$axios
        .get(`product/${productId}`)
        .then((r) => r.data)
        .then((product) => commit("SET_PRODUCT_STATE", product))
        .catch((error) => commit("SET_PRODUCT_ERROR", error));
    },
  },
  getters: {},
};

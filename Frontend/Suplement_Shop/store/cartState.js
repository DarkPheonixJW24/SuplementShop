export default {
  state: () => ({
    cart: undefined,
    loading: true,
    error: undefined
  }),
  mutations: {
    SET_CART_LOADING(state) {
      state.loading = true;
      state.error = undefined;
    },
    SET_CART(state, cart) {
      state.cart = cart;
      state.loading = false;
      state.error = undefined;
    },
    SET_CART_ERROR(state, error) {
      state.loading = false;
      state.error = error;
    }
  },
  actions: {
    loadCart({ commit }) {
      commit("SET_CART_LOADING");
      this.$axios
        .get(`cart/user`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    buyCart({ commit }, { cartId }) {
      commit("SET_CART_LOADING");
      this.$axios
        .get(`cart/buy/${cartId}`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    clearCart({ commit }, { cartId }) {
      commit("SET_CART_LOADING");
      this.$axios
        .get(`cart/clear/${cartId}`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    addCartItem({ commit }, { cartId, cartItem }) {
      commit("SET_CART_LOADING");
      this.$axios
        .post(`cart/cartItem/${cartId}`, cartItem)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    removeCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      this.$axios
        .delete(`cart/cartItem/${cartId}/${productId}`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    incrementCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      this.$axios
        .get(`cart/increment/${cartId}/${productId}`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    },
    decrementCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      this.$axios
        .get(`cart/decrement/${cartId}/${productId}`)
        .then(r => r.data)
        .then(cart => commit("SET_CART", cart))
        .catch(error => commit("SET_CART_ERROR", error));
    }
  },
  getters: {}
};

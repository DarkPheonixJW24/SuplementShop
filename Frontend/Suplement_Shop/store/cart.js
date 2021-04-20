import axios from "axios";

const BASE_URL =
  "https://0i691shtxb.execute-api.us-east-1.amazonaws.com/prod/api";

export default {
  state: () => ({
    cart: undefined,
    loading: true,
    error: undefined,
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
    },
  },
  actions: {
    loadCart({ commit }, { userId }) {
      commit("SET_CART_LOADING");
      axios
        .get(`${BASE_URL}/cart/user/${userId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    buyCart({ commit }, { cartId, userId }) {
      commit("SET_CART_LOADING");
      axios
        .get(`${BASE_URL}/cart/buy/${cartId}/${userId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    clearCart({ commit }, { cartId }) {
      commit("SET_CART_LOADING");
      axios
        .get(`${BASE_URL}/cart/clear/${cartId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    addCartItem({ commit }, { cartId, cartItem }) {
      commit("SET_CART_LOADING");
      axios
        .post(`${BASE_URL}/cart/cartItem/${cartId}`, cartItem)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    removeCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      axios
        .delete(`${BASE_URL}/cart/cartItem/${cartId}/${productId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    incrementCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      axios
        .get(`${BASE_URL}/cart/increment/${cartId}/${productId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
    decrementCartItem({ commit }, { cartId, productId }) {
      commit("SET_CART_LOADING");
      axios
        .get(`${BASE_URL}/cart/decrement/${cartId}/${productId}`)
        .then((r) => r.data)
        .then((cart) => commit("SET_CART", cart))
        .catch((error) => commit("SET_CART_ERROR", error));
    },
  },
  getters: {},
};

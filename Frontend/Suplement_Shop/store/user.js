import axios from "axios";

const BASE_URL =
  "https://0i691shtxb.execute-api.us-east-1.amazonaws.com/prod/api";

export default {
  state: () => ({
    user: undefined,
    loading: true,
    error: undefined,
  }),
  mutations: {
    SET_USER_LOADING(state) {
      state.user = undefined;
      state.loading = true;
      state.error = undefined;
    },
    SET_USER(state, user) {
      state.user = user;
      state.loading = false;
      state.error = undefined;
    },
    SET_USER_ERROR(state, error) {
      state.user = undefined;
      state.error = error;
      state.loading = false;
    },
  },
  actions: {
    logIn({ commit, dispatch }, { email, password }) {
      commit("SET_USER_LOADING");
      axios
        .post(`${BASE_URL}/user/log-in`, { email, password })
        .then((r) => r.data)
        .then((user) => {
          commit("SET_USER", user);
          dispatch("loadCart", { userId: user.id });
        })
        .catch((error) => commit("SET_USER_ERROR", error));
    },
    register({ commit }, { email, password, fullName }) {
      commit("SET_USER_LOADING");
      axios
        .post(`${BASE_URL}/user/register`, { email, password, fullName })
        .then((r) => r.data)
        .then((user) => {
          commit("SET_USER", user);
          dispatch("loadCart", { userId: user.id });
        })
        .catch((error) => commit("SET_USER_ERROR", error));
    },
    logOut({ commit }) {
      commit("SET_USER", undefined);
    },
  },
  getters: {},
};

export default {
  state: () => ({
    id: undefined,
    fullName: undefined,
    email: undefined,
    token: undefined,
    loading: true,
    error: undefined
  }),
  mutations: {
    SET_USER_LOADING(state) {
      state.id = undefined;
      state.fullName = undefined;
      state.email = undefined;
      state.token = undefined;
      state.loading = true;
      state.error = undefined;
    },
    SET_USER(state, response) {
      state.id = response.id;
      state.fullName = response.fullName;
      state.email = response.email;
      state.token = response.token;
      state.loading = false;
      state.error = undefined;
    },
    SET_USER_ERROR(state, error) {
      state.id = undefined;
      state.fullName = undefined;
      state.email = undefined;
      state.token = undefined;
      state.error = error;
      state.loading = false;
    }
  },
  actions: {
    logIn({ commit, dispatch }, { email, password }) {
      commit("SET_USER_LOADING");
      this.$axios
        .post(`user/log-in`, { email, password })
        .then(r => r.data)
        .then(response => {
          commit("SET_USER", response);
          setTimeout(() =>
            dispatch("cartState/loadCart", '', { root: true }), 0
          )
          this.$router.push({
            path: "/",
          });
        })
        .catch(error => commit("SET_USER_ERROR", error));
    },
    register({ commit, dispatch }, { email, password, fullName }) {
      commit("SET_USER_LOADING");
      this.$axios
        .post(`user/sign-up`, { email, password, fullName })
        .then(r => r.data)
        .then(user => {
          dispatch("logIn", { email, password });
        })
        .catch(error => commit("SET_USER_ERROR", error));
    },
    logOut({ commit }) {
      commit("SET_USER", {});
    }
  },
  getters: {}
};

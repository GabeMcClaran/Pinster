import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    activeUser: {},
    publicKeeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {}
  },
  mutations: {
    // setActiveUser(state, data) {
    //   state.activeUser = data;
    // },
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = publicKeeps;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    }
  },
  actions: {
    //#region -- Auth --
    setBearer({ commit }, bearer) {
      api.defaults.headers.authorization = bearer;
      // commit("setActiveUser", bearer);
      console.log(authorization);
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    //#endregion

    //#region --Keeps --
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
      console.log("here", res.data);
    },

    async changeKeepVault({ commit, dispatch }, data) {
      console.log("WHAT is DATA", data);
      let res = await api.post("vaultkeeps", data);
      console.log(res);
    },
    //#endregion

    //#region

    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setVaults", res.data);
      console.log("vaults", res.data);
    },

    async deleteVault({ commit, dispatch }, vault) {
      let res = await api.delete("vaults/" + vault.id);
      dispatch("getVaults");
      console.log(vault);
    }
    //#endregion
  }
});

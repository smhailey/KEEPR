import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    userKeeps: [],
    publicKeeps: [],
    activeKeep: {},
    userVaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setUserVaults(state, data) {
      state.userVaults = data
    },
    setActiveVault(state, data) {
      state.activeVault = data
    },
    setUserVaultKeeps(state, data) {
      state.vaultKeeps = data
    },
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    //#region -- Keeps --
    getAllPublicKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setPublicKeeps', res.data)
        })
    },
    getOneKeepById({ commit, dispatch }, keepId) {
      api.get('keeps/' + keepId)
        .then(res => {
          commit('setActiveKeep', res.data)
        })
    },
    getAllKeepsByUserId({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          commit('setUserKeeps', res.data)
        })
    },
    createKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
        .then(res => {
          dispatch('getAllKeepsByUserId')
        })
    },
    deleteKeepById({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch('getAllKeepsByUserId')
        })
    },
    //#endregion

    //#region -- Vaults --
    getOneVaultById({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          commit('setActiveVault', res.data)
        })
    },
    getAllVaultsByUserId({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setUserVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          dispatch('getAllVaultsByUserId')
        })
    },
    deleteVaultById({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getAllVaultsByUserId')
        })
    },
    //#endregion

    //#region -- VaultKeeps --
    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get('vaultkeeps/' + vaultId)
        .then(res => {
          commit('setUserVaultKeeps', res.data)
        })
    },
    addKeepToVault({ commit, dispatch }, newVaultKeep) {
      api.post('vaultkeeps', newVaultKeep)
        .then(res => {
          dispatch('getAllVaultsByUserId')
        })
    },

    //#endregion
  }
})

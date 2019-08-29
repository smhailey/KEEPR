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
    activeKeep: [],
    vaults: [],
    activeVault: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    userKeeps(state, data) {
      state.userKeeps = data
    },
    publicKeeps(state, data) {
      state.publicKeeps = data
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setVaults(state, data) {
      state.vaults = data
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
          commit('publicKeeps', res.data)
        })
    },
    getOneKeepById({ commit, dispatch }) {
      api.get('keeps/' + keepID)
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getAllKeepsByUserId({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          commit('userKeeps', res.data)
        })
    },
    createKeep({ commit, dispatch }, keepData) {
      api.post('keeps', keepData)
        .then(res => {
          dispatch('getKeeps')  //FIXME need to GetAllPublicKeeps & GetAllKeepsByUserId
        })
    },
    deleteKeepById({ commit, dispatch }, keepId) {
      api.put('keeps/' + keepId)
        .then(res => {
          dispatch('getKeeps')  //FIXME need to GetAllPublicKeeps & GetAllKeepsByUserId
          router.push({ name: 'keeps' })
        })
    },
    //#endregion

    //#region -- Vaults --
    GetOneVaultById({ commit, dispatch }) {
      api.get('vaults/' + vaultID)
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    GetAllVaultsByUserId({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setUserVaults', res.data)
        })
    },
    CreateVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          dispatch('getVaults')  //FIXME need to GetAllPublicVaultss & GetAllVaultsByUserId
        })
    },
    DeleteVaultById({ commit, dispatch }, payload) {
      api.put('vaults/' + payload)
        .then(res => {
          dispatch('getVaults')  //FIXME need to GetAllPublicVaults & GetAllVaultsByUserId
          router.push({ name: 'vaults' })
        })
    },
    //#endregion





  }
})

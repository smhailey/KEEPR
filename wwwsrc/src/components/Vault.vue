<template>
  <div class="vault">
    <button class="btn btn-sm btn-outline-danger m-2" @click="logout">Logout</button>
    <br>
    <h1>Vault Name: {{activeVault.name}}</h1>
    <h5>Vault Description: {{activeVault.description}}</h5>


    <div class="row justify-content-center">
      <h3>Your Keeps</h3>
    </div>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="userVaultKeep in userVaultKeeps" :key="userVaultKeep.id">
        <!-- <router-link :to="{name: 'vaultKeep', params: {keepId: userVaultKeep.id}}">{{userVaultKeep.name}}</router-link> -->
        <h5>{{userVaultKeep.name}}</h5>
        <p>{{userVaultKeep.description}}</p>
        <img :src="userVaultKeep.img" class="img-fluid" alt="image">
        <!-- <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteKeep(userKeep.id)">Delete keep</button> -->
      </div>
    </div>



  </div>
</template>

<script>
  export default {
    name: 'vault',
    props: ['vaultId'],
    mounted() {
      this.$store.dispatch("getOneVaultById", this.vaultId);
      // get all vaultkeeps by vaultid
      this.$store.dispatch("getAllVaultsByUserId");
    },
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      userKeeps() {
        return this.$store.state.userKeeps;
      },
      publicKeeps() {
        return this.$store.state.publicKeeps;
      },
      userVaults() {
        return this.$store.state.userVaults;
      },
      activeVault() {
        return this.$store.state.activeVault;
      },
      userVaultKeeps() {
        return this.$store.state.userVaultKeeps;
      }
    },
    methods: {
      getKeepsByVaultId(vaultId) {
        this.$store.dispatch("GetKeepsByVaultId", this.vaultId);
      },
      logout() {
        this.$store.dispatch("logout");
      }
    }
  }
</script>

<style scoped>
</style>
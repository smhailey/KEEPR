<template>
  <div class="vault">
    <button class="btn btn-sm btn-outline-danger m-2" @click="logout">Logout</button>
    <br>
    <h1>Vault Name: {{activeVault.name}}</h1>
    <h5>Vault Description: {{activeVault.description}}</h5>
    <vaultKeeps></vaultKeeps>
  </div>
</template>

<script>
  import vaultKeeps from "../components/VaultKeeps.vue"
  export default {
    name: 'vault',
    props: ['vaultId'],
    mounted() {
      this.$store.dispatch("getOneVaultById", this.vaultId);
      this.$store.dispatch("getKeepsByVaultId", this.vaultId)
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
        this.$store.dispatch("getKeepsByVaultId", this.vaultId);
      },
      logout() {
        this.$store.dispatch("logout");
      }
    }
  }
</script>

<style scoped>
</style>
<template>
  <div class="keep">
    <button class="btn btn-sm btn-outline-danger m-2" @click="logout">Logout</button>
    <br>
    <h1>Keep Name: {{activeKeep.name}}</h1>
    <h5>Keep Description: {{activeKeep.description}}</h5>
    <img :src="activeKeep.img" class="img-fluid" alt="image">

    <form>
      Select a vault to pin the keep to:
      <select v-model="selected">
        <option v-for="userVault in userVaults" :value="userVault.id">{{userVault.name}}</option>
      </select>
    </form>
    <button type="button" @click="addKeepToVault">Pin keep</button>


  </div>
</template>

<script>
  export default {
    name: 'keep',
    props: ['keepId'],
    mounted() {
      this.$store.dispatch("getOneKeepById", this.keepId);
      this.$store.dispatch("getAllVaultsByUserId");
    },
    data() {
      return {
        selected: ""
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
      activeKeep() {
        return this.$store.state.activeKeep;
      }
    },
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault);
        this.newVault = { name: "", description: "" };
        this.$store.dispatch("getAllVaultsByUserId");
      },
      deleteVault(id) {
        this.$store.dispatch('deleteVaultById', id);
      },
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep);
        this.newKeep = { name: "", description: "" };
        this.$store.dispatch("getAllKeepsByUserId");
        this.$store.dispatch("getAllPublicKeeps");
      },
      deleteKeep(id) {
        this.$store.dispatch('deleteKeepById', id);
      },
      addKeepToVault() {

        console.log(this.selected)
        this.newVaultKeep = { keepId: this.keepId, vaultId: this.selected }
        this.$store.dispatch("addKeepToVault", this.newVaultKeep);
      },
      logout() {
        this.$store.dispatch("logout");
      }
    }
  }
</script>

<style scoped>
</style>
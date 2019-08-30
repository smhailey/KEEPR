<template>
  <div class="keep">
    <button class="btn btn-sm btn-outline-danger m-2" @click="logout">Logout</button>
    <br>
    <h1>Keep Name: {{ActiveKeep.name}}</h1>
    <h5>Keep Description: {{ActiveKeep.description}}</h5>
    <img :src="userKeep.img" class="img-fluid" alt="image">


    <!-- drop down on task.vue
          drop to show available lists
          on click update task with new list id
          get all tasksById again -->
    <form>
      Select a vault to pin the keep to:
      <select id="AddKeepToVault">
        <option value=:vaultProp.name v-for="vault in vaults">{{vaultProp.name}}</option>
      </select>
    </form>
    <button type="button" onclick="AddKeepToVault()">Pin keep</button>


  </div>
</template>

<script>
  export default {
    name: 'keep',
    props: ['keepId'],
    mounted() {
      this.$store.dispatch("getOneKeepById", keepId);
      this.$store.dispatch("getAllVaultsByUserId", keepId);
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
      logout() {
        this.$store.dispatch("logout");
      }
    }
  }
</script>

<style scoped>
</style>
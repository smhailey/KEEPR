<template>
  <div>
    <h1>Welcome to your dashboard {{user.username}}</h1>
    <button class="m-1" v-if="user.id" @click="logout">logout</button>
    <router-link class="m-1" :to="{name: 'home'}">Home</router-link>

    <form @submit.prevent="createKeep">
      <input class="m-1" type="text" placeholder="Keep Name" v-model="newKeep.name" required>
      <input class="m-1" type="text" placeholder="Keep Description" v-model="newKeep.description">
      <input class="m-1" type="text" placeholder="Keep Image" v-model="newKeep.img">
      <br>

      <input class="m-1" type="checkbox" id="checkbox" v-model="newKeep.isPrivate">
      <label for="checkbox">Private</label>


      <!-- <input class="m-1" type="radio" id="public" value="0" v-model="newKeep.isPrivate">
      <label for="public">Public</label>
      <input class="m-1" type="radio" id="private" value="1" v-model="newKeep.isPrivate">
      <label for="private">Private</label> -->


      <button class="m-1" type="submit">Create Keep</button>
    </form>

    <form @submit.prevent="createVault">
      <input class="m-1" type="text" placeholder="Vault Name" v-model="newVault.name" required>
      <input class="m-1" type="text" placeholder="Vault Description" v-model="newVault.description">
      <button class="m-1" type="submit">Create Vault</button>
    </form>

    <div class="row justify-content-center">
      <h3>Your Keeps</h3>
    </div>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="userKeep in userKeeps" :key="userKeep.id">
        <router-link :to="{name: 'keep', params: {keepId: userKeep.id}}">{{userKeep.name}}</router-link>
        <!-- <router-link :to="{name: 'board', params: {boardId: board._id}}">{{board.title}}</router-link> -->
        <h5>{{userKeep.name}}</h5>
        <p>{{userKeep.description}}</p>
        <img :src="userKeep.img" class="img-fluid" alt="image">
        <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteKeep(userKeep.id)">Delete
          keep</button>
      </div>
    </div>

    <div class="row justify-content-center">
      <h3>Your Vaults</h3>
    </div>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="userVault in userVaults" :key="userVault.id">
        <h5>{{userVault.name}}</h5>
        <p>{{userVault.description}}</p>
        <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteVault(userVault.id)">Delete
          vault</button>
      </div>
    </div>

    <div class="row justify-content-center">
      <h3>Public Keeps</h3>
    </div>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="publicKeep in publicKeeps" :key="publicKeep.id">
        <h5>{{publicKeep.name}}</h5>
        <p>{{publicKeep.description}}</p>
        <img :src="publicKeep.img" class="img-fluid" alt="image">
      </div>
    </div>

  </div>
</template>

<script>
  import Keep from '../components/Keep.vue'
  export default {
    name: 'Dashboard',
    props: ['vaultProp'],
    mounted() {
      this.$store.dispatch("getAllKeepsByUserId");
      this.$store.dispatch("getAllPublicKeeps");
      this.$store.dispatch("getAllVaultsByUserId", this.vaultProp);
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          isPrivate: 0
        },
        newVault: {
          name: "",
          description: ""
        }
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
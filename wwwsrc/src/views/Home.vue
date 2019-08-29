<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>


    <form @submit.prevent="createKeep">
      <input type="text" placeholder="Keep Name" v-model="newKeep.name" required>
      <input type="text" placeholder="Keep Description" v-model="newKeep.description">
      <!-- <input type="radio" placeholder="Keep Description" v-model="newKeep.description"> -->

      <div class="btn-group btn-group-toggle mx-2" data-toggle="buttons">
        <label class="btn btn-secondary active">
          <input type="radio" name="public" id="public" autocomplete="off" checked v-model="newKeep.isPrivate=false">
          Public
        </label>
        <label class="btn btn-secondary">
          <input type="radio" name="private" id="private" autocomplete="off" v-model="newKeep.isPrivate=true"> Private
        </label>
      </div>

      <button type="submit">Create Keep</button>
    </form>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="userKeep in userKeeps" :key="userKeep._id">
        <router-link :to="{name: 'userKeep', params: {keepId: keep._id}}">{{userKeep.name}}</router-link>
        <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteKeep(keep._id)">Delete
          keep</button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="publicKeep in publicKeeps" :key="publicKeep._id">
        <router-link :to="{name: 'keep', params: {keepId: keep._id}}">{{publicKeep.name}}</router-link>
        <!-- <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteKeep(keep._id)">Delete
          keep</button> -->
      </div>
    </div>


  </div>
</template>


<script>
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getAllKeepsByUserId");
      this.$store.dispatch("getAllPublicKeeps");
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: ""
        }
      };
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      userKeeps() {
        return this.$store.state.keeps;
      },
      publicKeeps() {
        return this.$store.state.keeps;
      }
    },
    methods: {
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep);
        this.newKeep = { name: "", description: "" };
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
      },
      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>
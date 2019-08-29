<template>
  <div>
    <form @submit.prevent="createKeep">
      <input class="m-1" type="text" placeholder="Keep Name" v-model="newKeep.name" required>
      <input class="m-1" type="text" placeholder="Keep Description" v-model="newKeep.description">
      <input class="m-1" type="text" placeholder="Keep Image" v-model="newKeep.img">
      <!-- <input type="radio" placeholder="Keep Description" v-model="newKeep.description"> -->
      <br>
      <input class="m-1" type="radio" id="public" value="0" v-model="newKeep.isPrivate">
      <label for="public">Public</label>
      <input class="m-1" type="radio" id="private" value="1" v-model="newKeep.isPrivate">
      <label for="private">Private</label>
      <button class="m-1" type="submit">Create Keep</button>
    </form>

    <div class="row justify-content-center">
      <h3>Your Keeps</h3>
      <div class="row">
        <div class="card col-3 p-2 m-3" v-for="userKeep in userKeeps" :key="userKeep.id">
          <!-- <router-link :to="{name: 'userKeep', params: {keepId: userKeep.id}}">{{userKeep.name}}</router-link> -->
          <h5>{{userKeep.name}}</h5>
          <p>{{userKeep.description}}</p>
          <img :src="userKeep.img" class="img-fluid" alt="image">
          <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="deleteKeep(userKeep.id)">Delete
            keep</button>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'Dashboard',
    mounted() {
      this.$store.dispatch("getAllKeepsByUserId");
    },
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          isPrivate: 0
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
      }
    },
    methods: {
      createKeep() {
        this.$store.dispatch("createKeep", this.newKeep);
        this.newKeep = { name: "", description: "" };
        this.$store.dispatch("getAllKeepsByUserId")
      },
      deleteKeep(id) {
        this.$store.dispatch('deleteKeepById', id);
      },
    }
  }
</script>

<style scoped>
</style>
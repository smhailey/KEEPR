<template>
  <div class="home container">
    <h1>Welcome Home {{user.username}}</h1>
    <button class="m-1" v-if="user.id" @click="logout">logout</button>
    <router-link class="m-1" v-else :to="{name: 'login'}">Login</router-link>
    <router-link class="m-1" :to="{name: 'dashboard'}">My Dashboard</router-link>

    <div class="row">
      <h3>Public Keeps</h3>
    </div>
    <div class="row">
      <div class="card col-3 p-2 m-3" v-for="publicKeep in publicKeeps" :key="publicKeep.id">
        <!-- <router-link :to="{name: 'keep', params: {keepId: publicKeep.id}}">{{publicKeep.name}}</router-link> -->
        <h5>{{publicKeep.name}}</h5>
        <p>{{publicKeep.description}}</p>
        <img :src="publicKeep.img" class="img-fluid" alt="image">
      </div>
    </div>
  </div>
</template>

<script>
  import Dashboard from '../components/Dashboard.vue'
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getAllPublicKeeps");
    },
    data() {
      return {
      };
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      publicKeeps() {
        return this.$store.state.publicKeeps;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>
<template>
  <div class="vaultKeep">
    <div class="row justify-content-center">
      <div class="card col-3 p-2 m-3" v-for="userVaultKeep in userVaultKeeps" :key="userVaultKeep.id"></div>
      <h4>{{userVaultKeep.name}}</h4>
      <h4>{{userVaultKeep.description}}</h4>
      <img :src="userVaultKeep.img" class="img-fluid" alt="image">
    </div>
    <button type="button" class="mt-auto btn btn-danger btn-sm mb-2" @click="removeFromVault(vaultKeep)">Remove from
      Vault</button>
  </div>
</template>

<script>
  export default {
    name: 'vaultKeep',
    mounted() {
      this.$store.dispatch('getKeepsByVaultId', this.$route.params.Id);
      // this.$store.dispatch('getKeepsByVaultId', this.$route.params.vId)
    },
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },
      vault() {
        return this.$store.state.activeVault
      },
      vaultKeepDatas() {
        return this.$store.state.vaultKeepDatas
      }
    },
    methods: {
      removeFromVault(keep) {
        // debugger
        let vaultKeep = {
          vaultId: this.$route.params.vId,
          keepId: keep.id
        }
        // console.log(vaultKeep)
        this.$store.dispatch("removeFromVault", vaultKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>
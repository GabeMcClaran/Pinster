<template>
  <div class="dashboard">
    <div>
      <h1>WELCOME BACK TO PINSTER</h1>
    </div>
    <div class="container-fluid">
      <div class="row">
        <div class="col"></div>
        <div class="col">
          <div class="card-deck">
            <vaults v-for="vault in vaults" :key="vault.id" :vault="vault" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vaults from "@/components/Vaults.vue";
export default {
  name: "dashboard",
  // props:[user],
  mounted() {
    return this.$store.dispatch("getVaults");

    console.log(this.$route.user);
  },

  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  components: {
    Vaults
  }
};
</script>

<style></style>

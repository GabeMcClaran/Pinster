<template>
  <div class="vault">
    <div class="card" style="width: 18rem;">
      <div class="card-body">
        <div class="inline-block">
          <h5 class="card-title">{{vault.name}}</h5>
          <img
            id="size"
            @click="removeVault(vault)"
            src="https://img.icons8.com/dusk/64/000000/delete-sign.png"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vault"],

  mounted() {
    this.$store.dispatch("getVaults");
  },
  methods: {
    removeVault(vault) {
      this.$store.dispatch("deleteVault", vault);
      console.log(vault);
    }
  },

  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  }
};
</script>

<style>
</style>
<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row">
        <div class="col">
          <h2 class="text-center">Keeps {{user}}</h2>
        </div>
      </div>
      <div class="row" id="keepCards">
        <div v-for="keep in keeps" :key="keep.id" class="card col-sm-9 col-md-6 col-lg-3 m-3">
          <div class="card-body">
            <h5>{{keep.name}}</h5>
            <select @change="moveKeep(keep, newVaultId)" v-model="newVaultId">
              <option :value="vault.id" v-for="vault in vaults" :key="vault.id">{{vault.name}}</option>
            </select>
            <div>
              <img @click="addKeepToUser()" src="https://img.icons8.com/doodle/48/000000/add.png" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  props: ["vault"],
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        views: "",
        shares: "",
        keeps: ""
      }
    };
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    moveKeep(keep, newVaultId) {
      let oldlistId = keep.listId;
      keep.vaultId = newVaultId;

      this.$store.dispatch("changeKeepVault", { keep });
    }
  }
};
</script>

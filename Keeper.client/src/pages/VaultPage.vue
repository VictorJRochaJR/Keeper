<template>
  <div>
    <div class="col-2">
      <svg v-if="account.id == activeVault.creatorId"
           @click="deleteVault"
           xmlns="http://www.w3.org/2000/svg"
           width="40"
           height="40"
           fill="gray"
           class="bi bi-trash"
           viewBox="0 0 16 16"
      >
        <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
        <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
      </svg>
    </div>
    {{ vaultKeeps.length }}
    <div class="card-columns">
      <ActiveVaultKeepTemplate v-for="k in vaultKeeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {

  setup() {
    const route = useRoute()
    const router = useRouter()
    onMounted(async() => {
    // get vault by id
      await vaultsService.getKeepsByVaultId(route.params.id)
    })
    return {
      activeVault: computed(() => AppState.activeProfileVault),
      vaultKeeps: computed(() => AppState.vaultKeeps),
      account: computed(() => AppState.account),
      async deleteVault() {
        await vaultsService.deleteVault(this.activeVault.id)
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>

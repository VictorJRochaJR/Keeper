<template>
  <div>
    <ActiveVaultKeepTemplate v-for="k in vaultKeeps" :key="k.id" :keep="k" />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {

  setup() {
    const route = useRoute()
    onMounted(async() => {
      await vaultsService.getKeepsByVaultId(route.params.id)
    })
    return {
      vaultKeeps: computed(() => AppState.vaultKeeps)
    }
  }
}
</script>

<style lang="scss" scoped>

</style>

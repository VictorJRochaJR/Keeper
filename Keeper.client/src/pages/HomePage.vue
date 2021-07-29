<template>
  <div class="">
    <div v-if="keeps">
      <div class="card-columns">
        <KeepTemplate v-for="k in keeps" :key="k.id" :keep="k" />
      </div>
      <KeepModal />
    </div>
  </div>
</template>

<script>
import { onMounted, computed, reactive } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'

export default {
  setup() {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    onMounted(async() => {
      try {
        await keepsService.getKeeps()
        // await vaultsService.getVaultsForDropDown(state.account.id)
      } catch (error) {
        Notification.toast(error.message)
      }
    })
    return {
      state,
      keeps: computed(() => AppState.allKeeps),

      vaults: computed(() => AppState.profileVaults)
    }
  }
}
</script>

<style scoped lang="scss">
@media (min-width: 34em) {
    .card-column {
        -webkit-column-count: 2;
        -moz-column-count: 2;
        column-count: 2;
    }
}

@media (min-width: 48em) {
    .card-column {
        -webkit-column-count: 3;
        -moz-column-count: 3;
        column-count: 3;
    }
}

@media (min-width: 62em) {
    .card-column {
        -webkit-column-count: 4;
        -moz-column-count: 4;
        column-count: 4;
    }
}

@media (min-width: 75em) {
    .card-column {
        -webkit-column-count: 5;
        -moz-column-count: 5;
        column-count: 5;
    }
}

</style>

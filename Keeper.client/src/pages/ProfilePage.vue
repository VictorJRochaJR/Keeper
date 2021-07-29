<template>
  <div class="profile">
    <div class="container-fluid">
      <div class="row mt-5 ml-2">
        <div class="col">
          <img class="rounded-edges" :src="activeProfile.picture" height="250" width="250">
        </div>
        <div class="col">
          {{ activeProfile.name }}
          <div>
            <span>Vaults: {{ profileVaults.length }}
            </span>
          </div>
          <div>
            <span>Keeps: {{ profileKeeps.length }}
            </span>
          </div>
        </div>
      </div>
      <div class="row mt-3 ml-5 align-items-baseline">
        <h1>Vaults</h1> <svg v-if="state.account.id == activeProfile.id"
                             data-toggle="modal"
                             data-target="#createVaultModal"
                             xmlns="http://www.w3.org/2000/svg"
                             width="30"
                             height="30"
                             fill="currentColor"
                             class="bi bi-plus-circle-fill ml-2"
                             viewBox="0 0 16 16"
        >
          <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z" />
        </svg>
      </div>
      <div class="row">
        <div class="card-columns">
          <VaultTemplate v-for="v in profileVaults" :key="v.id" :vault="v" />
        </div>
      </div>
      <div class="row mt-3 ml-5 align-items-baseline">
        <h1>Keeps</h1><svg v-if="state.account.id == activeProfile.id"
                           data-toggle="modal"
                           data-target="#createKeepModal"
                           xmlns="http://www.w3.org/2000/svg"
                           width="30"
                           height="30"
                           fill="currentColor"
                           class="bi bi-plus-circle-fill ml-2"
                           viewBox="0 0 16 16"
        >
          <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z" />
        </svg>
      </div>
      <div class="card-columns">
        <ActiveKeepTemplate v-for="pk in profileKeeps" :key="pk.id" :profilekeep="pk" />
      </div>
    </div>
    <CreateVaultModal />
    <CreateKeepModal />
  </div>
</template>

<script>
import { keepsService } from '../services/KeepsService'
import { profilesService } from '../services/ProfilesService'
import { vaultsService } from '../services/VaultsService'
import { onMounted, computed, watch, reactive } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { AppState } from '../AppState'
export default {
  setup() {
    const state = reactive({
      account: computed(() => AppState.account)

    })
    watch(
      () => state.account, async() => {
        await vaultsService.getVaultsByProfileId(route.params.id)
      }
    )
    const route = useRoute()
    onMounted(async() => {
      console.log(route.params.id)
      await keepsService.getKeepByProfileId(route.params.id)
      await profilesService.getProfile(route.params.id)
      await vaultsService.getVaultsByProfileId(route.params.id)
    })
    return {
      state,

      activeProfile: computed(() => AppState.activeProfile),
      profileVaults: computed(() => AppState.profileVaults),
      profileKeeps: computed(() => AppState.profileKeeps)
    }
  },
  name: 'ProfilePage'
}

</script>
<style scoped>
.rounded-edges{
  border-radius: 40px;
}
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

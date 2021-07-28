<template>
  <router-link @click="setActiveVault" :to="{name: 'VaultPage', params:{ id: vault.creatorId}}" :key="vault.creatorId">
    <div class="card ">
      <div class="row">
        <div class="col text-center">
          {{ vault.name }}
        </div>
      </div>
      <div class="row">
        <div class="col text-center">
          {{ vault.description }}
        </div>
      </div>
    </div>
  </router-link>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { vaultsService } from '../services/VaultsService'
export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      setActiveVault() {
        vaultsService.setVault(props.vault.id)
        console.log(props.vault.id)
      }
    }
  }

}
</script>

<style lang="scss" scoped>

</style>

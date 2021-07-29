<template>
  <!-- Modal -->
  <div class="modal fade"
       id="createVaultModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="keepModal"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Create a Keep
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit="createVault" class="">
            <div class="form-group">
              <label for="exampleDropdownFormEmail2" class="sr-only">Nick Name</label>
              <input type="text" class="form-control" v-model="state.vault.name" placeholder="Vault Name">
            </div>
            <div class="form-check">
              <input class="form-check-input" v-model="state.vault.isPrivate" type="checkbox" value="" id="flexCheckDefault">
              <label class="form-check-label" for="flexCheckDefault">
                Set vault to private
              </label>
            </div>
            <button type="submit" class="btn btn-secondary">
              Create Vault
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { vaultsService } from '../services/VaultsService'
export default {

  setup() {
    const state = reactive({
      vault: {}
    })
    return {
      state,
      async createVault() {
        await vaultsService.createVault(state.vault)
        state.vault = {}
      }
    }
  }

}
</script>

<style lang="scss" scoped>

</style>

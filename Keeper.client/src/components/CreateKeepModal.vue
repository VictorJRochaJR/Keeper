<template>
  <!-- Modal -->
  <div class="modal fade"
       id="createKeepModal"
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
          <form @submit="createKeep" class="">
            <div class="form-group">
              <label for="exampleDropdownFormEmail2" class="sr-only">Nick Name</label>
              <input type="text" class="form-control" v-model="state.keep.name" placeholder="Keep Name" required>
              <label for="exampleDropdownFormEmail2" class="sr-only">Nick Name</label>
              <input type="text" class="form-control" v-model="state.keep.description" placeholder="Keep Description" required>
              <label for="exampleDropdownFormEmail2" class="sr-only">Nick Name</label>
              <input type="text" class="form-control" v-model="state.keep.img" placeholder="Keep Image" required>
            </div>
            <button type="submit" class="btn btn-secondary">
              Create Keep
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    const state = reactive({
      keep: {}
    })
    return {
      state,
      async createKeep() {
        await keepsService.createKeep(state.keep)
        state.keep = {}
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>

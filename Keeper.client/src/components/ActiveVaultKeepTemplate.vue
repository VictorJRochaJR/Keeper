<template>
  <div class="card row" data-toggle="modal" data-target="#activeVaultKeepModal" @click="setActiveVaultKeep">
    <img class="card-img-top img-fluid" id="bg-img" :src="keep.img">
    <div class="card-img-overlay text-center">
      <div class="d-flex align-items-end">
        <h4>{{ keep.description }}</h4>
      </div>
    </div>
    <ActiveVaultKeepModal />
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService'
export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      setActiveVaultKeep() {
        keepsService.increaseView(props.keep.id)

        keepsService.setActiveVaultKeep(props.keep.id)
      }
    }
  }

}
</script>

<style lang="scss" scoped>
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

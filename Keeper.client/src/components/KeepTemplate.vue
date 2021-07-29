<template>
  <div class="card row" data-toggle="modal" data-target="#keepModal" @click="setactiveKeep">
    <img class="card-img-top img-fluid" id="bg-img" :src="keep.img">
    <!-- :style="{ backgroundImage: `url(${keep.img})`} " -->
    <div class="card-img-overlay text-center">
      <div class="d-flex align-items-end" data-dismiss="modal">
        <h4>{{ keep.description }}</h4>
        <router-link @click.stop :to="{name: 'ProfilePage', params:{ id: keep.creatorId}}" data-dismiss="modal" :key="keep.creatorId">
          <img class="rounded-edges" :src="keep.creator.picture" height="40" width="40" data-dismiss="modal">
        </router-link>
      </div>
    </div>
  </div>
  <KeepModal />
</template>

<script>
import { reactive, computed } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      setactiveKeep() {
        keepsService.increaseView(props.keep.id)
        keepsService.setKeep(props.keep.id)
      },
      activeKeep: computed(() => AppState.activePost)

    }
  }
}
</script>

<style scoped>
#bg-img{
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.rounded-edges{
  border-radius: 10px;
}
</style>

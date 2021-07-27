<template>
  <div class="card" data-toggle="modal" data-target="#keepModal" @click="activeKeep">
    <img class="card-img-top img-fluid" id="bg-img" :src="keep.img">
    <!-- :style="{ backgroundImage: `url(${keep.img})`} " -->
    <div class="card-img-overlay text-center">
      <h4>{{ keep.description }}</h4>
    </div>
  </div>
  <KeepModal />
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
      activeKeep() {
        keepsService.setKeep(props.keep.id)
      }

    }
  }
}
</script>

<style scoped>
#bg-img{
  width: 100%;
  height: 70%;
  object-fit: cover;

}

</style>

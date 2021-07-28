<template>
  <div class="card row" data-toggle="modal" data-target="#activekeepModal" @click="setProfileKeep">
    <img class="card-img-top img-fluid" id="bg-img" :src="profilekeep.img">
    <div class="card-img-overlay text-center">
      <div class="d-flex align-items-end">
        <h4>{{ profilekeep.description }}</h4>
      </div>
    </div>
    <ActiveKeepModal />
  </div>
</template>

<script>
import { keepsService } from '../services/KeepsService'
import { reactive } from '@vue/reactivity'
export default {
  props: {
    profilekeep: { type: Object, required: true }

  },
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      setProfileKeep() {
        keepsService.setActiveProfileKeep(props.profilekeep.id)
      }
    }
  }

}
</script>

<style lang="scss" scoped>
#bg-img{
  width: 100%;
  height: 70%;
  object-fit: cover;

}

</style>

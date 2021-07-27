<template>
  <div v-if="keeps">
    Home Page
    <KeepTemplate v-for="k in keeps" :key="k.id" :keep="k" />
  </div>
</template>

<script>
import { onMounted, computed } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'

export default {
  setup() {
    onMounted(async() => {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Notification.toast(error.message)
      }
    })
    return {
      keeps: computed(() => AppState.allKeeps)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>

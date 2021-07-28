<template>
  <div class="card row" data-toggle="modal" data-target="#activekeepModal">
    <img class="card-img-top img-fluid" id="bg-img" :src="keep.img">
    <div class="card-img-overlay text-center">
      <div class="d-flex align-items-end">
        <h4>{{ keep.description }}</h4>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup() {
    return {}
  }

}
</script>

<style lang="scss" scoped>

</style>

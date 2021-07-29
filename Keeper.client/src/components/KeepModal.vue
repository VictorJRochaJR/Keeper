<template>
  <div class="modal fade"
       id="keepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="keepModal"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="container" v-if="activeKeep.creator">
          <div class="row">
            <div class="col-6">
              <img class="img-fluid m-2 rounded-edges" :src="activeKeep.img">
            </div>
            <div class="col-6">
              <div>
                <div class="row">
                  <div class="col">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="row mt-4 d-flex justify-content-center">
                  <div class="col-3">
                    <svg xmlns="http://www.w3.org/2000/svg"
                         width="16"
                         height="16"
                         fill="blue"
                         class="bi bi-eye-fill"
                         viewBox="0 0 16 16"
                    >
                      <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z" />
                      <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z" />
                    </svg>
                    {{ activeKeep.views }}
                  </div>
                  <div class="col-3">
                    <img src="../assets/img/Letter-K-PNG-Stock-Photo.png" width="16" height="16" />
                    {{ activeKeep.keeps }}
                  </div>
                  <div class="col-3">
                    <svg xmlns="http://www.w3.org/2000/svg"
                         width="16"
                         height="16"
                         fill="blue"
                         class="bi bi-share-fill"
                         viewBox="0 0 16 16"
                    >
                      <path d="M11 2.5a2.5 2.5 0 1 1 .603 1.628l-6.718 3.12a2.499 2.499 0 0 1 0 1.504l6.718 3.12a2.5 2.5 0 1 1-.488.876l-6.718-3.12a2.5 2.5 0 1 1 0-3.256l6.718-3.12A2.5 2.5 0 0 1 11 2.5z" />
                    </svg>
                    {{ activeKeep.shares }}
                  </div>
                </div>
              </div>
              <div class="row mt-5 d-flex justify-content-center">
                <h2 class="modal-description" id="keepModal">
                  {{ activeKeep.name }}
                </h2>
              </div>
              <div class="row mt-5">
                <div class="col text-center">
                  <span id="fontSize" style="font-size: 150%">{{ activeKeep.description }}
                  </span>
                  <div class="row-bordered mt-4">
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-4">
                  <div class="dropdown" v-if="state.vaults != null">
                    <button class="btn btn-secondary btn-sm dropdown-toggle"
                            type="button"
                            id="dropdownMenuButton"
                            data-toggle="dropdown"
                            aria-haspopup="true"
                            aria-expanded="false"
                    >
                      Dropdown button
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                      <a class="dropdown-item" v-for="v in state.vaults" :key="v.id" :vault="v" href="#">{{ v.name }}</a>
                    </div>
                  </div>
                </div>
                <div class="col-2">
                  <svg @click="deleteKeep"
                       xmlns="http://www.w3.org/2000/svg"
                       width="40"
                       height="40"
                       fill="gray"
                       class="bi bi-trash"
                       viewBox="0 0 16 16"
                  >
                    <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                    <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                  </svg>
                </div>
                <div class="col-4">
                  <div class="row h-100 d-flex flex-column">
                    <div class="col-4">
                      <img :src="activeKeep.creator.picture" class="rounded-edges" alt="Girl in a jacket" height="40" width="40">
                    </div>
                    <div class="col-6">
                      <span>{{ activeKeep.creator.name }}</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    const state = reactive({
      vaults: computed(() => AppState.dropdownVaults)
    })
    return {
      async deleteKeep(id) {
        await keepsService.deleteKeep(this.activeKeep.id)
      },
      state,
      activeKeep: computed(() => AppState.activeKeep)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
  .img-fluid{
display: block;
  width: 100%;
  max-height: auto;
  }
 modal-lg {
  max-width: 900px;
}
@media (min-width: 768px) {
   .modal-lg {
    width: 100%;
  }
}
@media (min-width: 992px) {
  .modal-lg {
    width: 900px;
  }
}

.rounded-edges{
  border-radius: 10px;
}

.fontSize{
  font-size: 60px;
}
.row-bordered {
  position: relative;
}

.row-bordered:after {
  content: "";
  display: block;
  border-bottom: 2px solid rgb(3, 3, 3);
  position: absolute;
  bottom: 0;
  left: 15px;
  right: 15px;
}

</style>

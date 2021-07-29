import { get } from 'jquery'
import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.allKeeps = res.data
    console.log(res.data)
  }

  setKeep(keepId) {
    const keep = AppState.allKeeps.find(k => k.id === keepId)
    console.log(keep, 'activekeep')
    AppState.activeKeep = keep
  }

  async increaseView(keepId) {
    const res = await api.get('api/keeps/' + keepId + '/increaseviews')
    console.log(res, 'keep added')
  }

  async getKeepByProfileId(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/keeps')
    console.log('profilekeeps', res.data)
    AppState.profileKeeps = res.data
  }

  setActiveProfileKeep(keepId) {
    const keep = AppState.profileKeeps.find(k => k.id === keepId)
    AppState.activeProfileKeep = keep
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    console.log(res.data)
  }

  async deleteKeep(id) {
    const res = await api.delete('api/keeps/' + id)
    console.log(res.data)
  }
}

export const keepsService = new KeepsService()

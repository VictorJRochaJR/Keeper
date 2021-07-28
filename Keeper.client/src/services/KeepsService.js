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

  async getKeepByProfileId(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/keeps')
    console.log('profilekeeps', res.data)
    AppState.profileKeeps = res.data
  }

  setActiveProfileKeep(keepId) {
    const keep = AppState.profileKeeps.find(k => k.id === keepId)
    AppState.activeProfileKeep = keep
  }
}

export const keepsService = new KeepsService()

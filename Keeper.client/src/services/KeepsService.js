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
}

export const keepsService = new KeepsService()

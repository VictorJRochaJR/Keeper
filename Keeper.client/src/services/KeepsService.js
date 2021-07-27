import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    AppState.allKeeps = res.data
    console.log(res.data)
  }
}

export const keepsService = new KeepsService()

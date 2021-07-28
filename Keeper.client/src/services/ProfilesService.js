import { AppState } from '../AppState'
import { api } from './AxiosService'
class ProfilesService {
  async getProfile(id) {
    const res = await api.get('api/profiles/' + id)
    console.log('profile', res.data)
    AppState.activeProfile = res.data
  }
}
export const profilesService = new ProfilesService()

import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultsByProfileId(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    console.log('profilevaults', res.data)
    AppState.profileVaults = res.data
  }

  setVault(vaultId) {
    debugger
    const vault = AppState.profileVaults.find(v => v.id === vaultId)
    console.log(vault, 'activevault')
    AppState.activeProfileVault = vault
  }
}

export const vaultsService = new VaultsService()

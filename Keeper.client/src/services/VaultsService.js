import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultsByProfileId(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    console.log('profilevaults', res.data)
    AppState.profileVaults = res.data
  }

  setVault(vaultId) {
    console.log(AppState.profileVaults)

    const vault = AppState.profileVaults.find(v => v.id === vaultId)
    console.log(vault, 'activevault')
    AppState.activeProfileVault = vault
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    console.log('vaultkeeps', res.data)
    AppState.vaultKeeps = res.data
  }
}

export const vaultsService = new VaultsService()

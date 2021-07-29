import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultsByProfileId(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    console.log('profilevaults', res.data)
    AppState.profileVaults = res.data
  }

  async getVaultsForDropDown(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    console.log('profilevaults', res.data)
    AppState.dropdownVaults = res.data
  }

  setVault(vaultId) {
    console.log(AppState.profileVaults, 'profilevaults')

    const vault = AppState.profileVaults.find(v => v.id === vaultId)
    console.log(vault, 'activevault')
    AppState.activeProfileVault = vault
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    console.log('vaultkeeps', res.data)
    AppState.vaultKeeps = res.data
  }

  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    console.log(res.data)
  }

  async deleteVault(id) {
    const res = await api.delete('api/vaults/' + id)
    console.log(res.data)
  }

  async createVaultKeep(vaultId, keepId) {
    const newVaultKeep = {}
    newVaultKeep.vaultId = vaultId
    newVaultKeep.keepId = keepId
    const res = await api.post('api/vaultkeeps', newVaultKeep)
    console.log(res.data)
  }
}

export const vaultsService = new VaultsService()

using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
       private readonly VaultKeepsRepository _vkr;
       private readonly VaultsRepository _vr;
       public VaultKeepsService(VaultKeepsRepository vkr, VaultsRepository vr)
       {
           _vkr = vkr;
           _vr = vr;
       }

       public VaultKeep Create(VaultKeep newvk)
       {

           VaultKeep vaultkeep = _vkr.Create(newvk);
         Vault vault =  _vr.GetOne(newvk.VaultId);
            if (vaultkeep.CreatorId != vault.CreatorId)
            {
                throw new Exception();
            }
            return vaultkeep;

       }

       public VaultKeep Get(int id)
       {
           return _vkr.Get(id);
       }


       internal void Delete(int id)
       {
        _vkr.Delete(id);
       }
    }
}
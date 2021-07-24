using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class VaultKeepsService
    {
       private readonly VaultKeepsRepository _vkr;
       public VaultKeepsService(VaultKeepsRepository vkr)
       {
           _vkr = vkr;
       }

       public VaultKeep Create(VaultKeep newvk)
       {
           return _vkr.Create(newvk);
       }
    }
}
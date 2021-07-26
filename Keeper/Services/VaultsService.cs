using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;
using Microsoft.AspNetCore.Http;

namespace Keeper.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vr;
        public VaultsService(VaultsRepository vr)
        {
            _vr = vr;
        }

        public void Delete(int id, string userId)
        {
            Vault vault = GetOne(id);
            if(vault.CreatorId != userId)
            {
                throw new Exception("You are not allowed to delete");
            }
            _vr.Delete(id);
        }
        
        public Vault Create(Vault vault)
        {
            return _vr.Create(vault);
        }

        internal Vault GetOne(int id)
    {
        var vault = _vr.GetOne(id);
        if (vault == null)
        {
            throw new System.Exception("invalid id");
        }
        return vault;
    }

        internal Vault Update(Vault v, string id)
        {
            Vault vault = _vr.GetOne(v.Id);
            if (vault == null)
            {
                throw new Exception("invalid id");
            }
            if (vault.CreatorId != id)
            {
                throw new Exception("You are not allowed to edit this");  
            }
            vault.Name = v.Name ?? vault.Name;
            vault.Description = v.Description ?? vault.Description;
            vault.IsPrivate = v.IsPrivate;
            return _vr.Update(vault);
            



        }

        public async List<Vault> GetVaultsById(string id, userInfo)
        {            
            var vaults = _vr.GetVaultByProfileId(id);
            foreach (var vault in vaults)
            {
                if (vault.IsPrivate != true && vault.CreatorId != userInfo.Id )
                {
                    
                }
            }
        }
    }
}
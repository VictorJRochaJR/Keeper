using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _kr;
        
        public KeepsService(KeepsRepository kr)
        {
            _kr = kr;
        }

        public Keep Create(Keep keep)
        {
            return _kr.Create(keep);
        }

        public List<Keep> GetAll()
        {
            return _kr.GetAll();
        }

        internal Keep GetOne(int id)
        {
            var keep = _kr.GetOne(id);
            if (keep == null)
            {
                throw new Exception("invalid id");
            }
            return keep;

        }

        public void Delete(int id, string userId)
        {
            Keep keep = GetOne(id);
            if(keep.CreatorId != userId)
            {
                throw new Exception("You are not allowed to delete this");
            }
            _kr.Delete(id);
        }

        public List<Keep> KeepByProfileId(string id, Account userInfo)
        {
            var keeps = _kr.GetKeepsByProfileId(id);
            return keeps;
        }

        public Keep Update(Keep k, string id)
        {
            Keep keep = _kr.GetOne(k.Id);
            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }
            if (keep.CreatorId != id)
            {
                throw new Exception("You are not allowed to edit this");
            }
            keep.Name = k.Name ?? keep.Name;
            keep.Description = k.Description ?? keep.Description;
            keep.Img = k.Img ?? keep.Img;
            keep.Views = k.Views;
            keep.Shares = k.Shares;

            return _kr.Update(keep);


        }

        internal  IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, Account userInfo)
        {
        
    return _kr.GetKeepsByVaultId(id);     
}
    public Keep IncreaseView(int id)
        {
            Keep keep = _kr.GetOne(id);
            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }

            //keep.Name = k.Name ?? keep.Name;
            //keep.Description = k.Description ?? keep.Description;
            //keep.Img = k.Img ?? keep.Img;
            keep.Views++;
            //keep.Shares = k.Shares;

            return _kr.Update(keep);


        }
        public Keep IncreaseKeep(int id)
        {
            Keep keep = _kr.GetOne(id);
            if (keep == null)
            {
                throw new Exception("Invalid Id");
            }

            //keep.Name = k.Name ?? keep.Name;
            //keep.Description = k.Description ?? keep.Description;
            //keep.Img = k.Img ?? keep.Img;
            keep.Keeps++;
            //keep.Shares = k.Shares;

            return _kr.Update(keep);


        }
        
    }




}
using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Repositories;

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
    }
}
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
            return _kr.GetOne(id);
        }
    }
}
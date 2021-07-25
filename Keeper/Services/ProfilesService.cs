using System;
using Keeper.Models;
using Keeper.Repositories;

namespace Keeper.Services
{
    public class ProfilesService
    {
        private readonly AccountsRepository _repo;
        public ProfilesService(AccountsRepository repo)
        {
            _repo = repo;

        }
        internal Profile GetProfileById(string id)
        {
            Profile profile = _repo.GetById(id);
            if (profile == null)
            {
                throw new Exception("Invalid id");
            }
                    return profile;
                }
            }
            
        }
using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get()
        {

            return _repo.Get();
        }

        public Vault GetById(int id, string userId)
        {
            Vault exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("invalid ID"); }
            return exists;
        }

        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal string Delete(int id)
        {
            var Current = _repo.GetById(id);
            if (Current == null) { throw new Exception("Invalid ID"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }



    }
}
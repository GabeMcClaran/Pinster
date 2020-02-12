using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository ks)
        {
            _repo = ks;
        }

        // internal object GetById(int id, string userId)
        // {
        //     throw new NotImplementedException();
        // }

        public VaultKeep Create(VaultKeep newData)
        {
            var exists = _repo.Find(newData.KeepId, newData.VaultId, newData.UserId);
            if (exists != null) { return exists; }
            exists = _repo.Create(newData);
            return exists;


        }

        public IEnumerable<Keep> GetKeepsByVault(int id, string userId)
        {
            var exists = _repo.GetKeepsById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }



        public String Delete(int vaultId, int keepId, string userId)
        {
            var exists = _repo.GetVaultKeep(vaultId, keepId, userId);
            if (exists != null)
            {
                return _repo.Delete(exists.Id);
            }

            return "Failed";

        }

    }
}
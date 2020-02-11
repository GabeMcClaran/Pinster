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

        internal void Create(VaultKeep newData)
        {
            VaultKeep exists = _repo.Find(newData);
            if (exists != null) { throw new Exception("Keep already exists in Vault"); }
            _repo.Create(newData);


        }

        public IEnumerable<Keep> GetKeepsByVault(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }



        // public string Delete(int id)
        // {
        //     VaultKeep exists = _repo.Get(id);
        //     if(exists ==null){throw new Exception("Invalid Id");}
        //     _repo.Delete(id);
        //     return "Deleted!!";
        // }

    }
}
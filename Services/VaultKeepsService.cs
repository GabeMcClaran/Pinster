using System;
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


        public object GetById(int id, string userId)
        {

        }
        public void Create(VaultKeepsService newData)
        {
            throw new NotImplementedException();
        }

        public object Delete(VaultKeep vk)
        {
            _repo.Delete()
        }

    }
}
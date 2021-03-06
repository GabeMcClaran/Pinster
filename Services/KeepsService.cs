using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {

            return _repo.Get();
        }

        internal Keep GetById(int id)
        {
            var exists = _repo.GetById(id);


            if (exists == null) { throw new Exception("Invalid Id, or private"); }
            else if (exists.IsPrivate == true)
            {
                throw new Exception("This keep is Private");
            }
            return exists;
        }

        public Keep Create(Keep newKeep)
        {

            return _repo.Create(newKeep);

        }

        internal Keep Edit(Keep update)
        {
            var exists = _repo.GetById(update.Id);
            if (exists == null) { throw new Exception("Invalid ID"); }
            _repo.Edit(update);
            return update;
        }

        internal string Delete(int id)
        {
            var current = _repo.GetById(id);
            if (current == null) { throw new Exception("Invalid ID"); }
            _repo.Delete(id);
            return "Successfully Deleted";

        }
    }
}
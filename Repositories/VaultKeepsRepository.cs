using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }



        internal VaultKeep Find(VaultKeep vk)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @KeepId AND vaultId = @VaultId)";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, vk);
        }

        public IEnumerable<Keep> GetById(int id)
        {
            string sql = "SELECT * FROM vaultkeeps Where vaultId = @VaultId";
            return _db.Query<Keep>(sql, new { id });
        }



        internal VaultKeep Create(VaultKeep newData)
        {
            string sql = @" INSERT INTO vaultkeeps (keepId, vaultId, userId) VALUES (@KeepId, @VaultId, @UserId); SELECT LAST_INSERT_ID();";
            string id = _db.ExecuteScalar<string>(sql, newData);
            newData.UserId = id;
            return newData;
        }



        internal void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
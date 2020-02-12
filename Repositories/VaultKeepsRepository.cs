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



        public VaultKeep Find(int keepId, int vaultId, string UserId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { keepId, vaultId });
        }

        public IEnumerable<Keep> GetKeepsById(int vaultId, string userId)
        {
            string sql = "SELECT k.* FROM vaultkeeps vk INNER JOIN keeps k ON k.id = vk.keepId WHERE (vaultId = @vaultId AND vk.userId = @userId)";
            return _db.Query<Keep>(sql, new { vaultId, userId });
        }

        public VaultKeep GetVaultKeep(int vaultId, int keepId, string userId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId, userId });
        }

        public VaultKeep Create(VaultKeep newData)
        {
            string sql = @" INSERT INTO vaultkeeps (keepId, vaultId, userId) VALUES (@KeepId, @VaultId, @UserId); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }



        public string Delete(int id)
        {
            string sql = @"DELETE FROM vaultkeeps WHERE id = @id;";
            _db.ExecuteScalar<int>(sql, new { id });
            return "Deleted";
        }
    }
}
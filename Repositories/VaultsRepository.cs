using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM vaults";
            return _db.Query<Vault>(sql);
        }
        public Vault GetById(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id =@id ";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }


        internal Vault Create(Vault VaultData)
        {
            string sql = @"INSERT INTO vaults ( name, description, userId, id) VALUES (@Name, @Description, @UserId, @Id);
           SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, VaultData);
            VaultData.Id = id;
            return VaultData;

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id=@id";
            _db.Execute(sql, new { id });
        }
    }

}
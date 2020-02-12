using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0";
            return _db.Query<Keep>(sql);
        }

        public Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }
        public Keep Create(Keep KeepData)
        {
            string sql = @"INSERT INTO keeps ( name, description, img, isPrivate)
            VALUES (@Name, @Description, @Img, @IsPrivate);
            SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, KeepData);
            KeepData.Id = id;
            return KeepData;
        }


        public void Edit(Keep update)
        {
            string sql = @"UPDATE keeps SET name =@Name,
            description =@Description,
            img = @Img,
            isPrivate = @IsPrivate,
            userId = @UserId;
            ";
            _db.Execute(sql, update);
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id=@id";
            _db.Execute(sql, new { id });
        }
    }
}
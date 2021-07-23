using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;
        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep Create(Keep k)
        {
            string sql = @"
            INSERT INTO keeps(creatorId, name, description, img, views, shares)
            VALUES(@CreatorId, @Name, @Description, @Img, @Views, @Shares );
            SELECT LAST_INSERT_ID();";
            k.Id = _db.ExecuteScalar<int>(sql, k);
            return k;
        }

        public Keep GetOne(int id)
        {
          string sql = @"
         SELECT
                 k.*,
                a.*
                FROM keeps k
                JOIN accounts a ON k.creatorId = a.id
                WHERE k.id = @id;";
                return _db.Query<Keep, Account, Keep>(sql, (k,a) =>
                {
                    k.Creator = a;
                    return k;
                }, new {id}).FirstOrDefault();
        }

        internal void Delete(int id)
        {
         string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1 ;";
          _db.Execute(sql, new {id});
        }

        internal List<Keep> GetAll()
        {
           string sql = @"
           SELECT
           k.*,
           a.*
           FROM keeps k
           JOIN Accounts a ON k.creatorId = a.id;";
           return _db.Query<Keep, Account, Keep>(sql, (k, a) => 
           {
               k.Creator = a;
               return k;
           }, splitOn: "id").ToList();
        }
    }
}
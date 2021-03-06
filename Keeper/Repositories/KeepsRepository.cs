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

        public List<Keep> GetKeepsByProfileId(string id)
        {
             string sql = @"
         SELECT
                 k.*,
                 a.*
                 From keeps k
                 JOIN accounts a ON k.CreatorId = a.id
                 WHERE a.id = @id;";
                return _db.Query<Keep, Account, Keep>(sql, (k,a) =>
                {
                    k.Creator = a;
                    return k;
                }, new {id}).ToList();
        }

        
//         {
// string sql = @"
//  SELECT k.*,
//  a.* 
//  FROM keeps k
//  JOIN accounts A  ON k.creatorId = a.id
//  WHERE k.id = @id;";
//  return _db.Query<Keep, Account, Keep>(sql, (k,a) =>
//  {
//      k.Creator = a;
//      return k;
//  }, splitOn: "id").ToList();
//  }
 

        

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
           JOIN accounts a ON k.creatorId = a.id;";
           return _db.Query<Keep, Account, Keep>(sql, (k, a) => 
           {
               k.Creator = a;
               return k;
           }, splitOn: "id").ToList();
        }

        internal Keep Update(Keep k)
        {
           string sql = @"
           UPDATE keeps
           SET 
           name = @Name,
           description = @Description,
           img = @Img,
           views = @Views,
           shares = @Shares,
           keeps = @Keeps
           WHERE id = @Id;
           ";
           
           var rowsAffected = _db.Execute(sql, k);
           if(rowsAffected > 1){
               throw new Exception("Too many updated");
           }
           if (rowsAffected < 1)
           {
               throw new Exception("update didnt work");
           }
           return k;
        }

        internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
        {
            string sql = @"
            SELECT 
            k.*,
            vk.id AS VaultKeepId
            FROM vaultkeeps vk
            JOIN keeps k ON k.id = vk.keepId
            WHERE vaultId = @id;";
            return _db.Query<VaultKeepViewModel>(sql, new {id});
        }
    }
}
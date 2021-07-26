using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        

        internal Vault Create(Vault v)
        {
            string sql = @"
            INSERT INTO vaults(creatorId, name, description, isprivate)
            VALUES(@CreatorId, @Name, @Description, @IsPrivate);
            SELECT LAST_INSERT_ID();";
            v.Id =_db.ExecuteScalar<int>(sql, v);
            return v;
            
        }

        public Vault GetOne(int id)
        {
            string sql = @"
            SELECT v.*,
            a.*
            FROM vaults v
            JOIN accounts a ON v.creatorId = a.id
            WHERE v.id = @id;";
            return _db.Query<Vault, Account, Vault>(sql, (v,a) =>
            {
                v.Creator = a;
                return v;
            }, new {id}).FirstOrDefault();
            }

        internal Vault Update(Vault v)
        {
        string sql = @"
        UPDATE vaults
        SET 
        name = @Name,
        description = @Description,
        isPrivate = @IsPrivate
        WHERE id = @Id;";       
        
        var rowsAffected = _db.Execute(sql, v);
        if(rowsAffected > 1)
        {
            throw new Exception("too many updated");
            }
            if (rowsAffected < 1 )
            {
                throw new Exception("update didnt work");
            }
            return v;
        }

        public List<Vault> GetVaultByProfileId(string id)
        {
            string sql = @"
            SELECT v.*,
            a.*
            FROM vaults v
            JOIN accounts a on v.CreatorId = a.id
            WHERE a.id = @id;";
             return _db.Query<Vault, Account, Vault>(sql, (v,a) =>
             {
                 v.Creator = a;
                 return v;
             }, new {id}).ToList();
              
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults where id = @id LIMIT 1;";
            _db.Execute(sql, new {id});
        }
    }
    }

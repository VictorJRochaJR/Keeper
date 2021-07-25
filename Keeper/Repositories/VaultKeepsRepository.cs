using System.Data;
using Dapper;
using Keeper.Models;

namespace Keeper.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep Create(VaultKeep vk)
        {
            string sql = @"
            INSERT INTO vaultkeeps(creatorId, vaultId, keepId)
            VALUES
            (@CreatorId, @VaultId, @KeepId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, vk);
            vk.Id = id;
            return vk;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new {id});
        }
    }
}
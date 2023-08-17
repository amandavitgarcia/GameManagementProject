using Dapper;
using ProjetoAds.CrossCutting.Settings;
using ProjetoAds.Domain.Entities;
using ProjetoAds.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Data.Repository
{
    public class ChampionshipRepository : IChampionshipRepository
    {
        public IEnumerable<Championship> GetAll()
        {
            using (var connection = new SqlConnection("Server=tcp:projetomackenzie.database.windows.net,1433;Initial Catalog=bancoprojeto;Persist Security Info=False;User ID=raizchefe;Password=gCvNFgXN@f5ttnV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connection.Open();

                string query = @"SELECT * FROM [dbo].[Championship]";

                return connection.Query<Championship>(query).ToList();
            }
        }

        public Championship GetById(long id)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                string query = @"SELECT * FROM [dbo].[Championship] WHERE [Id] = @Id";

                return connection.Query<Championship>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public void Insert(Championship championship)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"INSERT INTO [dbo].[Championship] (Description, Name, UserAdministratorId, Active, " +
                            "DataCriacao, DataAtualizacao)" +
                            "VALUES" +
                            "(@Description, @Name, @UserAdministratorId, @Active, GETDATE(), GETDATE()" +
                            "GETDATE(), GETDATE())";

                connection.Execute(query, new
                {
                    Description = championship.Description,
                    Name = championship.Name,
                    UserAdministratorId = championship.UserAdministratorId,
                    Active = championship.Active
                });
            }
        }

        public void Update(Championship championship)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"UPDATE [dbo].[Championship] SET " +
                            "Description = @IdCategoria, " +
                            "Name = @Descricao, " +
                            "UserAdministratorId = @UrlJogo, " +
                            "Active = @UrlVideoDemonstracao, " +
                            "Ativo = @Ativo, " +
                            "DataAtualizacao = GETDATE() WHERE [Id] = @Id";

                connection.Execute(query, new
                {
                    Description = championship.Description,
                    Name = championship.Name,
                    UserAdministratorId = championship.UserAdministratorId,
                    Active = championship.Active
                });
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"DELETE [dbo].[Championship] WHERE [Id] = @Id";

                connection.Execute(query, new
                {
                    Id = id
                });
            }
        }
    }
}

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
    public class GameRepository : IGameRepository
    {
        public IEnumerable<Game> GetAll()
        {
            using (var connection = new SqlConnection("Server=tcp:projetomackenzie.database.windows.net,1433;Initial Catalog=bancoprojeto;Persist Security Info=False;User ID=raizchefe;Password=gCvNFgXN@f5ttnV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connection.Open();

                string query = @"SELECT * FROM [dbo].[Championship]";

                return connection.Query<Game>(query).ToList();
            }
        }

        public Game GetById(long id)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                string query = @"SELECT * FROM [dbo].[Championship] WHERE [Id] = @Id";

                return connection.Query<Game>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public void Insert(Game game)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"INSERT INTO [dbo].[Game] (Description, Name, ChampionshipId, TeamAId, TeamBId, Result, Active, " +
                            "DataCriacao, DataAtualizacao)" +
                            "VALUES" +
                            "(@Description, @Name, @ChampionshipId, @TeamAId, @TeamBId, @Result, @Active, GETDATE(), GETDATE()" +
                            "GETDATE(), GETDATE())";

                connection.Execute(query, new
                {
                    Description = game.Description,
                    Name = game.Name,
                    ChampionshipId = game.ChampionshipId,
                    TeamAId = game.TeamAId,
                    TeamBId = game.TeamBId,
                    Result = game.Result,
                    Active = game.Active
                });
            }
        }

        public void Update(Game game)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"UPDATE [dbo].[Game] SET " +
                            "Description = @IdCategoria, " +
                            "Name = @Descricao, " +
                            "ChampionshipId = @UrlJogo, " +
                            "TeamAId = @Descricao, " +
                            "TeamBId = @UrlJogo, " +
                            "Active = @UrlVideoDemonstracao, " +
                            "DataAtualizacao = GETDATE() WHERE [Id] = @Id";

                connection.Execute(query, new
                {
                    Description = game.Description,
                    Name = game.Name,
                    ChampionshipId = game.ChampionshipId,
                    TeamAId = game.TeamAId,
                    TeamBId = game.TeamBId,
                    Active = game.Active
                });
            }
        }

        public void Delete(long id)
        {
            using (var connection = new SqlConnection(Settings.AdsDatabase))
            {
                connection.Open();

                var query = $"DELETE [dbo].[Game] WHERE [Id] = @Id";

                connection.Execute(query, new
                {
                    Id = id
                });
            }
        }
    }
}

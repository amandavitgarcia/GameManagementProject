using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Response.Game
{
    public class GameGetResponse
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name")]
        public long ChampionshipId { get; set; }

        [JsonProperty("Name")]
        public long TeamAId { get; set; }

        [JsonProperty("Name")]
        public long TeamBId { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        public static IEnumerable<GameGetResponse> CreateList(IEnumerable<ProjetoAds.Domain.Entities.Game> gameList)
        {
            if (gameList?.Count() == 0)
                return null;

            return gameList.Select(game => Create(game));
        }

        public static GameGetResponse Create(ProjetoAds.Domain.Entities.Game game)
        {
            if (game is null)
                return null;

            return new GameGetResponse()
            {
                Description = game.Description,
                Name = game.Name,
                ChampionshipId = game.ChampionshipId,
                TeamAId = game.TeamAId,
                TeamBId = game.TeamBId,
                Active = game.Active,
                CreateDate = game.CreateDate
            };
        }
    }
}

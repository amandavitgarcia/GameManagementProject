using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Response.Game
{
    public class GameOperationResponse
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        public static IEnumerable<GameOperationResponse> CreateList(IEnumerable<ProjetoAds.Domain.Entities.Game> gameList)
        {
            if (gameList?.Count() == 0)
                return null;

            return gameList.Select(game => Create(game));
        }

        public static GameOperationResponse Create(ProjetoAds.Domain.Entities.Game game)
        {
            if (game is null)
                return null;

            return new GameOperationResponse()
            {
                Description = game.Description
            };
        }
    }
}

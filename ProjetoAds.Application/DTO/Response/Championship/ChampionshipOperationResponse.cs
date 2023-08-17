using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Response.Championship
{
    public class ChampionshipOperationResponse
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        public static IEnumerable<ChampionshipOperationResponse> CreateList(IEnumerable<ProjetoAds.Domain.Entities.Championship> championshipList)
        {
            if (championshipList?.Count() == 0)
                return null;

            return championshipList.Select(championship => Create(championship));
        }

        public static ChampionshipOperationResponse Create(ProjetoAds.Domain.Entities.Championship championship)
        {
            if (championship is null)
                return null;

            return new ChampionshipOperationResponse()
            {
                Description = championship.Description
            };
        }
    }
}

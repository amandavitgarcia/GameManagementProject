using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Response.Championship
{
    public class ChampionshipGetResponse
    {
        [JsonProperty("UserAdministratorId")]
        public long UserAdministratorId { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        public static IEnumerable<ChampionshipGetResponse> CreateList(IEnumerable<ProjetoAds.Domain.Entities.Championship> championshipList)
        {
            if (championshipList?.Count() == 0)
                return null;

            return championshipList.Select(championship => Create(championship));
        }

        public static ChampionshipGetResponse Create(ProjetoAds.Domain.Entities.Championship championship)
        {
            if (championship is null)
                return null;

            return new ChampionshipGetResponse()
            {
                UserAdministratorId = championship.UserAdministratorId,
                Description = championship.Description,
                Name = championship.Name,
                Active = championship.Active,
                CreateDate = championship.CreateDate
            };
        }
    }
}

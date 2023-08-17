using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Request.Championship
{
    public class ChampionshipPostRequest
    {
        [JsonIgnore]
        public long UserAdministratorId { get; set; }

        [Required(ErrorMessage = "O Id da categoria é obrigatório.")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O Id da categoria é obrigatório.")]
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}

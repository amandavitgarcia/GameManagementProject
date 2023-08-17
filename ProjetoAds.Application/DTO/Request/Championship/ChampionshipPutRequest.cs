using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Request.Championship
{
    public class ChampionshipPutRequest : ChampionshipPostRequest
    {
        [Required(ErrorMessage = "O Id do camponato é obrigatório.")]
        [JsonProperty("Id")]
        public long Id { get; set; }
    }
}

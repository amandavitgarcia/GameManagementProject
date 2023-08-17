using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Request.Game
{
    public class GamePostRequest
    {
        [JsonIgnore]
        public long UserAdministratorId { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatória.")]
        [JsonProperty("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A nome do jogo é obrigatória.")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Id do campeonato é obrigatório.")]
        [JsonProperty("ChampionshipId")]
        public long ChampionshipId { get; set; }

        [Required(ErrorMessage = "O Id do time A é obrigatório.")]
        [JsonProperty("TeamAId")]
        public long TeamAId { get; set; }

        [Required(ErrorMessage = "O Id do time B é obrigatório.")]
        [JsonProperty("TeamBId")]
        public long TeamBId { get; set; }
    }
}

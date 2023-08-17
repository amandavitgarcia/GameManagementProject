using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.DTO.Request.Game
{
    public class GamePutRequest : GamePostRequest
    {
        [Required(ErrorMessage = "O Id do jogo é obrigatório.")]
        [JsonProperty("Id")]
        public long Id { get; set; }
    }
}

using ProjetoAds.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Entities
{
    public class Game : BaseEntity
    {
        public Game(long id, string description, string name, long championshipId, long teamAId, long teamBId)
        {
            Id = id;
            Description = description;
            Name = name;
            ChampionshipId = championshipId;
            TeamAId = teamAId;
            TeamBId = teamBId;
        }

        public Game(string description, string name, long championshipId, long teamAId, long teamBId)
        {
            Description = description;
            Name = name;
            ChampionshipId = championshipId;
            TeamAId = teamAId;
            TeamBId = teamBId;
        }

        public static Game CreateInstance(string description, string name, long championshipId, 
            long teamAId, long teamBId)
        {
            return new Game(description, name, championshipId, teamAId, teamBId);
        }

        public static Game CreateInstance(long id, string description, string name, long championshipId,
        long teamAId, long teamBId)
        {
            return new Game(id, description, name, championshipId, teamAId, teamBId);
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public long ChampionshipId { get; set; }
        public long TeamAId { get; set; }
        public long TeamBId { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public ResultGameEnum Result { get; set; }
    }
}

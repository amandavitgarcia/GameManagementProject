using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public Team()
        {

        }
    }
}

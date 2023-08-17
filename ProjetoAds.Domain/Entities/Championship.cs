using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Entities
{
    public class Championship : BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public long UserAdministratorId { get; set; }
        public User UserAdministrator { get; set; }

        public Championship(long id, string description, string name, long userAdministratorId)
        {
            Id = id;
            Description = description;
            Name = name;
            UserAdministratorId = userAdministratorId;
        }

        public Championship(string description, string name, long userAdministratorId)
        {
            Description = description;
            Name = name;
            UserAdministratorId = userAdministratorId;
        }

        public static Championship CreateInstance(string description, string name, long userAdministratorId)
        {
            return new Championship(description, name, userAdministratorId);
        }

        public static Championship CreateInstanceUpdate(long id, string description, string name, long userAdministratorId)
        {
            return new Championship(id, description, name, userAdministratorId);
        }
    }
}

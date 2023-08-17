using ProjetoAds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Service.Contracts
{
    public interface IGameService
    {
        IEnumerable<Game> GetAll();

        Game Get(long id);

        void Insert(Game championship);

        void Update(Game championship);

        void Delete(long id);
    }
}

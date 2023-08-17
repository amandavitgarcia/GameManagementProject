using ProjetoAds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Repository
{
    public interface IGameRepository
    {
        Game GetById(long id);

        IEnumerable<Game> GetAll();

        void Insert(Game game);

        void Update(Game game);

        void Delete(long id);
    }
}

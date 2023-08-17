using ProjetoAds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Repository
{
    public interface IChampionshipRepository
    {
        Championship GetById(long id);

        IEnumerable<Championship> GetAll();

        void Insert(Championship championship);

        void Update(Championship championship);

        void Delete(long id);
    }
}

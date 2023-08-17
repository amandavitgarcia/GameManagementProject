using ProjetoAds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Service.Contracts
{
    public interface IChampionshipService
    {
        IEnumerable<Championship> GetAll();

        Championship Get(long id);

        void Insert(Championship championship);

        void Update(Championship championship);

        void Delete(long id);
    }
}

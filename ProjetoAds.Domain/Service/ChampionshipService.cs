using ProjetoAds.Domain.Entities;
using ProjetoAds.Domain.Repository;
using ProjetoAds.Domain.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Domain.Service
{
    public class ChampionshipService : IChampionshipService
    {
        private readonly IChampionshipRepository _championshipRepository;

        public ChampionshipService(IChampionshipRepository championshipRepository)
        {
            _championshipRepository = championshipRepository;
        }

        public Championship Get(long id)
        {
            return _championshipRepository.GetById(id);
        }

        public IEnumerable<Championship> GetAll()
        {
            return _championshipRepository.GetAll();
        }

        public void Insert(Championship championship)
        {
            _championshipRepository.Insert(championship);
        }

        public void Update(Championship championship)
        {
            _championshipRepository.Update(championship);
        }

        public void Delete(long id)
        {
            _championshipRepository.Delete(id);
        }
    }
}

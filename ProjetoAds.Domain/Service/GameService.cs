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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Get(long id)
        {
            return _gameRepository.GetById(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public void Insert(Game game)
        {
            _gameRepository.Insert(game);
        }

        public void Update(Game game)
        {
            _gameRepository.Update(game);
        }

        public void Delete(long id)
        {
            _gameRepository.Delete(id);
        }
    }
}

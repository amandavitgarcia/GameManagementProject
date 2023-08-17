using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Game;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.Game;
using ProjetoAds.Domain.Entities;
using ProjetoAds.Domain.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.Application
{
    public class GameApplication : ApplicationBase<Game>, IGameApplication
    {
        private readonly IGameService _gameService;

        public GameApplication(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<BaseResponse<IEnumerable<GameGetResponse>>> GetAll()
        {
            var gameList = _gameService.GetAll();

            return await Task.Run(() =>
            {
                return GetBaseResponse<IEnumerable<GameGetResponse>>(GameGetResponse.CreateList(gameList));
            });
        }

        public async Task<BaseResponse<GameGetResponse>> Get(long id)
        {
            var game = _gameService.Get(id);

            return await Task.Run(() =>
            {
                return GetBaseResponse<GameGetResponse>(GameGetResponse.Create(game));
            });
        }

        public async Task<BaseResponse<GameOperationResponse>> Insert(GamePostRequest request)
        {
            return await Task.Run(() =>
            {
                var game = Game.CreateInstance(request.Description, request.Name, request.ChampionshipId, request.TeamAId, request.TeamBId);

                _gameService.Insert(game);

                return GetBaseResponse<GameOperationResponse>(GameOperationResponse.Create(game));
            });
        }

        public async Task<BaseResponse<GameOperationResponse>> Update(GamePutRequest request)
        {
            return await Task.Run(() =>
            {
                var game = Game.CreateInstance(request.Id, request.Description, request.Name, request.ChampionshipId, request.TeamAId, request.TeamBId);

                _gameService.Update(game);

                return GetBaseResponse<GameOperationResponse>(GameOperationResponse.Create(game));
            });
        }

        public async Task<BaseResponse<GameOperationResponse>> Delete(long id)
        {
            return await Task.Run(() =>
            {
                var championship = _gameService.Get(id);

                _gameService.Delete(championship.Id);

                return GetBaseResponse<GameOperationResponse>(GameOperationResponse.Create(championship));
            });
        }
    }
}

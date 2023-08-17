using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Championship;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.Championship;
using ProjetoAds.Domain.Entities;
using ProjetoAds.Domain.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.Application
{
    public class ChampionshipApplication : ApplicationBase<Championship>, IChampionshipApplication
    {
        private readonly IChampionshipService _championshipService;

        public ChampionshipApplication(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        public async Task<BaseResponse<IEnumerable<ChampionshipGetResponse>>> GetAll()
        {
            var championshipList = _championshipService.GetAll();

            return await Task.Run(() =>
            {
                return GetBaseResponse<IEnumerable<ChampionshipGetResponse>>(ChampionshipGetResponse.CreateList(championshipList));
            });
        }

        public async Task<BaseResponse<ChampionshipGetResponse>> Get(long id)
        {
            var championshipList = _championshipService.Get(id);

            return await Task.Run(() =>
            {
                return GetBaseResponse<ChampionshipGetResponse>(ChampionshipGetResponse.Create(championshipList));
            });
        }

        public async Task<BaseResponse<ChampionshipOperationResponse>> Insert(ChampionshipPostRequest request)
        {
            return await Task.Run(() =>
            {
                var championship = Championship.CreateInstance(request.Description, request.Name, request.UserAdministratorId);

                _championshipService.Insert(championship);

                return GetBaseResponse<ChampionshipOperationResponse>(ChampionshipOperationResponse.Create(championship));
            });
        }

        public async Task<BaseResponse<ChampionshipOperationResponse>> Update(ChampionshipPutRequest request)
        {
            return await Task.Run(() =>
            {
                var championship = Championship.CreateInstanceUpdate(request.Id, request.Description, request.Name, request.UserAdministratorId);

                _championshipService.Update(championship);

                return GetBaseResponse<ChampionshipOperationResponse>(ChampionshipOperationResponse.Create(championship));
            });
        }

        public async Task<BaseResponse<ChampionshipOperationResponse>> Delete(long id)
        {
            return await Task.Run(() =>
            {
                var championship = _championshipService.Get(id);

                _championshipService.Delete(championship.Id);

                return GetBaseResponse<ChampionshipOperationResponse>(ChampionshipOperationResponse.Create(championship));
            });
        }
    }
}

using ProjetoAds.Application.DTO.Request.Championship;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.Championship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.Contracts
{
    public interface IChampionshipApplication
    {
        Task<BaseResponse<IEnumerable<ChampionshipGetResponse>>> GetAll();
        Task<BaseResponse<ChampionshipGetResponse>> Get(long id);
        Task<BaseResponse<ChampionshipOperationResponse>> Insert(ChampionshipPostRequest request);
        Task<BaseResponse<ChampionshipOperationResponse>> Update(ChampionshipPutRequest request);
        Task<BaseResponse<ChampionshipOperationResponse>> Delete(long id);
    }
}

using ProjetoAds.Application.DTO.Request.Game;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAds.Application.Contracts
{
    public interface IGameApplication
    {
        Task<BaseResponse<IEnumerable<GameGetResponse>>> GetAll();
        Task<BaseResponse<GameGetResponse>> Get(long id);
        Task<BaseResponse<GameOperationResponse>> Insert(GamePostRequest request);
        Task<BaseResponse<GameOperationResponse>> Update(GamePutRequest request);
        Task<BaseResponse<GameOperationResponse>> Delete(long id);
    }
}

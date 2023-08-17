using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Game;
using ProjetoAds.Application.DTO.Response.Game;

namespace ProjetoAds.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameApplication _gameApplication;

        public GameController(IGameApplication gameApplication)
        {
            _gameApplication = gameApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gameList = await _gameApplication.GetAll();

            return BaseResponse<IEnumerable<GameGetResponse>>(gameList);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var game = await _gameApplication.Get(id);

            return BaseResponse<GameGetResponse>(game);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GamePostRequest request)
        {
            request.UserAdministratorId = Convert.ToInt64(GetUserLoggedInId());

            return BaseResponse<GameOperationResponse>(await _gameApplication.Insert(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GamePutRequest request)
        {
            request.UserAdministratorId = Convert.ToInt64(GetUserLoggedInId());

            return BaseResponse<GameOperationResponse>(await _gameApplication.Update(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return BaseResponse<GameOperationResponse>(await _gameApplication.Delete(id));
        }
    }
}

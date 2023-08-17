using Microsoft.AspNetCore.Mvc;
using ProjetoAds.Application.Contracts;
using ProjetoAds.Application.DTO.Request.Championship;
using ProjetoAds.Application.DTO.Response;
using ProjetoAds.Application.DTO.Response.Championship;

namespace ProjetoAds.Controllers
{
    public class ChampionshipController : BaseController
    {
        private readonly IChampionshipApplication _championshipApplication;

        public ChampionshipController(IChampionshipApplication championshipApplication)
        {
            _championshipApplication = championshipApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var championshipList = await _championshipApplication.GetAll();

            return BaseResponse<IEnumerable<ChampionshipGetResponse>>(championshipList);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var championship = await _championshipApplication.Get(id);

            return BaseResponse<ChampionshipGetResponse>(championship);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChampionshipPostRequest request)
        {
            request.UserAdministratorId = Convert.ToInt64(GetUserLoggedInId());

            return BaseResponse<ChampionshipOperationResponse>(await _championshipApplication.Insert(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ChampionshipPutRequest request)
        {
            request.UserAdministratorId = Convert.ToInt64(GetUserLoggedInId());

            return BaseResponse<ChampionshipOperationResponse>(await _championshipApplication.Update(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return BaseResponse<ChampionshipOperationResponse>(await _championshipApplication.Delete(id));
        }
    }
}

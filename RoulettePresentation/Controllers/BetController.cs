using AplicationServices.DTOs;
using AplicationServices.Services;
using DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoulettePresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBet betService;

        public BetController(IBet betService)
        {
            this.betService = betService;
            
        }


        [HttpGet("girar")]
        public IActionResult Get() 
        {
            try
            {
                var result = betService.CreateRandomNumberColor();

               

                return Ok(BaseResponse<RouletteDto>.OK(result));
            }
            catch (Exception)
            {

                return StatusCode(500, BaseResponse<string>.Fail("Error al girar la ruleta.")); ;
            }
        }

        [HttpPost("Jugar")]
        public  IActionResult MakeBet([FromBody] BetDto bet)
        {
            try
            {
                var result =  betService.MakeBet(bet);


                return Ok(BaseResponse<BetDto>.OK(result));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

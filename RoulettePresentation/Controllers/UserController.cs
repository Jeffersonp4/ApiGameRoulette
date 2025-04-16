using System.Security.Cryptography.X509Certificates;
using AplicationServices.DTOs;
using AplicationServices.Services;
using DataAccessLayer.Helpers;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoulettePresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userService;

        public UserController(IUser userService)
        {
            this.userService = userService;
        }



        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {

            try
            {
                
                var result = await userService.GetByName(name);

                if (result == null) 
                    return NotFound(BaseResponse<string>.Fail("Usuario no encontrado"));

                return Ok(BaseResponse<Users>.OK(result, "Usuario encontrado"));
                
            }
            catch (Exception)
            {

                return StatusCode(500, BaseResponse<string>.Fail("Error interno del servidor.")); ;
            }

         
        }
        
        [HttpPost("{SaveUser}")]
        public async Task<IActionResult> SaveUserBalance([FromBody] Users user)
        {
            if (User == null || string.IsNullOrWhiteSpace(user.name))
                return BadRequest(BaseResponse<string>.Fail("El nombre del usuario es obligatorio."));

            try
            {
                var result = await userService.CreateUser(user);
                return Ok(BaseResponse<Users>.OK(result, "Saldo actualizado correctamente."));
            }
            catch (ApplicationException msgError)
            {
                return BadRequest(BaseResponse<string>.Fail(msgError.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, BaseResponse<string>.Fail("Error interno del servidor."));
            }
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> Update(string name, [FromBody] Users user) 
        {
            if (User == null || string.IsNullOrWhiteSpace(user.name))
                return BadRequest(BaseResponse<string>.Fail("El nombre del usuario es obligatorio."));

            try
            {
                var result = await userService.CreateUser(user);



                return Ok(BaseResponse<Users>.OK(result, "Saldo Actualizado Correctamente"));
            }
            catch (ApplicationException msgError)
            {

                return BadRequest(BaseResponse<string>.Fail(msgError.Message)); 
            }
            catch (Exception)
            {
                return StatusCode(500, BaseResponse<string>.Fail("Error interno del servidor."));
            }
        }
    }
}

using Busiines.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO.Account;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountSupply _accountManager;

        public AccountController(IAccountSupply accountManager)
        {
            _accountManager = accountManager;
        }
        // GET: api/Account
        //  Userlari login yapar

  

        [AllowAnonymous]
        [HttpPost("user/authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest model)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Kullanıcı adı ve şifre gereklidir.");
            }

            var result = await _accountManager.Authenticate(model);
            if(result == null)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı.");
            }
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

    }
}

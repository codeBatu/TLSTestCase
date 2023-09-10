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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<Users>> Authenticate(Users model)
        {
            var user = await _accountManager.Authenticate(model);
         
            return Ok(user);
        }
    }
}

using Model;
using Model.DTO.Account;
using Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busiines.Abstract
{
    public interface IAccountSupply
    {
        IDataResult<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        public Task<Users> Authenticate(Users model);
    }
}

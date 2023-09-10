using AutoMapper;
using Busiines.Abstract;
using Microsoft.Extensions.Options;
using Model;
using Model.DTO.Account;
using Model.Result;
using Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busiines.Concrete
{
    public class AccountManager : IAccountSupply
    {
        private readonly IAccountRepository _accountDal;
      

        public AccountManager(IAccountRepository accountDal)
        {
            _accountDal = accountDal;
          
        }

        public async Task<Users> Authenticate(Users model)
        {
        var user =  await _accountDal.getUserByEmailAndPassword(model);

            return user;
        }

        public IDataResult<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }
    }

}

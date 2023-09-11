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
        private readonly IMapper _mapper;

        public AccountManager(IAccountRepository accountDal, IMapper mapper)
        {
            _accountDal = accountDal;
            _mapper = mapper;
        }

        public async Task<Users> Authenticate(Users model)
        {
        var user =  await _accountDal.getUserByUserNameAndPassword(model);

            return user;
        }

        public async Task< IDataResult<AuthenticateResponse>> Authenticate(AuthenticateRequest model)
        {
            var account = await _accountDal.getUserByUserName(model.UserName);
            if (account == null )
                return null;
            if (account.Password != model.Password)
                return null;
            var response = _mapper.Map<AuthenticateResponse>(account);
            return new Model.Result.DataResult<AuthenticateResponse>(response, true, "Login Successful");
        }

     
    }

}

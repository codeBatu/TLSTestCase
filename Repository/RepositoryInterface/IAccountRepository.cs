using Model;
using Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryInterface
{
    public interface IAccountRepository : IGenericRepository<Users, int>
    {
        Task<IDataResult<int>> Register(Users account);
        public Task<Users> getUserByEmailAndPassword(Users users);


    }
}

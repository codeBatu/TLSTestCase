using Microsoft.EntityFrameworkCore;
using Model;
using Model.Result;
using Repository.Models;
using Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TestCaseContext _context;

        public AccountRepository(TestCaseContext context)
        {
            _context = context;
        }
   
        // Useri username ve password gore getirir

        public async Task<Users> getUserByUserNameAndPassword (Users users)
        {
            var user = await _context.Users.Where(x => x.Username == users.Username && x.Password == users .Password).FirstOrDefaultAsync();
            if (user == null)
            {
                   return null;
            }

            return user;
           
        
        }
        // Useri username gore getirir
        public async Task<Users> getUserByUserName(string username)
        {
            var user = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            return user;


        }


        public Task<IDataResult<int>> Register(Users account)
        {
            throw new NotImplementedException();
        }
    }
}

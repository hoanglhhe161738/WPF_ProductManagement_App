using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountDAO AccountDAO = new AccountDAO();
        public int GetAccountMemberById(string accountMemberId, string password) => AccountDAO.GetAccountById(accountMemberId, password);
    }
}

using BusinessObjects;
using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo = new AccountRepository();
        public int GetAccountMember(string accountId, string password) => _accountRepo.GetAccountMemberById(accountId, password);
    }
}

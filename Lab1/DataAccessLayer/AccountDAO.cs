using BusinessObjects;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        public MyStoreContext _storeContext = new MyStoreContext();
        public int GetAccountById(string id, string password)
        {
            AccountMember accountMember = _storeContext.AccountMembers.Where(a => a.MemberId == id && a.MemberPassword == password).FirstOrDefault();
            if (accountMember == null) return -1;
            if (accountMember != null && accountMember.MemberRole != 1) return -2;
            return 1;
        }
    }
}

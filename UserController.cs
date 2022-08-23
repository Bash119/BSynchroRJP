using Microsoft.AspNetCore.Mvc;
using BSynchroRJP.Context;
using BSynchroRJP.Models;

namespace BSynchroRJP.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      private UserDBContext _dbuserContext;

        public UserController(UserDBContext userContext)
        {
            _dbuserContext = userContext;
        }

        // EndPoint1:Once the endpoint is called,
        // a new account will be opened connected to the user whose ID is
        // customerID.
         [HttpPost]
        public void AddUserAccount(int userid,decimal initialcredit)
        { 
            Account account = new Account();
            account.AccountId = userid;
            account.InitialCredit = initialcredit;
            account.balance = 0;
            
            if (initialcredit > 0)
            {
                Transaction tn=new Transaction();
                tn.AccountId = userid;
                tn.Amount = initialcredit;
                account.Transactions.Add(tn);
            }
            account.balance=account.balance+initialcredit;
            _dbuserContext.Accounts.Add(account);
            _dbuserContext.SaveChanges();

        }

        [HttpPost]
        public UserSheet OutputUserInfo(int userid)
        {
            UserSheet sheet = new UserSheet();
            var user=_dbuserContext.Users.FirstOrDefault(x=>x.UserId==userid);
            var acc = _dbuserContext.Accounts.FirstOrDefault(x => x.AccountId == userid);
            sheet.UserId = userid;
            sheet.Name = user.Name;
            sheet.Balance = acc.balance;
            sheet.Surname = user.Surname;
            sheet.Transactions = acc.Transactions;
            return sheet;
        }

    }
}

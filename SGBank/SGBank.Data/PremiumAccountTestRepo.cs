using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class PremiumAccountTestRepo : IAccountRepo
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            Balance = 100.00M,
            AccountNumber = "11111",
            accountType = AccountType.Premium

        };

        public Account LoadAccount(string AccountNumber)
        {
            if (AccountNumber != _account.AccountNumber)
            {
                return null;
            }
            else if (AccountNumber == _account.AccountNumber)
            {
                return _account;
            }

            else
            {
                throw new Exception("Input did not match known Accounts.");
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}

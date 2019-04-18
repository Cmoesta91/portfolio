using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTest
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase ("11111", "Premium Account", 100, AccountType.Premium, -50, false)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account() { AccountNumber = accountNumber, accountType = accountType, Balance = amount };
            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("11111", "Premium Account", 100, AccountType.Basic, -50, false)]
        [TestCase("11111", "Premium Account", 100, AccountType.Premium, 50, false)]
        [TestCase("11111", "Premium Account", 100, AccountType.Premium, -601, false)]
        [TestCase("11111", "Premium Account", 100, AccountType.Premium, -50, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRules();
            Account account = new Account() { AccountNumber = accountNumber, accountType = accountType, Balance = amount };
            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}

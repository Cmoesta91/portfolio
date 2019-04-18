using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class AccountMapper
    {
        public static Account ToAccount(string row)
        {
            Account a = new Account();
            string[] fields = row.Split(',');
            a.AccountNumber = fields[0];
            a.Name = fields[1];
            a.Balance = int.Parse(fields[2]);
            string type = fields[3];
            AccountType Bob = new AccountType(); 
            switch (type)
            {
                case "F":
                    Bob = AccountType.Free;
                    break;
                case "B":
                    Bob = AccountType.Basic;
                    break;
                case "P":
                    Bob = AccountType.Premium;
                    break;
            }
            a.accountType = Bob;
            return a;
        }

        public static string ToStringCSV(Account a)
        {
            string row = $"{a.AccountNumber},{a.Name},{a.Balance.ToString()},{a.accountType.ToString().Remove(1)}";

            return row;
        }
    }
}

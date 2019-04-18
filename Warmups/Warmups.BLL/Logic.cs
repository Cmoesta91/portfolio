using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars >= 40 && cigars <= 60 && isWeekend == false)
            {
                return true;
            }
            else if (cigars >= 40 && isWeekend == true)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle > 7 || dateStyle > 7)
            {
                return 2;
            }
            else if (yourStyle < 3 || dateStyle < 3)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp > 59 && temp < 101 && isSummer == true)
            {
                return true;
            }

            else if (temp > 59 && temp < 91 && isSummer == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (speed < 61)
            {
                return 0;
            }
            else if (speed < 66 && isBirthday == true)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        
        public int SkipSum(int a, int b)
        {
            if (a + b > 10 && a + b < 19)
            {
                return 20;
            }
            else
            {
                return a + b;
            }
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            
            if (day == 0 && day == 6 && vacation == true)
            {
                return "off";
            } 
            else if (day < 6 && day > 0 && vacation == false)
            {
                return "7:00";
            }
            else
            {
                return "10:00";
            }
        }
        
        public bool LoveSix(int a, int b)
        {
            if ( a == 6 || b == 6 || a + b == 6)
            {
                return true;
            }
            else if (a - b == 6 || b - a == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10 && outsideMode == false)
            {
                return true;
            }
            else if (n <= 1 || n >= 10 && outsideMode == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool SpecialEleven(int n)
        {

           if(n % 11 == 0 || n % 11 == 1)
           {
                return true;
           }
           else
           {
                return false;
           }
        }
        
        public bool Mod20(int n)
        {
            if(n % 20 == 1 || n % 20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod35(int n)
        {

            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            else if (n % 3 == 0 || n % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep == true)
            {
                return false;
            }
            else if (isMorning == true && isMom == true)
            {
                return true;
            }
            else if (isMorning == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || a + c == b || b + c == a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (b > a && b < c && bOk == false)
            {
                return true;
            }
            else if (b < c && bOk == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a < b && b < c && a < c && equalOk == false)
            {
                return true;
            }
            else if (a <= b && b <= c && a <= c && equalOk == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int modA = a % 10;
            int modB = b % 10;
            int modC = c % 10;

            if (modA == modB || modA == modC || modB == modC)
                return true;
            else
                return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles == true && die1 == 6 || die2 == 6)
            {
                return 1 + die2;
            }
            else if (noDoubles == true && die1 != die2)
            {
                return die1 + die2;
            }
            else if (noDoubles == true)
            {
                return die1 + die2 + 1;
            }
            else
            {
                return die1 + die2;
            }
            
        }

    }
}

using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
           return "<" + tag + ">" + content + "</" + tag + ">";

        }

        public string InsertWord(string container, string word) {

            return container.Substring(0,2) + word + container.Substring(2,2);
        }

        public string MultipleEndings(string str)
        {
             return str.Substring(str.Length-2) + str.Substring(str.Length - 2) + str.Substring(str.Length - 2); 
        }

        public string FirstHalf(string str)
        {
            return str.Remove(str.Length / 2);
        }

        public string TrimOne(string str)
        {
            string result = str.Substring(str.Length - 1);
            return str.Substring(1, str.Length - 2);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }

            else
                return a + b + a;
        }

        public string RotateLeft2(string str)
        {
            return str.Substring(2) + str.Substring(0, 2);
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2) + str.Remove(str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
               return str.Remove(1);
            }
            else
            {
               return str.Substring(str.Length -1);
            }
        }

        public string MiddleTwo(string str)
        {
            string newstrOne;
            string newStrTwo;
            newstrOne = str.Substring(str.Length / 2);
            newStrTwo = str.Remove(str.Length / 2);

            return newStrTwo.Substring(newStrTwo.Length - 1) + newstrOne.Remove(1);
        }

        public bool EndsWithLy(string str)
        {
            throw new NotImplementedException();
        }

        public string FrontAndBack(string str, int n)
        {
            throw new NotImplementedException();
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}

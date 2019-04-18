using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers[0] == numbers[numbers.Length -1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] MakePi(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if(a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int Sum(int[] numbers)
        {
            return numbers[0] + numbers[1] + numbers[2];
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            return numbers[];
        }
        
        public int[] Reverse(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] HigherWins(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

    }
}

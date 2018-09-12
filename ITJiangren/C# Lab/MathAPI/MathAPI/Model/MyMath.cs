using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MathAPI.Model
{
    public static class MyMath
    {
        public static long Fibonacci(int n)
        {
            long _result = 0;
            long f0 = 1;
            long f1 = 1;
            long f2 = 1;
            if (n < 93)
            {
                if (n > 0)
                {
                    if (n >= 3)
                    {
                        for (int i = 2; i < n; i++)
                        {
                            f2 = f0 + f1;
                            f0 = f1;
                            f1 = f2;
                        }
                    }
                    _result = f2;
                }


            }
            else
                _result = -1;//when n is bigger than 93;
            return _result;
        }

        public static string ReverseWords(string words)
        {
            if (words == null) return null;
            string[] wordsArray = words.Split(' ', StringSplitOptions.None);
            char[] singleWord;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                singleWord = wordsArray[i].ToArray();
                Array.Reverse(singleWord);
                wordsArray[i] = new string(singleWord);
            }
            Array.Reverse(wordsArray);

            return string.Join(" ", wordsArray);
        }

        public static string TriangleType(float a, float b, float c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
                return "wrong input!";

            else if (a == b && b == c)
                return "Equilateral";
            else if (a == b || b == c || a == c)
            {
                if (isRightTriangle(a, b, c))
                    return "Isosceles Right Triangle";
                else
                    return "Isosceles";
            }
            else if (isRightTriangle(a, b, c))
                return "Right Triangle";
            else
                return "Scalene";

        }

        private static bool isRightTriangle(float a, float b, float c)
        {
            //throw new NotImplementedException();
            
            return (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) 
                || Math.Pow(c, 2) + Math.Pow(b, 2) == Math.Pow(a, 2) 
                || Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2)) ? true : false;
        }
    }
}

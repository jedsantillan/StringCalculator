using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringCalculate
{
    public class Operators
    {

        public static bool isExpressionValid(ref string strInput, out string strAppMessage)
        {
            strAppMessage = "";
            string strTemp;

            if (string.IsNullOrEmpty(strInput))
            {
                strAppMessage = "User input is empty!";
                return false;
            }

            if (strInput.Length > 250)
            {
                strAppMessage = "Number of user input exceeded 250 characters";
                return false;
            }

            if (strInput.Contains(" "))
            {
                strInput = strInput.Replace(" ", "");
            }

            if (strInput.Contains("sqrt"))
            {
                strInput = strInput.Replace("sqrt", "√");
                strInput = strInput.Replace("(", "");
                strInput = strInput.Replace(")", "");
            }

            string[] numericalValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "√" };
            strTemp = strInput;
            bool boolStartsWith = numericalValues.Any(prefix => strTemp.StartsWith(prefix));
            
            if (!boolStartsWith)
            {
                strAppMessage = "Invalid Expression! It needs to begin with a number or square root operator";
                return false;
            }
            
            numericalValues[10] = " ";           
            bool boolEndsWith = numericalValues.Any(suffix => strTemp.EndsWith(suffix));
            
            if (!boolEndsWith)
            {
                strAppMessage = "Invalid Expression! It needs to end with a number";
                return false;
            }

            if (!Regex.IsMatch(strInput, "^[-0-9+*/^√ ]+$"))
            {
                strAppMessage = "Invalid Expression! Valid user input are Numbers, +, -, *, /, ^ and sqrt";
                return false;
            }

            if (!Regex.IsMatch(strInput, "[-+*/^√]"))
            {
                strAppMessage = "Invalid Expression! User input contains non-mathematical operators";
                return false;
            }

            return true;
        }


        public static double processExpression(List<char> listOperator, List<double> listNumber)
        {
            int nIndex = 0;
            double Result = 0;
            List<int> listIndex = new List<int>(); ;

            if (listOperator.Contains('√'))
            {
                while (listOperator.Contains('√'))
                {
                    nIndex = operatorInstance('√', ref listOperator);
                    listNumber[nIndex] = (fSquareRoot(listNumber[nIndex]));
                }
            }

            if (listOperator.Contains('^'))
            {
                while (listOperator.Contains('^'))
                {
                    nIndex = operatorInstance('^', ref listOperator);
                    listNumber[nIndex] = (fExponent(listNumber[nIndex], listNumber[nIndex + 1]));
                    listNumber.RemoveRange(nIndex + 1, 1);
                }
            }

            if (listOperator.Contains('/'))
            {
                while (listOperator.Contains('/'))
                {
                    nIndex = operatorInstance('/', ref listOperator);
                    listNumber[nIndex] = (fDivide(listNumber[nIndex], listNumber[nIndex + 1]));
                    listNumber.RemoveRange(nIndex + 1, 1);
                }
            }

            if (listOperator.Contains('*'))
            {
                while (listOperator.Contains('*'))
                {
                    nIndex = operatorInstance('*', ref listOperator);
                    listNumber[nIndex] = (fMultiply(listNumber[nIndex], listNumber[nIndex + 1]));
                    listNumber.RemoveRange(nIndex + 1, 1);
                }
            }

            if (listOperator.Contains('-'))
            {
                while (listOperator.Contains('-'))
                {
                    nIndex = operatorInstance('-', ref listOperator);
                    listNumber[nIndex] = (fSubtract(listNumber[nIndex], listNumber[nIndex + 1]));
                    listNumber.RemoveRange(nIndex + 1, 1);
                }
            }

            if (listOperator.Contains('+'))
            {
                while (listOperator.Contains('+'))
                {
                    nIndex = operatorInstance('+', ref listOperator);
                    listNumber[nIndex] = (fAdd(listNumber[nIndex], listNumber[nIndex + 1]));
                    listNumber.RemoveRange(nIndex + 1, 1);
                }
            }

            Result = listNumber[0];
            return Result;
        }

        public static int operatorInstance(char cOperator, ref List<char> listOperator)
        {
            int index = 0;

            index = listOperator.IndexOf(cOperator);
            listOperator.RemoveRange(index, 1);

            return index;
        }

        public static double fAdd(double a, double b)
        {
            return a + b;
        }

        public static double fSubtract(double a, double b)
        {
            return a - b;
        }

        public static double fMultiply(double a, double b)
        {
            return a * b;
        }

        public static double fDivide(double a, double b)
        {
            return a / b;
        }

        public static double fSquareRoot(double a)
        {
            return Math.Sqrt(a);
        }

        public static double fExponent(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}

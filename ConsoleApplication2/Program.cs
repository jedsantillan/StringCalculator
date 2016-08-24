using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculate
{
    class Program
    {  
        public static void Main(string[] args)
        {
            String strInput = null, strMessage = null;
            List<string> lValue;
            List<char> operatorUsed;
            List<double> lParsedValue;
            char[] delimiter = new char[] { '+', '-', '*', '/', '^', '√' };
            ConsoleKeyInfo consoleKey;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter expression: ");

                strInput = Console.ReadLine();

                // Validates the user input
                if (Operators.isExpressionValid(ref strInput, out strMessage))
                {
                    //Creates a list of numeric values
                    lValue = strInput.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();

                    //Parses the string values to double
                    parseList(lValue, out lParsedValue);

                    //Creates a list of operators
                    makeOperatorList(strInput, out operatorUsed);
                    Console.ForegroundColor = ConsoleColor.Green;

                    try
                    {
                        Console.WriteLine("Answer: {0}", Operators.processExpression(operatorUsed, lParsedValue));
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Expression! User Input is an Invalid Math Expression");
                    }
                    Console.ResetColor();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(strMessage);
                    Console.ResetColor();
                }
                Console.WriteLine("Please key in 'y' to enter new expression");
                consoleKey = Console.ReadKey();
            } while (consoleKey.KeyChar == 'y' || consoleKey.KeyChar == 'Y');
        }

        private static void makeOperatorList(string strInput, out List<char> listOperator)
        {
            listOperator = new List<char>();

            for (int i = 0; i < strInput.Length; i++)
            {
                if (strInput[i] == '+' || strInput[i] == '-' || strInput[i] == '*' || strInput[i] == '/' || strInput[i] == '^' || strInput[i] == '√')
                {
                    listOperator.Add(strInput[i]);
                }
            }
        }

        private static void parseList(List<string> listValue, out List<double> listNumValue)
        {
            listNumValue = new List<double>();
            foreach (var temp in listValue)
            {
                listNumValue.Add(double.Parse(temp));
            }
        }
    }
}

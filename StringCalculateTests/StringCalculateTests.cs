using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculate;
using System.Collections.Generic;


namespace StringCalculateTests
{
    [TestClass]
    public class StringCalculateTests
    {
        [TestMethod]
        public void isExpressionValid_ValidInput()
        {
            //Arrange
            bool actualFlag, expectedFlag = true;
            string strActualInput, strExpectedInput, strAppMessage;
            strActualInput = "sqrt(256) - 10 / 5 * 2 + 3 ^ 2";
            strExpectedInput = "√256-10/5*2+3^2";
            //Act
            actualFlag = Operators.isExpressionValid(ref strActualInput, out strAppMessage);

            //Assert
            Assert.AreEqual(expectedFlag, actualFlag);
            Assert.AreEqual(strExpectedInput, strActualInput);
        }

        [TestMethod]
        public void isExpressionValid_InvalidInput_AlphabetString()
        {
            bool actualFlag, expectedFlag = false;
            string strActualInput, strExpectedInput, strAppMessage;
            strActualInput = "10 / 5 * 2 + 2 ^ 2 - 6 + 15a * 2 - sqrt(256)";
            strExpectedInput = "10/5*2+2^2-6+15a*2-√256";

            actualFlag = Operators.isExpressionValid(ref strActualInput, out strAppMessage);
            Assert.AreEqual(expectedFlag, actualFlag);
            Assert.AreEqual(strExpectedInput,strActualInput);
        }

        [TestMethod]
        public void isExpressionValid_InvalidInput_NullAndInvalidCharacter()
        {
            bool actualFlag, expectedFlag = false;
            string strActualNullInput="", strExpectedNull="", strActualInvalidChar, strExpectedInput, strAppMessage;
            strActualInvalidChar = "10/ 5*2+(2^2)-6+15a*2=";
            strExpectedInput = "10/5*2+(2^2)-6+15a*2=";

            actualFlag = Operators.isExpressionValid(ref strActualNullInput, out strAppMessage);
            Assert.AreEqual(expectedFlag, actualFlag);
            Assert.AreEqual(strExpectedNull, strActualNullInput);

            actualFlag = Operators.isExpressionValid(ref strActualInvalidChar, out strAppMessage);
            Assert.AreEqual(strExpectedInput, strActualInvalidChar);
            Assert.AreEqual(expectedFlag, actualFlag);
        }

        [TestMethod]
        public void processExpression_ValidInput()
        {
            //Arrange
            List<double> listNumber;
            List<char> listOperator;
            double  actualOutput, expectedOutput = 25;
            listOperator = new List<char>() {'+','*','-','√','-','/','*','+','^'};
            listNumber = new List<double>() {6,15,2,256,10,5,2,3,2};

            //Act
            actualOutput = Operators.processExpression(listOperator, listNumber);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);      
        }
    }
}

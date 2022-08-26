using NUnit.Framework;
using System;

namespace CalculatorApp.Test
{
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("")]
        public void ShouldAddEmptyStringResultZero(string numbers)
        {
            //Act
            var stringCalculator = new StringCalculator();

            //Arrange
            var result = stringCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(0));   
        }

        [TestCase("1")]
        public void ShouldAddSingleNumber(string numbers)
        {
            //Act
            var stringCalculator = new StringCalculator();

            //Arrange
            var result = stringCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [TestCase("1,2")]
        public void ShouldAddTwoNumbers(string numbers)
        {
            //Act
            var stringCalculator = new StringCalculator();

            //Arrange
            var result = stringCalculator.Add(numbers);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [TestCase(3, "1,2")]
        [TestCase(6, "1,2,3")]
        [TestCase(12, "1,2,4,5")] 
        public void ShouldAddManyNumbers(int result, string numbers)
        {
            //Act
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }

        [TestCase(13, "1\n1,2,4,5")]
        public void ShouldAddManyNumbersWithNewLine(int result, string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }

        [TestCase(1, "1,\n")]
        public void ShouldAddManyNumbersWithNewLineTwo(int result, string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }

        [TestCase(3, "//;\n1;2")]
        public void ShouldAddManyNumbersWithDelimeter(int result, string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }

        [TestCase("//;\n1;-2")]
        [TestCase("//;\n1;2;-2;1")]
        [TestCase("//;\n1;2;-2;-1")]
        public void ShouldAddManyNumbersWithNegative(string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Assert
            Assert.Throws<ArgumentException>(() => stringCalculator.Add(numbers));
        }

        [TestCase(3, "//;\n1;2;1001")]
        public void ShouldAddAvoidOneThousand(int result, string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }

        //
        [TestCase(6, "//[***]\n1***2***3")]
        public void ShouldAddNumbersUnknownDelimeter(int result, string numbers)
        {
            //Act 
            var stringCalculator = new StringCalculator();

            //Arrange
            var resultAdd = stringCalculator.Add(numbers);

            //Assert
            Assert.That(resultAdd, Is.EqualTo(result));
        }
    }
}
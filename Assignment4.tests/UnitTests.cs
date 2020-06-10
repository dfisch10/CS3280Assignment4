using System.Diagnostics.CodeAnalysis;
using Xunit;
using Assignment_4.Services;

using System.Collections.Generic;
using Assignment_4.Displays;
using System;

namespace Assignment_4.tests
{
    [ExcludeFromCodeCoverage]
    public class UnitTests
    {
        [Theory]
        [MemberData(nameof(AddData))]
        public void Add_VariousQuanitityOfNumbersInputted_ReturnsValid(double expectedResult, params double[] operands)
        {
            var sut = new Calculator();

            var actual = sut.Add(operands);

            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> AddData => new List<object[]>
        {
            new object[] {15, new double[] { 5, 10 } },
            new object[] {7, new double[] { -2, 9 } },
            new object[] {-30, new double[] { -23, -7 } },
            new object[] {-36, new double[] { -15, -21 } },
           new object[] {269, new double[] { 100, 55, 45, 69 } },
            new object[] {203, new double[] { 100, 0, 42, 8, 53} },
            new object[] { 649898, new double[] { 98574, 551324 } },
            new object[] {0, new double[] { 0, 0 } },
        };


        [Theory]
        [MemberData(nameof(SubtractData))]
        public void Subtract_VariousQuanitityOfNumbersInputted_ReturnsValid(double expectedResult, params double[] operands)
        {
            var sut = new Calculator();

            var actual = sut.Subtract(operands);

            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> SubtractData => new List<object[]>
        {
            new object[] {5, new double[] { 10, 5 } },
            new object[] {11, new double[] {9, -2 } },
            new object[] {-37, new double[] { -7, 30 } },
            new object[] {-6, new double[] {-21, -15} },
            new object[] {347, new double[] {500, 15, 85, 53} },
            new object[] {44, new double[] {-21, -15, -100, 50} },
            new object[] {452750, new double[] { 551324, 98574 } },
            new object[] {0, new double[] { 0, 0 } }
        };

        [Theory]
        [MemberData(nameof(MultiplyData))]
        public void Multiply_VariousQuanitityOfNumbersInputted_ReturnsValid(double expectedResult, params double[] operands)
        {
            var sut = new Calculator();

            var actual = sut.Multiply(operands);

            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> MultiplyData => new List<object[]>
        {
            new object[] { 50, new double[] { 10, 5 } },
            new object[] {-18, new double[] { 9, -2 } },
            new object[] {-210, new double[] { -30, 7 } },
            new object[] { 315, new double[] { -21, -15} },
            new object[] { 1200, new double[] { 5, 4, 5, 12 } },
            new object[] { 5238816, new double[] { 984, 5324 } },
            new object[] { 100, new double[] { 2, 5, 10 } },
            new object[] { 0, new double[] { 0, 0, 0 } }
        };

        [Theory]
        [MemberData(nameof(DivideData))]
        public void Divide_VariousQuanitityOfNumbersInputted_ReturnsValid(double expectedResult, params double[] operands)
        {
            var sut = new Calculator();

            var actual = sut.Divide(operands);

            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> DivideData => new List<object[]>
        {
            new object[] {2, new double[] { 10, 5 } },
            new object[] {-3, new double[] {9, -3} },
            new object[] {5, new double[] {-30, -6} },
            new object[] {1, new double[] { -21, -21 } },
            new object[] {984, new double[] { 98400, 100 } },
            new object[] {0.02, new double[] { 55, 5, 11, 50 } },
            new object[] {615, new double[] { 98400, 5, 4, 8 } },
            new object[] { 31.142857142857142, new double[] { 654, 21 } },
            new object[] { 5.5, new double[] { 55, 10 } },
            new object[] {"NaN", new double[] { 0, 0, 0 } }
        };

        
        [Theory]
        [MemberData(nameof(CheckUserInputData))]
        public void CheckUserInput_UserOptionOneThroughFiveInputted_ReturnsValid(string input, List<string> inputOptions)
        {
            var actual = DisplayUtility.CompareUserInputToAcceptedOptionsList(input, inputOptions);

            Assert.True(actual);
        }

        public static IEnumerable<object[]> CheckUserInputData => new List<object[]>
        { 

            new object[] {"1", new List<string>{"1", "2", "3", "4", "5"}},
            new object[] {"2", new List<string>{"1", "2", "3", "4", "5"}},
            new object[] {"3", new List<string>{"1", "2", "3", "4", "5"}},
            new object[] {"4", new List<string>{"1", "2", "3", "4", "5"}},
            new object[] {"5", new List<string> {"1", "2", "3", "4", "5" }}        
        };

        [Theory]
        [MemberData(nameof(ConvertStringToIntData))]
        public void ConvertStringToInt_UserMenuOptionsPassedAndIntValueReturned_ReturnsValid(string input, int expectedResult)
        {
            var actual = DisplayUtility.ConvertStringToInt(input);

            Assert.Equal(actual, expectedResult);
        }

        public static IEnumerable<object[]> ConvertStringToIntData => new List<object[]>
        {

            new object[] {"1", 1},
            new object[] {"2", 2},
            new object[] {"3", 3},
            new object[] {"4", 4},
            new object[] {"5", 5}
        };
    }
}
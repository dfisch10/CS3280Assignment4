using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace Assignment_4.Services
{
    public class Calculator : ICalculator
    {

        /// <summary>
        /// Takes an array of double type operands that the user inputs, and then returns their sum.
        /// </summary>
        /// <param name="operands">An array of double type numeric values.</param>
        /// <returns>Returns the sum of all the numbers.</returns>
        public double Add(params double[] operands)
        {
            checkForInvalidAndNullOrEmptyValuesForOperands(operands);

            var result = operands.Sum();

            return result;
        }

        /// <summary>
        /// Takes an array of double type operands that the user inputs, and then returns the difference.
        /// </summary>
        /// <param name="operands">An array of double type numeric values.</param>
        /// <returns>Returns the difference of all the numbers.</returns>
        public double Subtract(params double[] operands)
        {
            checkForInvalidAndNullOrEmptyValuesForOperands(operands);

            double result = 0;

            int counter = 1;

            foreach(double operand in operands)
            {
                if(counter == 1)
                {
                    result = operand;
                }
                else
                {
                    result -= operand;
                }
                counter++; 
            }

            return result;
        }

        /// <summary>
        /// Takes an array of double type operands that the user inputs, and then returns their product.
        /// </summary>
        /// <param name="operands">An array of double type numeric values.</param>
        /// <returns>Returns the product of all the numbers.</returns>
        public double Multiply(params double[] operands)
        {
            checkForInvalidAndNullOrEmptyValuesForOperands(operands);

            double result = 1;

            foreach(double operand in operands)
            {
                result = result * operand;
            }

            return result;
        }

        /// <summary>
        /// Takes an array of double type operands that the user inputs, and then returns thei quotient.
        /// </summary>
        /// <param name="operands">An array of double type numeric values.</param>
        /// <returns>Returns the quotient of all the numbers.</returns>
        public double Divide(params double[] operands)
        {
            checkForInvalidAndNullOrEmptyValuesForOperands(operands);

            double result = 1;

            int counter = 1;

            foreach (double operand in operands) 
            {
                if(counter == 1)
                {
                    result = operand; 
                }
                else
                {
                    result /= operand;
                }
                counter++;
            }

            return result;
        }

        /// <summary>
        /// Takes the array of operands passed into the method, and checks to ensure that the array is not empty/null, and that the input is able to be of type double.
        /// </summary>
        /// <param name="operands">An array of double type numeric values.</param>
        [ExcludeFromCodeCoverage]
        private static void checkForInvalidAndNullOrEmptyValuesForOperands(double[] operands)
        {
            double toDouble = 0;
            string input = Convert.ToString(operands);
            bool canConvert = double.TryParse(input, out toDouble);

            if (string.IsNullOrEmpty(input) || canConvert == false)
            {
                Console.WriteLine("You may only have numeric values of type double entered, and no null/empty values accepted, please try again");
            }
        }
    }

   /// <summary>
   /// Calculator Interface
   /// </summary>
   internal interface ICalculator
    {
    }
}


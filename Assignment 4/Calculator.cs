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
    }
}


using Assignment_4.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Assignment_4.Displays
{
    public class DisplayUtility
    {
        /// <summary>
        /// This method displays the Menu options, and activates the appropriate option/methods depending on the user Input.
        /// </summary>
        /// <param name="menuRecall">Initialized at true and then returns true/false depending if the menu should be recalled or not after selection made (or if calculator object is null).</param>
        /// <param name="calculator">Generates a Calculator object to utilize calculator methods (add, subtract, multiply, and divide) as part of user input handling.</param>
        [ExcludeFromCodeCoverage]
        public static void Menu(out bool menuRecall, Calculator calculator)
        {  
            if( calculator is null)
            {
                menuRecall = false;

                return;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1) add");
            Console.WriteLine("2) subtract");
            Console.WriteLine("3) multiply");
            Console.WriteLine("4) divide");
            Console.WriteLine("5) Exit Application");
           
           menuRecall = handleUserInput(calculator);
        }

        /// <summary>
        /// Changes user inputs, which are in string format due to Console.ReadLine(), and then converts them to int type
        /// </summary>
        /// <param name="input">The string input that is entered by the user at prompt.</param>
        /// <returns>Converts and returns the user inputted string value as type int.</returns>
        public static int ConvertStringToInt(string input)
        {
            return Convert.ToInt32(input);
        }

        /// <summary>
        /// Compares the user's input, to a list of acceptable options, based off of the menu options (1-5), then returns if the input is valid or not (true or false).
        /// </summary>
        /// <param name="input">The string input that is entered by the user at prompt.</param>
        /// <param name="inputOptions">The List of valid inputs allowed to activate the menu options.</param>
        /// <returns>Returns true/false depending on if the user inputted value is on of the accepted values from the valid input options.</returns>
        public static bool CompareUserInputToAcceptedOptionsList(string input, List<string> inputOptions)
        {
            return inputOptions.Contains(input);
        }

       /// <summary>
       /// Determines what cases/procedures to run based off of the option the user selected from the menu. Also throws error message if value entered is null, or not one of the accepted case values.
       /// </summary>
       /// <param name="calculator">Object creation to utilize/call the Calculator class methods dependent on which option was chosen.</param>
       /// <returns>Returns true/false based of the user inputted menu option to determine if the menu should be recalled or not.</returns>
       [ExcludeFromCodeCoverage]
        private static bool handleUserInput(Calculator calculator)
        {
            if (calculator is null)
            {
                return false;
            }

            var option = receiveMenuOption();

            switch (option)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    var operand1 = receiveUserInputForOperand();
                    var operand2 = receiveUserInputForOperand();

                    switch (option)
                    {
                        case 1:
                            outputDisplay(calculator.Add(operand1, operand2));

                            break;

                        case 2:
                            outputDisplay(calculator.Subtract(operand1, operand2));

                            break;

                        case 3:
                            outputDisplay(calculator.Multiply(operand1, operand2));

                            break;

                        case 4:
                            outputDisplay(calculator.Divide(operand1, operand2));

                            break;
                    }
                    Console.WriteLine();

                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return false;
                default:
                    string errorMessage = "You did not enter a valid entry, please try again using options 1-5.";

                    errorMessageDisplay(errorMessage);

                    break;
            }
            return true;
        }

        /// <summary>
        /// Takes in the user input after the menu prompt, and checks it against the valid input options. Throws error message if not one of the valid optioons.
        /// </summary>
        /// <returns>Returns converted user input from string type to int type, or throws error message if input was invalid.</returns>
        [ExcludeFromCodeCoverage]
        private static int receiveMenuOption()
        {
            Console.Write("\r\nPlease select an option: ");

            var inputOptions = new List<string> { "1", "2", "3", "4", "5" };

            string input = Console.ReadLine();

            if (!CompareUserInputToAcceptedOptionsList(input, inputOptions))
            {
                var errorMessage = "The only valid inputs are 1-5, please try again.";

                errorMessageDisplay(errorMessage);

                return receiveMenuOption();
            }
            return ConvertStringToInt(input);
        }

        /// <summary>
        /// Checks the user inputted values for the mathematical operands to ensure they are not null/empty, and that they only entered numerical characters. Then converts the input to type int and returns it.
        /// </summary>
        /// <returns>Returns converted user input from string type to int type for entered operands, or throws error message if input was invalid.</returns>
        [ExcludeFromCodeCoverage]
        private static double receiveUserInputForOperand()
        {
            int toInt = 0;

            string input = receiveInput();

            bool canConvert = int.TryParse(input, out toInt);

            if (string.IsNullOrEmpty(input))
            {
                const string errorMessage = "You can not enter a null/empty value, please try again.";
                errorMessageDisplay(errorMessage);
                return receiveUserInputForOperand();
            }
            else if (canConvert == false)
            {
                const string errorMessage2 = "You can only enter numeric character, please try again.";
                errorMessageDisplay(errorMessage2);
                return receiveUserInputForOperand();
            }
            else
            {
                return ConvertStringToInt(input);
            }
        }

        /// <summary>
        /// Changes the foreground color of the answer line to Cyan, then resets the console color back to default after displaying the answer line.
        /// </summary>
        /// <param name="result"> The resulting sum, difference, product, or quotient after the two operands have utilized the specified mathmatical operator. </param>
        [ExcludeFromCodeCoverage]
        private static void outputDisplay(double result)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Your answer is: " + result);

            Console.ResetColor();
        } 

       /// <summary>
       /// Takes in the user input for the menu options.
       /// </summary>
       /// <returns>Returns the user input as a string type via Console.ReadLine()</returns>
       [ExcludeFromCodeCoverage]
        private static string receiveInput()
        {
            Console.Write("Please enter a number: ");
            
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays a custom error message that is passed into the method, and changes the foreground color of that message to dark red. It then resets the console foreground color to its default after being displayed. 
        /// </summary>
        /// <param name="errorMessage">A custom string type message passed into the method.</param>
        [ExcludeFromCodeCoverage]
        private static void errorMessageDisplay(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}

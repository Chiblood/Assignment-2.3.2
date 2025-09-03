/* Assignment 2.3.2
2. Design a tip calculator: enter the bill total, tip % and display grand total after adding tip.

Use the format specifiers to display currency, % symbol.
*/
using System;

namespace Assignment232
{
    public class Program
    {
        /// <summary>
        /// Prompts the user for input and ensures a non-empty string is returned.
        /// </summary>
        /// <param name="prompt">The message to display to the user.</param>
        /// <returns>A non-null, non-whitespace string from the user.</returns>
        private static string GetRequiredString(string prompt)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        /// <summary>
        /// Prompts the user for input, validates it, and converts it to the specified type `T`.
        /// See https://learn.microsoft.com/en-us/aspnet/core/blazor/components/generic-type-support?view=aspnetcore-9.0 for more details.
        /// </summary>
        /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
        /// <param name="prompt">The message to display to the user.</param>
        /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
        /// <returns>A valid value of type `T` from the user.</returns>
        private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
        {
            T? value;
            while (!T.TryParse(GetRequiredString(prompt), null, out value)) // Calls GetUserInput() to get the raw user input first.
            {
                Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
            }
            return value;
        }

        public static void Main(string[] args)
        {

            decimal billTotal = GetUserInput<decimal>("Enter the bill total: ", "What is that? Please enter a valid amount.");

            decimal tipPercentage = GetUserInput<decimal>("Enter the tip rate percentage (e.g., 15 for 15%): ");

            decimal tipAmount = billTotal * (tipPercentage / 100);
            decimal grandTotal = billTotal + tipAmount;

            Console.WriteLine($"Tip Amount: {tipAmount:C}");
            Console.WriteLine($"Grand Total: {grandTotal:C}");
        }
    }
}
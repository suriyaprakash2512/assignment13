using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();


            int wordCount = CountWords(inputText);
            Console.WriteLine("\nWord Count: {0}", wordCount);


            List<string> emailAddresses = ValidateEmailAddresses(inputText);
            if (emailAddresses.Count > 0)
            {
                Console.WriteLine("\nEmail Addresses:");
                foreach (string emailAddress in emailAddresses)
                {
                    Console.WriteLine("- {0}", emailAddress);
                }
            }
            else
            {
                Console.WriteLine("\nNo valid email addresses found.");
            }


            List<string> mobileNumbers = ExtractMobileNumbers(inputText);
            if (mobileNumbers.Count > 0)
            {
                Console.WriteLine("\nMobile Numbers:");
                foreach (string mobileNumber in mobileNumbers)
                {
                    Console.WriteLine("- {0}", mobileNumber);
                }
            }
            else
            {
                Console.WriteLine("\nNo mobile numbers found.");
            }


            Console.WriteLine("\nEnter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            MatchCollection matches = Regex.Matches(inputText, customRegexPattern);
            if (matches.Count > 0)
            {
                Console.WriteLine("\nCustom Regex Matches:");
                foreach (Match match in matches)
                {
                    Console.WriteLine("- {0}", match.Value);
                }
            }
            else
            {
                Console.WriteLine("\nNo matches found for the custom regular expression.");
            }
        }

        // Method to count the number of words in a string
        static int CountWords(string inputText)
        {

            string[] words = inputText.Split(' ', ',', '.', '?', '!', '-');
            int wordCount = 0;
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    wordCount++;
                }
            }
            return wordCount;
        }

        // Method to validate email addresses in a string
        static List<string> ValidateEmailAddresses(string inputText)
        {
            // Regex pattern for validating email addresses
            Regex emailRegex = new Regex(@"^([^\s]+)@([^\s]+)\.([^\s]+)$");
            MatchCollection matches = emailRegex.Matches(inputText);

            // Extract valid email addresses from the matches
            List<string> emailAddresses = new List<string>();
            foreach (Match match in matches)
            {
                string emailAddress = match.Value;
                if (!emailAddresses.Contains(emailAddress))
                {
                    emailAddresses.Add(emailAddress);
                }
            }
            return emailAddresses;
        }

        // Method to extract mobile numbers from a string
        static List<string> ExtractMobileNumbers(string inputText)
        {
            // Regex pattern for extracting mobile numbers (10 digits)
            Regex mobileNumberRegex = new Regex(@"(\d{10})");
            MatchCollection matches = mobileNumberRegex.Matches(inputText);

            // Extract mobile numbers from the matches
            List<string> mobileNumbers = new List<string>();
            foreach (Match match in matches)
            {
                string mobileNumber = match.Value;
                if (!mobileNumbers.Contains(mobileNumber))
                {
                    mobileNumbers.Add(mobileNumber);
                }
            }
            return mobileNumbers;



        }

    }
}

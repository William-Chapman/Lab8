using System;
using System.Text.RegularExpressions;

namespace Lab8
{
    class Program
    {
        static void Main()
        {
            string[] studentList = { "John", "Mary", "Bill", "Christine", "Jack", "Kate", "Andrew", "Heather", "Frank", "Nancy" };
            string[] ages = { "20", "25", "29", "24", "35", "43", "19", "32", "23", "21" };
            string[] hometowns = { "Detroit", "Livonia", "Redford", "Canton", "Plymouth", "Pontiact", "Brownstown", "Flat Rock", "Ann Arbor", "Lansing" };

            do
            {
                string userNum = Ask("Which student would you like to learn about? (1-10)", @"^(1|2|3|4|5|6|7|8|9|10)$", "Please ensure the number is between 1 and 10.").ToLower();
                string userQuestion = Ask($"What would you like to know about {studentList[int.Parse(userNum) - 1]}? (age or hometown)", @"^\b(age|hometown)\b$", "Please ensure you are entering a proper option.").ToLower();
                WriteInfo(userNum, userQuestion, studentList[int.Parse(userNum) - 1], ages[int.Parse(userNum) - 1], hometowns[int.Parse(userNum) - 1]);
            }
            while (Continue() == 1);
        }

        static string Ask(string question, string pattern, string errorMessage)
        {
            string response;
            do
            {
                Console.WriteLine(question);
                response = Console.ReadLine();
                if (!Regex.IsMatch(response, pattern))
                {
                    Console.WriteLine(errorMessage);
                }
            }
            while (!Regex.IsMatch(response, pattern));
            return response;
        }

        static void WriteInfo(string userNum, string userQuestion, string name, string age, string hometown)
        {
            if(userQuestion == "age")
            {
                Console.WriteLine($"Student #{userNum} is {name}. They are {age} years old");
            }
            else if(userQuestion == "hometown")
            {
                Console.WriteLine($"Student #{userNum} is {name}. They are from {hometown}.");
            }
        }

        static int Continue()
        {
            string response;
            int situ = 3;
            while (situ == 3)
            {
                Console.WriteLine("Continue ? (y/n): ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    //if yes, restart at main
                    situ = 1;
                }
                else if (response == "n" || response == "no")
                {
                    //if no, exit
                    situ = 0;
                }
                else if (response != "n" || response != "no" || response != "y" || response != "yes")
                {
                    situ = 3;
                }

                if (situ == 3)
                {
                    Console.WriteLine("Please enter valid response.");
                }
            }
            return situ;
        }
    }
}
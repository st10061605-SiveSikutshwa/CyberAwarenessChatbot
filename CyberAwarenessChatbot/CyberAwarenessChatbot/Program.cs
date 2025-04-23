using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CyberAwarenessChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===================================================");
            Console.WriteLine("              WELCOME TO CYBERSECURITY BOT");
            Console.WriteLine("===================================================");
            Console.ResetColor();

            // Play voice greeting
            PlayGreeting();

            // Display ASCII art
            ShowAsciiArt();

            // Get user name
            Console.Write("\nPlease enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            DisplayResponse($"Hello, {name}! I'm your Cybersecurity Awareness Assistant.");

            // Chat loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nAsk me something (or type 'exit'): ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayResponse("I didn’t catch that. Please type a question.");
                    continue;
                }

                if (input == "exit")
                {
                    DisplayResponse("Thank you for using the Cybersecurity Awareness Bot. Stay safe online!");
                    break;
                }

                RespondToUser(input);
            }
        }

        static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/welcome.wav");
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Audio greeting failed to play: " + ex.Message);
                Console.ResetColor();
            }
        }

        static void ShowAsciiArt()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string art = File.ReadAllText("Assets/ascii_logo.txt");
                Console.WriteLine(art);
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] ASCII logo not found.");
                Console.ResetColor();
            }
        }

        static void RespondToUser(string input)
        {
            if (input.Contains("how are you"))
            {
                DisplayResponse("I'm just a bot, but I'm ready to help you stay secure online!");
            }
            else if (input.Contains("purpose"))
            {
                DisplayResponse("I'm here to teach you about cybersecurity and help you stay safe on the internet.");
            }
            else if (input.Contains("ask") || input.Contains("topics"))
            {
                DisplayResponse("You can ask me about password safety, phishing, or safe browsing.");
            }
            else if (input.Contains("password"))
            {
                DisplayResponse("Use long, unique passwords with letters, numbers, and symbols. Avoid using the same password twice.");
            }
            else if (input.Contains("phishing"))
            {
                DisplayResponse("Watch out for suspicious emails or messages asking for personal information. Never click on unknown links.");
            }
            else if (input.Contains("safe browsing"))
            {
                DisplayResponse("Avoid visiting untrusted websites. Use secure connections and always log out of accounts when done.");
            }
            else
            {
                DisplayResponse("I didn’t quite understand that. Could you rephrase?");
            }
        }

        // Helper: Display response with green color
        static void DisplayResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"> {message}");
            Console.ResetColor();
        }

        // Helper: Typing effect (optional usage)
        static void TypeOut(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}

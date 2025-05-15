using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CyberAwarenessChatbot
{
    class Program
    {
        // This dictionary links keywords (like "password", "scam", "privacy") to specific cybersecurity tips.
        // It helps the bot recognize what topic the user is asking about and reply with the right message.

        static Dictionary<string, string> keywordResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "password", "Tip: Use strong, unique passwords for every account. Avoid using personal information." },
            { "scam", "Tip: Be cautious of messages requesting personal info. Scammers often pretend to be trusted companies." },
            { "privacy", "Tip: Regularly review your privacy settings on social media and other platforms." }
        };


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

        // This method takes the user's input and helps the bot decide how to respond.
        // It first checks for general questions, then tries to match keywords from the dictionary.
        // If no match is found, it shows a default response.
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
                DisplayResponse("You can ask me about password safety, phishing, scams, or privacy settings.");
            }
            else
            {
                bool keywordFound = false;
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        DisplayResponse(keywordResponses[keyword]);
                        keywordFound = true;
                        break;
                    }
                }

                if (!keywordFound)
                {
                    DisplayResponse("I didn’t quite understand that. Could you rephrase?");
                }
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

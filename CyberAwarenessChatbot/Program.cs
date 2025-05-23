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

        static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "password", new List<string>
                {
                    "Tip: Use long, unique passwords for each account.",
                    "Tip: Never reuse the same password on multiple websites.",
                    "Tip: Avoid using personal info like birthdays or names in passwords."
                }
            },
            { "scam", new List<string>
                {
                    "Tip: Be cautious of emails or messages asking for urgent action.",
                    "Tip: Scammers often pretend to be trusted companies.",
                    "Tip: Always verify a link before clicking on it."
                }
            },
            { "privacy", new List<string>
                {
                    "Tip: Check your social media privacy settings often.",
                    "Tip: Don’t overshare personal details online.",
                    "Tip: Disable location tracking unless you need it."
                }
            },
            { "phishing", new List<string>
                {
                    "Tip: Don’t click links from unknown senders.",
                    "Tip: Check for spelling mistakes in emails — it’s often a sign of phishing.",
                    "Tip: Legit companies will never ask for your password by email."
                }
            }
        };

        // This stores the user's name and interest for later use
        static string userName = "";
        static string userInterest = "";



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
            //Console.Write("\nPlease enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine();
            //DisplayResponse($"Hello, {name}! I'm your Cybersecurity Awareness Assistant.");

            //
            userName = Console.ReadLine();
            Console.WriteLine();
            DisplayResponse($"Hello, {userName}! I'm your Cybersecurity Awareness Assistant.");


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

        // This method processes user input by first checking for casual conversation, then scanning for cybersecurity keywords.
        // If a keyword is found, it responds with a random relevant tip.

        static void RespondToUser(string input)
        {
            // Step 1: Handle general or small-talk responses
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

            // Check if the user mentions a topic of interest
            else if (input.Contains("interested in"))
            {
                int index = input.IndexOf("interested in") + "interested in".Length;
                if (index < input.Length)
                {
                    userInterest = input.Substring(index).Trim();
                    DisplayResponse($"Great! I'll remember that you're interested in {userInterest}.");
                }
                else
                {
                    DisplayResponse("Thanks for sharing! Could you tell me which topic you're interested in?");
                }
            }

            // If the user wants the bot to recall what they said earlier
            else if (input.Contains("what do you remember") || input.Contains("my interest"))
            {
                if (!string.IsNullOrEmpty(userInterest))
                {
                    DisplayResponse($"You told me you're interested in {userInterest}, {userName}. That's a smart focus!");
                }
                else
                {
                    DisplayResponse("I don’t think you've told me what you're interested in yet.");
                }
            }


            else
            {
                // Step 2: Look for keywords related to cybersecurity
                bool keywordFound = false;

                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        // Get the list of tips for the matched keyword
                        var tips = keywordResponses[keyword];

                        // Pick one tip at random using the Random class
                        Random rand = new Random();
                        string selectedTip = tips[rand.Next(tips.Count)];

                        // Display the randomly selected tip
                        DisplayResponse(selectedTip);

                        keywordFound = true;
                        break; // Stop after first match
                    }
                }

                // Step 3: Handle unknown or unsupported input
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

# Cybersecurity Awareness Chatbot

A beginner-friendly console chatbot designed to teach South African citizens about online safety and cybersecurity.

---

## F E A T U R E S 

### Part 1: Foundation
- Voice greeting (plays on startup)
- ASCII art logo
- Personalized name greeting
- Colored console UI
- Input validation with fallback messaging
- GitHub Actions CI workflow enabled

### Part 2: Interactive Improvements
- **Keyword Recognition**: Detects topics like `password`, `scam`, `privacy`, `phishing`
- **Random Responses**: Varies replies to keep conversations fresh
- **User Memory**: Remembers your name and your cybersecurity interest
- **Sentiment Detection**: Responds empathetically to moods like “worried” or “curious”
- **Improved Conversation Flow**: Maintains session context naturally

---

## How to Run

1. Clone or download the repo
2. Open the solution in Visual Studio (ensure `.NET 6.0+`)
3. Place the following files inside the `Assets/` folder:
   - `welcome.wav` (voice greeting)
   - `ascii_logo.txt` (ASCII art logo)
4. Press `F5` or run via terminal

---

## GitHub CI

This project uses **GitHub Actions** to:
- Automatically build the solution on each push
- Flag syntax or build errors early

Make sure your code builds clean before submission.

---

## Folder Structure

CyberAwarenessChatbot/
??? Assets/
? ??? welcome.wav
? ??? ascii_logo.txt
??? Program.cs
??? CyberAwarenessChatbot.csproj
??? README.md


---

## ?? Educational Impact

This bot supports national cybersecurity awareness efforts by simulating realistic Q&A and teaching users how to protect themselves online — all while helping the developer practice real-world programming patterns.

---


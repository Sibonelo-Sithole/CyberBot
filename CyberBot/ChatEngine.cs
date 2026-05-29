using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberBot
{
    public class ChatEngine
    {
        private Random random = new Random();

        // memory variables

        private string userName = "";
        private string interest = "";

        // keyword response lists

        private List<string> passwordTips = new List<string>()
        {
            "Use strong passwords with letters, numbers and symbols.",
            "Never reuse the same password across different accounts.",
            "Avoid using personal information like your name or birthdate.",
            "Consider using a password manager for safety.",
            "Enable two-factor authentication where possible."
        };

        private List<string> scamTips = new List<string>()
        {
            "Be careful of messages asking for urgent action or money.",
            "Scammers often pretend to be trusted companies.",
            "Do not click unknown or suspicious links.",
            "If it feels too good to be true, it probably is.",
            "Always verify requests before sharing any personal details."
        };

        private List<string> phishingTips = new List<string>()
        {
            "Always check email addresses carefully before clicking links.",
            "Phishing emails often try to create urgency.",
            "Never enter passwords on unknown websites.",
            "Look for spelling mistakes or unusual domains.",
            "Be cautious of emails asking you to 'verify' your account."
        };

        private List<string> privacyTips = new List<string>()
        {
            "Review your privacy settings regularly.",
            "Do not share too much personal information online.",
            "Only accept requests from people you trust.",
            "Limit app permissions on your devices.",
            "Be careful what you post on social media."
        };

        //main method to process user input and generate responses

        public string ProcessMessage(string input)
        {
            input = input.ToLower();

            // ---------------- MEMORY: NAME ----------------
            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();
                return "Nice to meet you " + userName + "! I will remember your name.";
            }

            if (input.Contains("who am i"))
            {
                if (userName != "")
                    return "You are " + userName + ". Stay safe online!";
                else
                    return "I don’t know your name yet. Please tell me your name.";
            }

            // ---------------- MEMORY: INTEREST ----------------
            if (input.Contains("i like"))
            {
                interest = input.Replace("i like", "").Trim();
                return "Got it! I will remember that you are interested in " + interest + ".";
            }

            // password keywords
            if (input.Contains("password") || input.Contains("login") || input.Contains("pass"))
            {
                return "🔐 Password Tip: " + GetRandom(passwordTips);
            }

            // scam keywords
            if (input.Contains("scam") || input.Contains("fraud") || input.Contains("fake"))
            {
                return "⚠️ Scam Tip: " + GetRandom(scamTips);
            }

            // phishing keywords
            if (input.Contains("phishing") || input.Contains("email") || input.Contains("link"))
            {
                return "🎣 Phishing Tip: " + GetRandom(phishingTips);
            }

            // privacy keywords
            if (input.Contains("privacy") || input.Contains("data") || input.Contains("personal info"))
            {
                return "🔒 Privacy Tip: " + GetRandom(privacyTips);
            }

            // personalised fallback (memory usage)
            if (userName != "")
            {
                return "I’m not sure about that " + userName + ". Try asking about passwords, scams, phishing or privacy.";
            }

            return "I’m not sure I understand. Try asking about passwords, scams, phishing or privacy.";
        }

        //helper method to get a random tip from a list

        private string GetRandom(List<string> list)
        {
            return list[random.Next(list.Count)];
        }
    }
}
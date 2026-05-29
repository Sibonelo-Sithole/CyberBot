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
        private string lastTopic = "";

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

            // ---------------- SENTIMENT DETECTION ----------------

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                return "It's okay to feel that way. Cybersecurity can be confusing, but I will help you stay safe.\n🔐 " + GetRandom(passwordTips);
            }

            if (input.Contains("confused") || input.Contains("lost") || input.Contains("dont understand"))
            {
                return "No worries, I will explain it simply. Try asking about passwords, scams, phishing or privacy.";
            }

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
            {
                return "I understand your frustration. Let’s take it step by step and keep it simple.";
            }

            if (input.Contains("curious") || input.Contains("interested"))
            {
                return "Great! Curiosity helps keep you safe online. What would you like to learn about?";
            }

            // memory: name
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

            // memory: interest
            if (input.Contains("i like"))
            {
                interest = input.Replace("i like", "").Trim();
                return "Got it! I will remember that you are interested in " + interest + ".";
            }

            if (input.Contains("what do i like") || input.Contains("what am i interested in"))
            {
                if (interest != "")
                    return "You are interested in " + interest + ".";
                else
                    return "I don’t know yet. Tell me what you like by saying 'I like ...'.";
            }

            // topic-based responses with contextual follow-up

            if (input.Contains("password") || input.Contains("login") || input.Contains("pass"))
            {
                lastTopic = "password";
                return "🔐 Password Tip: " + GetRandom(passwordTips);
            }

            if (input.Contains("scam") || input.Contains("fraud") || input.Contains("fake"))
            {
                lastTopic = "scam";
                return "⚠️ Scam Tip: " + GetRandom(scamTips);
            }

            if (input.Contains("phishing") || input.Contains("email") || input.Contains("link"))
            {
                lastTopic = "phishing";
                return "🎣 Phishing Tip: " + GetRandom(phishingTips);
            }

            if (input.Contains("privacy") || input.Contains("data") || input.Contains("personal info"))
            {
                lastTopic = "privacy";
                return "🔒 Privacy Tip: " + GetRandom(privacyTips);
            }

            //contextual follow-up for more advice on the last topic
            if (input.Contains("tell me more") || input.Contains("explain more") || input.Contains("more"))
            {
                if (lastTopic == "password")
                    return "🔐 More Password Advice: " + GetRandom(passwordTips);

                if (lastTopic == "scam")
                    return "⚠️ More Scam Advice: " + GetRandom(scamTips);

                if (lastTopic == "phishing")
                    return "🎣 More Phishing Advice: " + GetRandom(phishingTips);

                if (lastTopic == "privacy")
                    return "🔒 More Privacy Advice: " + GetRandom(privacyTips);

                return "Please ask me about a topic first like password, scam, phishing or privacy.";
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
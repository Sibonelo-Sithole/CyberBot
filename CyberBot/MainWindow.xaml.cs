using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace CyberBot
{
    public partial class MainWindow : Window
    {
        ChatEngine engine = new ChatEngine();
        private string userName;

        public MainWindow()
        {
            InitializeComponent();

            new SoundGreet();

            // welcome message when app starts
            AddMessage("Hello! I am your Cybersecurity Awareness Bot.", false);
        }

        // this runs when user submits their name
        private void submit_name(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            userName = username.Text.Trim();

            username_grid.Visibility = Visibility.Hidden;
            background_grid.Visibility = Visibility.Visible;

            
        }

        // when user sends a message
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                AddMessage("Please type something before sending.", false);
                return;
            }

            // show user message
            AddMessage(input, true);

            // get bot response from engine
            string response = engine.ProcessMessage(input);

            // show bot message
            AddMessage(response, false);

            inputBox.Clear();
        }

        // allows user to press Enter instead of clicking send
        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendButton_Click(sender, e);
            }
        }

        // this is just to format chat messages nicely
        private void AddMessage(string message, bool isUser)
        {
            Paragraph paragraph = new Paragraph();

            Run text = new Run(message);

            if (isUser)
            {
                text.Foreground = Brushes.LightGreen;
                paragraph.Inlines.Add("You: ");
            }
            else
            {
                text.Foreground = Brushes.Cyan;
                paragraph.Inlines.Add("Bot: ");
            }

            paragraph.Inlines.Add(text);

            chatBox.Document.Blocks.Add(paragraph);

            chatBox.ScrollToEnd();
        }
    }
}
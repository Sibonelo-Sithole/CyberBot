using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window    
    {
        ChatEngine engine = new ChatEngine(); // ADD THIS
        private string userName;

        public MainWindow()
        {
            InitializeComponent();
            new SoundGreet();

            
        }

        private void submit_name(object sender, RoutedEventArgs e)
        {

            userName = username.Text;

            username_grid.Visibility = Visibility.Hidden;

            background_grid.Visibility = Visibility.Visible;

            chatBox.Text = "Bot: Hello " + userName + "! Welcome to Cybersecurity Bot.\n";
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {

            string input = inputBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                chatBox.Text += "\nBot: Please type something.";
                return;
            }

            chatBox.Text += "\nYou: " + input;

            string response = engine.ProcessMessage(input);

            chatBox.Text += "\nBot: " + response + "\n";

            inputBox.Clear();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberBot
{
    public class SoundGreet
    {

        public SoundGreet()
        {//start of constructor

            string auto_path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net8.0-windows\", @"\greet.wav");

            //create an instance for the SoundPlayer class
            SoundPlayer greetMe = new SoundPlayer(auto_path);

            //then greet 
            greetMe.Play();
        }


    }
}

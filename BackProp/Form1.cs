using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackProp
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        string [] words;
        int[] bagofwords = new int[25];
        string[] testwords = { "sandwich", "have", "a", "how", "for", "are", "good", "make", "me", "it", "day", "soon", "nice", "later", "going", "you", "today", "can", "lunch", "is", "see", "to", "talk", "what","goodbye" };

    
        public Form1()
        {
            InitializeComponent();
        }

        private void createNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(25, 150, 3);

        }

        private void Learn1 ( string classifier, string sentence)
        {
            words = sentence.ToLower().Split(' ');
            foreach (var word in words)
            {
                //Console.WriteLine(word);
                for (int i = 0; i < 25; i++)
                {
                    if (word == testwords[i])
                    {
                        bagofwords[i] += 1;
                    }
                }
            }

            for (int i = 0; i < 25; i++)
            {
                nn.setInputs(i, Convert.ToDouble(bagofwords[i]));
            }

            if (classifier == "greeting")
            {
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
            }
            else if (classifier == "goodbye")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
            }

            else if (classifier =="lunch")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
            }
            nn.learn();
            for (int i= 0; i < 25; i++)
            {
               //Console.WriteLine(bagofwords[i]);
                bagofwords[i] = 0;
            }
        }
        private void Learn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                //greetings
                Learn1("greeting", "how are you");
                Learn1("greeting", "how is your day");
                Learn1("greeting", "good day");
                Learn1("greeting", "how is it going today");

                //goodbye
                Learn1("goodbye", "have a nice day");
                Learn1("goodbye", "see you later");
                Learn1("goodbye", "goodbye");
                Learn1("goodbye", "talk to you soon");

                //lunch
                Learn1("lunch", "make me a sandwich");
                Learn1("lunch", "can you make a sandwich");
                Learn1("lunch", "having a sandwich today");
                Learn1("lunch", "what's for lunch");
            }

        }
            /*for (int i = 0; i < 1000; i++)
            {
                //Love
                nn.setInputs(0, 1.0);
                nn.setInputs(1, 0.0);
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.learn();
                //hate
                nn.setInputs(0, 0.0);
                nn.setInputs(1, 1.0);
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.learn();
            }
            */
        

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                
                bagofwords[i] = 0;
            }
            words = textBox1.Text.ToLower().Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(word);
                for (int i = 0; i < 25; i++)
                {
                    if (word == testwords[i])
                    {
                        bagofwords[i] += 1;
                    }
                }
                //System.Console.WriteLine($"<{word}>");

            }
            

            for (int i = 0; i < 25; i++)
            {
                nn.setInputs(i, Convert.ToDouble(bagofwords[i]));
            }
            //nn.setInputs(0, Convert.ToDouble(bagofwords[0]));
            //nn.setInputs(1, Convert.ToDouble(bagofwords[1]));
            nn.run();
            /*label2.Text = " " + nn.getOuputData(0) + " , " + nn.getOuputData(1);
            if (nn.getOuputData(0) > 0.6 && nn.getOuputData(1) < 0.4)
            {
                label1.Text = "Greeting: ";
                
            }

            else if (nn.getOuputData(0) < 0.4 && nn.getOuputData(1) > 0.6)
            {
                label1.Text = "Goodbye: ";
            }

            else if (nn.getOuputData(0) < 0.4 && nn.getOuputData(1) < 0.4)
            {
                label1.Text = "Lunch";
            }
            */
          
            /* for (int i=0; i<3;i++)
                 if (nn.getOuputData(i) > 0.3)
                 {
                     if (i == 0)
                     {
                         label1.Text = "\nGreeting: " + nn.getOuputData(i).ToString();
                     }
                     else if (i == 1)
                     {
                         label1.Text += "\nGoodbye: " + nn.getOuputData(i).ToString();
                     }
                     else
                     {
                         label1.Text += "\nLunch: " + nn.getOuputData(i).ToString();
                     }
                     //label1.Text = "Greeting: " + nn.getOuputData(0).ToString();
                 }
                 */
            //if (nn.getOuputData(1) > 0.6
            label1.Text = "greeting: " + nn.getOuputData(0).ToString();
            label2.Text = "goodbye: " + nn.getOuputData(1).ToString();
            label3.Text = "lunch: " + nn.getOuputData(2).ToString();

            /* if (nn.getOuputData(0) == 1)
            {
                label1.Text = "Hate";
            }

            else if (nn.getOuputData(0) == 0)
            {
                label1.Text = "Love";
            }
            */

            //label1.Text = "Love: " + bagofwords[0].ToString() + " Hate: " + bagofwords[1].ToString();
        }

       
    }
}

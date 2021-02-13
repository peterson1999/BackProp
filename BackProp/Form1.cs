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
        int[] bagofwords = { 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        private void createNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(2, 20, 2);

        }

        private void Learn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bagofwords[0]= 0;
            bagofwords[0] = 0;
            words = textBox1.Text.ToLower().Split(' ');
            foreach (var word in words)
            {
                //System.Console.WriteLine($"<{word}>");
                if (word =="hate")
                {
                    bagofwords[1]+=1;
                }
                else if(word =="love")
                {
                    bagofwords[0] +=1;
                }
            }

            nn.setInputs(0, Convert.ToDouble(bagofwords[0]));
            nn.setInputs(1, Convert.ToDouble(bagofwords[1]));
            nn.run();
            label1.Text = "Love: " + nn.getOuputData(1).ToString();
            label2.Text = "Hate: " + nn.getOuputData(0).ToString();
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

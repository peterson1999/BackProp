using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        int[] bagofwords;
        string[] testwords;//= { "sandwich", "have", "a", "how", "for", "are", "good", "make", "me", "it", "day", "soon", "nice", "later", "going", "you", "today", "can", "lunch", "is", "see", "to", "talk", "what","goodbye" };
        IDictionary<string, string> d = new Dictionary<string, string>();
        HashSet<string> allWords = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            string path = @"D:\Dev\IS\BackProp\train2.txt";
            string content = "";
            string[] train,ws;
            StreamReader sr = File.OpenText(path);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();
                train = content.ToLower().Split(';');
                d.Add(train[0], train[1]);
            }
            foreach(var word in d.Keys)
            {
                ws = word.ToLower().Split(' ');
                foreach (var w in ws)
                {
                    if (w == "i" || w == "am")
                    {
                        continue;
                    }

                    else
                    {
                        allWords.Add(w);
                        //Console.WriteLine(w);
                    }
                       
                }
               
            }
            bagofwords = new int[allWords.Count];
            testwords = allWords.ToArray();
           
            //Console.WriteLine(bagofwords.Length);
        }

        private void createNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(allWords.Count, allWords.Count*3, 6);

        }

        private void LearnSentences( string classifier, string sentence)
        {
            words = sentence.ToLower().Split(' ');
            foreach (var word in words)
            {
                for (int i = 0; i < bagofwords.Length; i++)
                {
                    if (word == testwords[i])
                    {
                        bagofwords[i]++;
                    }
                }
            }

            for (int i = 0; i < bagofwords.Length; i++)
            {
                nn.setInputs(i, Convert.ToDouble(bagofwords[i]));
            }

            if (classifier == "sadness")
            {
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.setDesiredOutput(5, 0.0);
            }
            else if (classifier == "joy")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.setDesiredOutput(5, 0.0);
            }

            else if (classifier =="love")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.setDesiredOutput(5, 0.0);
            }
            else if (classifier == "surprise")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);
                nn.setDesiredOutput(5, 0.0);
            }
            else if (classifier == "anger")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);
                nn.setDesiredOutput(5, 0.0);
            }
            else if (classifier == "fear")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
                nn.setDesiredOutput(5, 1.0);
            }
            //LEARN
            nn.learn();
            for (int i= 0; i < bagofwords.Length; i++)
            {
                bagofwords[i] = 0;
            }
        }
        private void Learn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                foreach(var set in d)
                {
                    LearnSentences(set.Value, set.Key);
                }
                Console.WriteLine("Progress:" + i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bagofwords.Length; i++)
            {
                
                bagofwords[i] = 0;
            }
            words = textBox1.Text.ToLower().Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(word);
                for (int i = 0; i < bagofwords.Length; i++)
                {
                    if (word == testwords[i])
                    {
                        bagofwords[i] += 1;
                    }
                }

            }
            

            for (int i = 0; i < bagofwords.Length; i++)
            {
                nn.setInputs(i, Convert.ToDouble(bagofwords[i]));
            }
            nn.run();
            
            //if (nn.getOuputData(1) > 0.6
            label1.Text = "sadness: " + nn.getOuputData(0).ToString();
            label2.Text = "joy: " + nn.getOuputData(1).ToString();
            label3.Text = "love: " + nn.getOuputData(2).ToString();
            label4.Text = "surprise: " + nn.getOuputData(3).ToString();
            label5.Text = "anger: " + nn.getOuputData(4).ToString();
            label6.Text = "fear: " + nn.getOuputData(5).ToString();
        }

        private void saveWeightsDialog_FileOk(object sender, CancelEventArgs e)
        {
            nn.saveWeights(saveWeightsDialog.FileName);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveWeightsDialog.ShowDialog();
        }
    }
}

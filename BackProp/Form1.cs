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
        const string bot = "J.A.M.E.S: ";
        const string you = "You: ";
        string [] words;
        int[] bagofwords;
        string[] testwords;//= { "sandwich", "have", "a", "how", "for", "are", "good", "make", "me", "it", "day", "soon", "nice", "later", "going", "you", "today", "can", "lunch", "is", "see", "to", "talk", "what","goodbye" };
        IDictionary<string, string> d = new Dictionary<string, string>();
        HashSet<string> allWords = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
            string path = @"C:\Users\Peterson\Downloads\greetings.txt";
            string path1 = @"C:\Users\Peterson\Downloads\farewells.txt";
            string content = "";
            string[] train,ws;
            StreamReader sr = File.OpenText(path);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();
                
                d.Add(content.ToLower(), "greeting");
            }

            sr= File.OpenText(path1);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();

                d.Add(content.ToLower(), "farewell");
            }
            foreach (var word in d.Keys)
            {
                ws = word.ToLower().Split(' ');
                foreach (var w in ws)
                {
                    

                    
                        allWords.Add(w);
                        //Console.WriteLine(w);
                    

                }

            }

            
            bagofwords = new int[allWords.Count];
            testwords = allWords.ToArray();
            Console.WriteLine("bow:"+bagofwords.Length.ToString()+" ,tw:"+testwords.Length.ToString());
            for (int i = 0; i < bagofwords.Length; i++)
            {
                Console.WriteLine(testwords[i]);
            }
            //Console.WriteLine(bagofwords.Length);
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

            if (classifier == "greeting")
            {
                nn.setDesiredOutput(0, 1.0);
                nn.setDesiredOutput(1, 0.0);
            }
            else if (classifier == "farewell")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
 
            }

 
            //LEARN
            nn.learn();
            for (int i= 0; i < bagofwords.Length; i++)
            {
                bagofwords[i] = 0;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bagofwords.Length; i++)
            {
                
                bagofwords[i] = 0;
            }
            words = messageBox.Text.ToLower().Split(' ');
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
            //label1.Text = "greeting: " + nn.getOuputData(0).ToString();
            //label2.Text = "farewell: " + nn.getOuputData(1).ToString();

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            nn.loadWeights(openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveWeightsDialog.ShowDialog();
        }
        private void saveWeightsDialog_FileOk(object sender, CancelEventArgs e)
        {
            nn.saveWeights(saveWeightsDialog.FileName);
        }

        private void createBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(allWords.Count, allWords.Count * 2, 2);
        }

        private void teachBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; i++)
            {
                foreach (var set in d)
                {
                    LearnSentences(set.Value, set.Key);

                }
                Console.WriteLine("Progress:" + i);
            }
        }
    }
}

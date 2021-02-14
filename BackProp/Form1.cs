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
        private readonly Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            string path = @"C:\Users\Peterson\Downloads\greetings.txt";
            string path1 = @"C:\Users\Peterson\Downloads\farewells.txt";
            string path2 = @"C:\Users\Peterson\Downloads\complaints.txt";
            string path3 = @"C:\Users\Peterson\Downloads\order.txt";
            string path4 = @"C:\Users\Peterson\Downloads\inquiries.txt";
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

            sr = File.OpenText(path2);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();

                d.Add(content.ToLower(), "complaint");
            }
            sr = File.OpenText(path3);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();

                d.Add(content.ToLower(), "order");
            }
            sr = File.OpenText(path4);
            while ((content = sr.ReadLine()) != null)
            {
                //content = sr.ReadLine();

                d.Add(content.ToLower(), "inquiry");
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

        private void createNNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(allWords.Count, allWords.Count*2, 5);

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
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);
            }
            else if (classifier == "farewell")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 1.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);

            }
            else if (classifier == "complaint")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 1.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 0.0);

            }
            else if (classifier == "order")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 1.0);
                nn.setDesiredOutput(4, 0.0);

            }
            else if (classifier == "inquiry")
            {
                nn.setDesiredOutput(0, 0.0);
                nn.setDesiredOutput(1, 0.0);
                nn.setDesiredOutput(2, 0.0);
                nn.setDesiredOutput(3, 0.0);
                nn.setDesiredOutput(4, 1.0);

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
            for (int i = 0; i < 250; i++)
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
            label1.Text = "label1";
            label2.Text = "label2";
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
            // label1.Text = "greeting: " + nn.getOuputData(0).ToString();
            // label2.Text = "farewell: " + nn.getOuputData(1).ToString();
            // label3.Text = "complaint: " + nn.getOuputData(2).ToString()
            getResponse(nn.getOuputData(0), nn.getOuputData(1), nn.getOuputData(2), nn.getOuputData(3), nn.getOuputData(4));
            Console.WriteLine(nn.getOuputData(0));
            Console.WriteLine(nn.getOuputData(1));
            Console.WriteLine(nn.getOuputData(2));
            Console.WriteLine(nn.getOuputData(3));
            Console.WriteLine(nn.getOuputData(4));


        }


        public void getResponse(double op0, double op1, double op2,double op3, double op4)
        {
            int value;
            if (op0 > 0.4)
            {
                value = RandomNumber(0, 3);

                switch (value)
                {
                    case 0:
                        label1.Text="Hi! Thank you for reaching out!";
                        break;
                    case 1:
                        label1.Text = "Hey, Customer! So good to hear from you!";
                        break;
                    case 2:
                        label1.Text = "Howdy, Partner!";
                        break;
                }
            }

            else if(op1>0.4)
            {
                value = RandomNumber(0, 3);

                switch (value)
                {
                    case 0:
                        label1.Text = "Bye! We hope to hear from you soon!";
                        break;
                    case 1:
                        label1.Text = "Thank you! Just contact us anytime!";
                        break;
                    case 2:
                        label1.Text = "I'm so glad to help you! See you!";
                        break;
                }
            }

            if (op4>0.4)
            {
                value = RandomNumber(0, 3);

                switch (value)
                {
                    case 0:
                        label2.Text = "Please hold on for a minute, I'll send you more details about that product.";
                        break;
                    case 1:
                        label2.Text = "Thanks for asking! I'll send you the product details.";
                        break;
                    case 2:
                        label2.Text = "I see you're interested in this product, I can give you more details in a minute";
                        break;
                }
            }
            else if (op2 > 0.4)
            {
                value = RandomNumber(0, 3);

                switch (value)
                {
                    case 0:
                        label2.Text = "Hmmm... I see... I'll transfer you to someone who knows more about your problem.";
                        break;
                    case 1:
                        label2.Text = "That sure is a problem, but its okay, I can look for someone who can help you much better.";
                        break;
                    case 2:
                        label2.Text = "Uh-oh, that doesnt sound good, maybe someone else can help you, please hold on.";
                        break;
                }
            }
            else if (op3 > 0.4)
            {
                value = RandomNumber(0, 3);

                switch (value)
                {
                    case 0:
                        label2.Text = "For any questions about the status of your order you can use your tracking number. Here is your tracking number :#70790932813";
                        break;
                    case 1:
                        label2.Text = "I see you have a question about your order, I'll contact the courier and get back to you!";
                        break;
                    case 2:
                        label2.Text = "I understand you have concerns about your order, I can give you the courier's contact number and you can talk to them directly.";
                        break;
                }
            }
        }
        public int RandomNumber(int min, int max)
        {
            return r.Next(min, max);
        }

        private void saveWeightsDialog_FileOk(object sender, CancelEventArgs e)
        {
            nn.saveWeights(saveWeightsDialog.FileName);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveWeightsDialog.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            nn.loadWeights(openFileDialog1.FileName);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}

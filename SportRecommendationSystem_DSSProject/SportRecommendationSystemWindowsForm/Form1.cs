using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
namespace SportRecommendationSystemWindowsForm
{
    public partial class Form1 : Form
    {
        Program p = new Program();
        XmlNodeList Rules;
        public Form1()
        {
            InitializeComponent();
        }
        //termindex refer on questions index
        public  int termindex;
        //public int ruleindex;
        public void Form1_Load(object sender, EventArgs e)
        {
            termindex = 0;

            Rules = p.GetRules();
            
            label1.Text = Rules[0].ChildNodes[0].ChildNodes[termindex].Name;
            
            label2.Text = "Do you like " + label1.Text.Replace("_", " ").ToLower() + " ?";
            label1.Visible = false;
            

        }
        //public bool  button1WasClicked=false;

        Dictionary<string, string> userQA = new Dictionary<string, string>();

        public void Button1_Click(object sender, EventArgs e)
        {
            string inputanswer = textBox1.Text.Replace(" ", "").ToLower();
            userQA.Add(label1.Text, inputanswer);
            
            /*
            //This delete function does not work***
            //For loop to delete
            for (int i = 0; i < Rules.Count; i++)
            {
                for (int j = 0; j < Rules[i].ChildNodes[0].ChildNodes.Count; j++)
                {
                    if (label1.Text == Rules[i].ChildNodes[0].ChildNodes[j].Name
                        && inputanswer != Rules[i].ChildNodes[0].ChildNodes[j].ChildNodes[0].InnerText.Replace(" ", "").ToLower())
                    {
                        Rules[i].ParentNode.RemoveChild(Rules[i]);
                    }
                }
            }
            */
            


            for (int i = 0; i < Rules.Count; i++)
            {

                for (int j = 0; j < Rules[i].ChildNodes[0].ChildNodes.Count; j++)
                {
                    if (label1.Text == Rules[i].ChildNodes[0].ChildNodes[j].Name
                        && inputanswer == Rules[i].ChildNodes[0].ChildNodes[j].ChildNodes[0].InnerText.Replace(" ", "").ToLower()
                         )
                    {
                        //textBox1.Text = null;
                        if (termindex == ((Rules[i].ChildNodes[0].ChildNodes.Count) - 1))
                        {
                            MessageBox.Show("Our Recommendation " + Rules[i].ChildNodes[1].ChildNodes[0].InnerText);
                            Close();
                            break;

                        }
                        termindex++;
                        textBox1.Text = null ;
                        inputanswer = null ;
                        label1.Text = Rules[i].ChildNodes[0].ChildNodes[termindex].Name ;
                        label2.Text = "Do you like " + label1.Text.Replace("_", " ").ToLower() + " ?" ;
                    }

                }
            }
        }
    }
}

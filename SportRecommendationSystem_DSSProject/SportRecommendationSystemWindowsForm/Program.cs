using System;
using System.Windows.Forms;
using System.Xml;
namespace SportRecommendationSystemWindowsForm
{
    public class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
        public XmlNodeList GetRules()
        {

            XmlDocument KB = new XmlDocument();
            KB.Load(@"C:\Users\mostafa gaber\Source\Repos\SportRecommendationSystem\DSS - Copy.xml");
            XmlNodeList Rules = KB.SelectNodes("/Model [@name='Sports']/block/rule");
            return Rules;
        }

    }
}

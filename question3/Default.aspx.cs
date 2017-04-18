using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Homework4_1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = @"http://www.public.asu.edu/~ehleung/Hotels.xml";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XPathDocument doc = new XPathDocument(@TextBox1.Text);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("/*/*");           // Grab each Hotel node

            //Label1.Text = "There are " + iter.Count + " main nodes." + Environment.NewLine;      // test code

            while (iter.MoveNext())
            {
                XPathNodeIterator it = iter.Current.Select("*");
                it.MoveNext();
                Label dynLabel = new Label();
                dynLabel.Text = it.Current.Name + ": " + it.Current.Value + "<br/>";
                div1.Controls.Add(dynLabel);

                XPathNodeIterator atrbIt = iter.Current.Select("@*");
                while (atrbIt.MoveNext())
                {
                    Label atrbLabel = new Label();
                    atrbLabel.Text = atrbIt.Current.Name + ": " + atrbIt.Current.Value + "<br/>";
                    div1.Controls.Add(atrbLabel);
                }

                it.MoveNext();
                XPathNodeIterator conIt = it.Current.Select("*");
                while (conIt.MoveNext())
                {
                    Label conLabel = new Label();
                    conLabel.Text = conIt.Current.Name + ": " + conIt.Current.Value + "<br/>";
                    div1.Controls.Add(conLabel);
                }

                it.MoveNext();
                XPathNodeIterator adrIt = it.Current.Select("*");
                while (adrIt.MoveNext())
                {
                    Label adrLabel = new Label();
                    adrLabel.Text = adrIt.Current.Name + ": " + adrIt.Current.Value + "<br/>";
                    div1.Controls.Add(adrLabel);
                }

                Label newLine = new Label();
                newLine.Text = "<br/>";
                div1.Controls.Add(newLine);

            }
        }
    }
}
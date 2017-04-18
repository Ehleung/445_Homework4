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
            nav.MoveToFirstChild();

            XPathNodeIterator iter = nav.Select("*");           // Grab each Hotel node

            Label1.Text = "There are " + iter.Count + " main nodes." + Environment.NewLine;      // test code

            while (iter.MoveNext())     // while there is another node to traverse to
            {
                XPathNodeIterator nodeIter = iter.Current.Select("*");

                while (nodeIter.MoveNext())
                {
                    if (nodeIter.Current.HasChildren == false)
                    {
                        Label dynamicLabel = new Label();
                        div1.Controls.Add(dynamicLabel);
                        dynamicLabel.Text = nodeIter.Current.Name + ": " + nodeIter.Current.Value + "<br/>";
                    }
                    else
                    {
                        XPathNodeIterator elementIter = nodeIter.Current.Select("*");
                        Label1.Text = elementIter.Count.ToString();
                        while (elementIter.MoveNext())
                        {
                            Label elementLabel = new Label();
                            div1.Controls.Add(elementLabel);
                            elementLabel.Text = elementIter.Current.Name + ": " + elementIter.Current.Value + "<br/>";
                        }
                    }
                }

                Label newLine = new Label();
                newLine.Text = "<br/>";
                div1.Controls.Add(newLine);
            }

            //node = doc.DocumentElement;
            //Label1.Text = node.NodeType.ToString();
            //Label2.Text = Convert.ToString(node.Name);

        }
    }
}
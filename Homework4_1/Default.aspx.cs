using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace Homework4_1
{
    public partial class _Default : Page
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNode node;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = @"temporary string url";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = @TextBox1.Text;

            doc.Load(url);
            node = doc.DocumentElement;
            Label1.Text = node.NodeType.ToString();
            TextBox2.Text = Convert.ToString(node.Name);

        }
    }
}
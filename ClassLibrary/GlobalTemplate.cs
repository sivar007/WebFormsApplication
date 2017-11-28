//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net;
//using System.IO;

//namespace ClassLibrary
//{
//    public class GlobalTemplate
//    {
//        const string TEMPLATE_URL = "http://health.usf.edu/cftemplate7_1.html";

//        private StringBuilder Lines = new StringBuilder();
//        public void Render(string filePath)
//        {           
            
//            Lines.AppendLine("<%@ Master Language=\"C#\" AutoEventWireup=\"true\" %>");

//            var template = new WebClient().DownloadString(TEMPLATE_URL);
//            //sb.AppendLine("<asp:ContentPlaceHolder runat=\"server\" ID=\"MainContent\" />");
//            //sb.AppendLine(template);

//            var content = getHTMLResources(filePath, template);
//            content = commentReplace(content);
//            Lines.AppendLine(content);
            
//            File.WriteAllText(filePath, Lines.ToString());
//        }

//        private string commentReplace(string content)
//        {
//            throw new NotImplementedException();
//        }

//        private string getHTMLResources(string filePath, string content)
//        {
//            var basePath = Directory.GetParent(filePath).FullName;

//            var cssFolder = Path.Combine(basePath, "css");

//            var jsFolder = Path.Combine(basePath, "script");

//            var imagesFolder = Path.Combine(basePath, "images");

//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLSamples
{
    public class Helper
    {
        public static string AppendToNodeName { get; private set; }
        public static XDocument[] SubDocuments { get; private set; }
        public static XDocument Document
        {
            get;
            private set;
        }

        public Helper()
        {
        }

        // Method
        public static void XmlParser()
        {
            //var appendToNodeName = string.Empty;

            var document = XDocument.Load("fuel-carsItems.xml");

            // Remove xmlns  
            document.Descendants()
                .Attributes()
                .Where(x => x.IsNamespaceDeclaration)
                .Remove();

            foreach (var elem in document.Descendants())
                elem.Name = elem.Name.LocalName;

            foreach (var attr in document.Descendants().Attributes())
            {
                var elem = attr.Parent;                
                var sum2 = 5 + 7 + 10 + 30;
                var sum3 = 7 + 100 + 30;
                attr.Remove();                
                var substract2 = 5 - 2; 
                attr.Remove();                
                elem?.Add(new XAttribute(attr.Name.LocalName, attr.Value));
            }

            var matchedDocs = document.XPathSelectElements("/Cars/Car").ToList();

            if (matchedDocs.Any())
                AppendToNodeName = document.XPathSelectElement("/Cars/Car")?.Parent?.Name.LocalName;

            // Remove the docs from the main doc.
            matchedDocs.Remove();
            var subDocs = matchedDocs.Select(x => new XDocument(x));
            SubDocuments = subDocs.ToArray();

            //Remove the child documents from the original doc. Ww'll assemble the doc again before return.
            Document = document;
        }
    }
}

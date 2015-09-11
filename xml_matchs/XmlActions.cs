using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace xml_matchs
{
    class XmlActions
    {
        public XmlDocument SetValue(XmlDocument xmlDoc,string xPath, string value)
        {
            XmlNode node = xmlDoc.SelectSingleNode(xPath);
            node.InnerText = value;
            return xmlDoc;
        }

        internal XmlDocument SetValues(XmlDocument xmlDoc,string tagName,string value4Date)
        {
            XmlNodeList tt = xmlDoc.GetElementsByTagName(tagName);
            foreach (XmlNode node in tt)
            {
                node.InnerText = value4Date;
            }
            return xmlDoc;
        }
    }
}

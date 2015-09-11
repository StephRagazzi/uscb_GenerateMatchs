using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;

namespace xml_matchs
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTools dt = new DateTools();
            XmlActions xActions = new XmlActions();
            string xPathTitle = "//feuille2match/infos/titre";
            var list = dt.GetListOfSaturdays(new DateTime(2015, 9, 12), new DateTime(2016, 5, 30));
            foreach (var item in list)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("base.xml");

                string fileName = dt.GetFileName(item.Date);
                xmlDoc = xActions.SetValue(xmlDoc, xPathTitle, dt.GetDays(item.Date));
                xmlDoc = xActions.SetValues(xmlDoc, "date", item.Date.ToShortDateString());
                xmlDoc.Save(fileName);                
            }
        }
    }
}

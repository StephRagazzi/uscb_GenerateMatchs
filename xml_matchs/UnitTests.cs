using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;

namespace xml_matchs
{
    [TestFixture]
    public class UnitTests
    {
        DateTools _dt;
        [SetUp]
        public void Init()
        {
            _dt = new DateTools();
        }

        [Test]
        public void GetSaturdays()
        {
            var list=_dt.GetListOfSaturdays(new DateTime(2011, 6, 4), new DateTime(2011, 7, 3));
            Assert.That(list.First(),Is.EqualTo(new DateTime(2011, 6, 4)));
            Assert.That(list.Last(), Is.EqualTo(new DateTime(2011, 7, 2)));
        }
        [Test]
        public void GetFilename()
        {
            var list = _dt.GetListOfSaturdays(new DateTime(2011, 8, 30), new DateTime(2011, 9, 4));
            string fileName = _dt.GetFileName(list.First().Date);
            Assert.That(fileName,Is.EqualTo("m2011_09_03.xml"));
        }
        
        //[Test]
        //public void SetTagValue()
        //{
        //    string xPath = "//feuille2match/infos/titre";
        //    string value4Title = "Samedi et dimanche";
        //    XmlActions xActions= new XmlActions();
        //    XmlDocument xmlDoc = xActions.SetValue(xPath, value4Title);
        //    xmlDoc.Save("testValue.xml");
        //    XmlDocument xmlDoc2Check = new XmlDocument();
        //    xmlDoc2Check.Load("testValue.xml");
        //    XmlNode node = xmlDoc2Check.SelectSingleNode(xPath);
        //    Assert.That(node.InnerText, Is.EqualTo(value4Title));
        //}

        //[Test]
        //public void SetTagValues()
        //{
        //    string xmlFile = "testValues.xml";
        //    string xPath = "//feuille2match/garcons/match/date";
        //    string value4Date = "17/09/2011";
        //    XmlActions xActions = new XmlActions();
        //    XmlDocument xmlDoc = xActions.SetValues("date",value4Date);
        //    xmlDoc.Save(xmlFile);
        //    //reload
        //    XmlDocument xmlDoc2Check = new XmlDocument();
        //    xmlDoc2Check.Load(xmlFile);
        //    XmlNode node = xmlDoc2Check.SelectSingleNode(xPath);

        //    Assert.That(node.InnerText, Is.EqualTo(value4Date));
        //}

        [Test]
        public void SetDays()
        {
            string days =_dt.GetDays(new DateTime(2011,9,3));
            Assert.That(days,Is.EqualTo("Samedi 3 et Dimanche 4 septembre"));

            days =_dt.GetDays(new DateTime(2012,3,31));
            Assert.That(days,Is.EqualTo("Samedi 31 mars et Dimanche 1 avril"));
        }
    }
}

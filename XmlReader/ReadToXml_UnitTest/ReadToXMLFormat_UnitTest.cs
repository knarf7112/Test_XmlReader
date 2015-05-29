using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlConvert;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ReadToXml_UnitTest
{
    [TestClass]
    public class ReadToXMLFormat_UnitTest
    {
        [TestInitialize()]
        public void Init()
        {
            
        }
        [TestMethod]
        public void Test_ReadConfig()
        {
            string configFile = @"D:\HW2\XmlReader\XmlReader\config.xml";
            if (File.Exists(configFile))
            {
                Dictionary<string, string> NodeNameSize = ReadToXMLFormat.ReadXmlConfig(configFile, "size");
                XElement xe = XElement.Load(configFile, LoadOptions.None);
                foreach (var el in xe.Descendants())
                {
                    string xName = el.Name.LocalName;
                    string expected = NodeNameSize[key: xName];
                    string actual = el.Attribute("size").Value;
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void Test_RaedToXMLFile()
        {
            string filePath = @"D:\HW2\hw2source.txt";
            string configFile = @"D:\HW2\XmlReader\XmlReader\config.xml";
            string outputFile = @"D:\HW2\hw2source.xml";
            if (File.Exists(filePath) && File.Exists(filePath))
            {
                ReadToXMLFormat.RaedToXMLFile(filePath, configFile, outputFile, Encoding.UTF8);
                XElement xe = XElement.Load(outputFile, LoadOptions.None);
                string expected = "<Root>" + 
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>123456</TxID>       ".Trim() +
		                           "    <Item>Baseketball</Item>  ".Trim() +
		                           "    <Amount>3</Amount>        ".Trim() +
		                           "    <UnitPrice>200</UnitPrice>".Trim() +
	                               "</TxData>                     ".Trim() +
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>234157</TxID>       ".Trim() +
		                           "    <Item>FujiApple</Item>    ".Trim() +
		                           "    <Amount>25</Amount>       ".Trim() +
		                           "    <UnitPrice>100</UnitPrice>".Trim() +
	                               "</TxData>                     ".Trim() +
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>326415</TxID>       ".Trim() +
		                           "    <Item>BlueCherry</Item>   ".Trim() +
		                           "    <Amount>6</Amount>        ".Trim() +
		                           "    <UnitPrice>180</UnitPrice>".Trim() +
	                               "</TxData>                     ".Trim() +
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>785269</TxID>       ".Trim() +
		                           "    <Item>Carrot</Item>       ".Trim() +
		                           "    <Amount>128</Amount>      ".Trim() +
		                           "    <UnitPrice>12</UnitPrice> ".Trim() +
	                               "</TxData>                     ".Trim() +
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>451686</TxID>       ".Trim() +
		                           "    <Item>GuineaPig</Item>    ".Trim() +
		                           "    <Amount>2</Amount>        ".Trim() +
		                           "    <UnitPrice>150</UnitPrice>".Trim() +
	                               "</TxData>                     ".Trim() +
	                               "<TxData>                      ".Trim() +
		                           "    <TxID>151356</TxID>       ".Trim() +
		                           "    <Item>BugsBunny</Item>    ".Trim() +
		                           "    <Amount>1</Amount>        ".Trim() +
		                           "    <UnitPrice>1280</UnitPrice>".Trim() +
	                               "</TxData>" +
                                   "</Root>";

                StringWriter sw = new StringWriter();
                XmlTextWriter xt = new XmlTextWriter(sw);
                
                xe.WriteTo(xt);
                string actual = sw.ToString();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestCleanup]
        public void Test_CleanUp()
        {

        }
    }
}

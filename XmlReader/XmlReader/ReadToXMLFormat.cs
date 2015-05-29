using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace XmlConvert
{
    public class ReadToXMLFormat
    {
        /// <summary>
        /// txt文字檔資料轉xml格式檔資料
        /// </summary>
        /// <param name="filePath">輸入的txt文字檔位置(要含路徑)</param>
        /// <param name="configXmlFilePath">xml格式的設定檔位置(要含路徑)</param>
        /// <param name="outputFilePath">輸出的xml檔位置(要含路徑)</param>
        /// <param name="encoding">txt文字檔讀取的編碼設定</param>
        public static void RaedToXMLFile(string filePath, string configXmlFilePath, string outputFilePath, Encoding encoding)
        {
            //讀取xml設定檔size屬性
            Dictionary<string, string> NodeNameSize = ReadXmlConfig(configXmlFilePath,"size");

            List<TxData> txDataList = new List<TxData>();

            //載入txt檔轉成物件TxData並用List裝載
            using (StreamReader sr = new StreamReader(filePath, encoding))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    TxData txData = new TxData();
                    int startIndex = 0;
                    for (int i = 0; i < txData.PropertyLength; i++)
                    {
                        string propertyName = txData.GetPropertyName(i).ToString();
                        txData[i] = line.Substring(startIndex, int.Parse(NodeNameSize[propertyName]));
                        startIndex += int.Parse(NodeNameSize[propertyName]);
                    }
                    txDataList.Add(txData);
                }
            }

            //設定xml輸出格式
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.IndentChars = "\t";
            setting.OmitXmlDeclaration = true;

            //xml寫入檔案
            using (XmlWriter xmlWriter = XmlWriter.Create(outputFilePath, setting))
            {
                StringBuilder XmlString = new StringBuilder();
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Root");
                XmlString.AppendLine("<Root>");
                foreach (TxData obj in txDataList)
                {
                    xmlWriter.WriteStartElement("TxData");
                    XmlString.AppendLine("<TxData>");
                    for (int i = 0; i < obj.PropertyLength; i++)
                    {
                        xmlWriter.WriteElementString(obj.GetPropertyName(i), obj[i]);
                        XmlString.AppendLine("<" + obj.GetPropertyName(i) + ">" + obj[i] + "/<" + obj.GetPropertyName(i) + ">");
                    }
                    xmlWriter.WriteEndElement();
                    XmlString.AppendLine("</TxData>");
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                XmlString.AppendLine("</Root>");
                xmlWriter.Flush();
                Debug.WriteLine(XmlString);//輸出Xml字串到Listeners 集合中的追蹤接聽項
            }
        }

        /// <summary>
        /// xml設定檔載入(第一層), Key(TagName) / Value(TagAttribute)
        /// </summary>
        /// <param name="configPath">Xml檔案路徑</param>
        /// <param name="wrapValue">要取的屬性名稱用來獲得屬性值</param>
        /// <returns>Key(TagName)/Value(TagAttribute)</returns>
        public static Dictionary<string, string> ReadXmlConfig(string configPath,string wrapValue)
        {
            XElement xmlConfig = XElement.Load(configPath);
            
            Dictionary<string, string> NodeSizeList = new Dictionary<string, string>();
            foreach (XElement node in xmlConfig.Elements())
            {
                if (node.HasAttributes)
                {
                    string nodeName = node.Name.LocalName;
                    string nodeValue = node.Attribute(wrapValue).Value;
                    NodeSizeList.Add(nodeName, nodeValue);
                }
            }
            return NodeSizeList;
        }
    }
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConvert;
namespace ReadToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadToXMLFormat.RaedToXMLFile(@"D:\HW2\hw2source.txt", @"D:\HW2\XmlReader\XmlReader\config.xml", @"D:\HW2\hw2source.xml", Encoding.UTF8);
        }
    }
}

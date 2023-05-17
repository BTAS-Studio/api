using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace BTAS.API.Extensions
{
    public static class XmlHelper
    {
        public static string GetSoapXmlBody(HttpRequestMessage request)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(request.Content.ReadAsStreamAsync().Result);

            var xmlData = xmlDocument.DocumentElement;
            var xmlBodyElement = xmlData.GetElementsByTagName("SOAP-ENV:Body");

            var xmlBodyNode = xmlBodyElement.Item(0);
            if (xmlBodyNode == null) throw new Exception("Function GetSoapXmlBody: Can't find SOAP-ENV:Body node");

            var xmlPayload = xmlBodyNode.FirstChild;
            if (xmlPayload == null) throw new Exception("Function GetSoapXmlBody: Can't find XML payload");

            return xmlPayload.OuterXml;
        }
    }
}

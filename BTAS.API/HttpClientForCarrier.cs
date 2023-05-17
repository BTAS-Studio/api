using BTAS.API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class HttpClientForCarrier : IDisposable
    {
        private string baseUrl;

        public HttpClientForCarrier(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public HttpWebRequest MakeCall(string method, string route, List<CarrierHeaders> headers)
        {
            string uri = baseUrl;
            string path = uri + route;
            

            HttpWebRequest client = (HttpWebRequest)WebRequest.Create(path);

            //client.ContentType = "application/json";
            //client.Accept = "application/json";
            client.Method = method;
            foreach(var header in headers)
            {
                client.Headers.Add(header.header, header.value);
            }

            return client;
        }


        public string PrintWebResponse(WebResponse response)
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

        public string EncodeAuth(string data, string key)
        {
            string rtn = null;
            if (null != data && null != key)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(data);
                byte[] byteKey = Encoding.UTF8.GetBytes(key);
                using (HMACSHA1 myhmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                    {
                        byte[] hashValue = myhmacsha1.ComputeHash(stream);
                        rtn = Convert.ToBase64String(hashValue);
                    }
                }
            }
            return rtn;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

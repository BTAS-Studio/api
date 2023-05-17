using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Models;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ApgRepository
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        IConfiguration config;

        public ApgRepository(MainDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            this.config = config;
        }

        public async Task<object> CreateShipmentAsync(List<CreateShippingRequest> request)
        {
            try
            {
                string url = "http://qa.etowertech.com";
                string endpoint = "/services/shipper/orders";

                HttpClientForCarrier api = new HttpClientForCarrier(url);

                List<CarrierHeaders> headers = new();

                string wallTechDate = String.Format("{0:R}", DateTime.UtcNow);
                string auth = "POST" + '\n' + wallTechDate + '\n' + url + endpoint;
                string hash = api.EncodeAuth(auth, config["ETowerCredentials:Secret"]);
                headers.Add(new CarrierHeaders { header = "Content-Type", value = "application/json" });
                headers.Add(new CarrierHeaders { header = "X-WallTech-Date", value = wallTechDate });
                headers.Add(new CarrierHeaders { header = "Authorization", value = "WallTech " + config["ETowerCredentials:Token"] + ':' + hash });

                var client = api.MakeCall("POST", endpoint, headers);

                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
                client.ContentLength = data.Length;

                string trackingNo = "";
                int parcelInfoId = 0;

                using (Stream requestStream = await client.GetRequestStreamAsync())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }

                using (WebResponse response = await client.GetResponseAsync())
                {
                    var result = api.PrintWebResponse(response);
                    response.Close();

                    if (result.IndexOf("Failure") > -1)
                    {
                        return JsonConvert.DeserializeObject<CreateShippingResponseError>(result);
                    }
                    else
                    {
                        if (result.IndexOf("Partial") > -1)
                        {
                            return JsonConvert.DeserializeObject<GenericResponsePartial>(result);
                        }
                        else
                        {


                            return JsonConvert.DeserializeObject<CreateShippingResponseSuccess>(result);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<object> CreateLabelAsync([FromBody] CreateLabelRequest request)
        {
            string url = "http://qa.etowertech.com";
            string endpoint = "/services/shipper/labels";

            HttpClientForCarrier api = new HttpClientForCarrier(url);

            List<CarrierHeaders> headers = new();

            string wallTechDate = String.Format("{0:R}", DateTime.UtcNow);
            string auth = "POST" + '\n' + wallTechDate + '\n' + url + endpoint;
            string hash = api.EncodeAuth(auth, config["ETowerCredentials:Secret"]);
            headers.Add(new CarrierHeaders { header = "X-WallTech-Date", value = wallTechDate });
            headers.Add(new CarrierHeaders { header = "Authorization", value = "WallTech " + config["ETowerCredentials:Token"] + ':' + hash });

            var client = api.MakeCall("POST", endpoint, headers);

            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
            client.ContentLength = data.Length;

            using (Stream requestStream = await client.GetRequestStreamAsync())
            {
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
            }

            using (WebResponse response = await client.GetResponseAsync())
            {
                var result = api.PrintWebResponse(response);
                response.Close();
                if (result.IndexOf("Failure") > -1)
                {
                    return JsonConvert.DeserializeObject<CreateLabelResponseError>(result);
                }
                else
                {
                    return JsonConvert.DeserializeObject<CreateLabelResponseSuccess>(result);
                }
            }
        }
    }
}

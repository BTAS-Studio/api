using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Allied;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
//using TnTWebService;
//using static TnTWebService.TTWSClient;
//using BTAS.WCF.AlliedWS;

namespace BTAS.API.Repository
{
    public class AlliedRepository
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        IConfiguration config;

        public AlliedRepository(MainDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            this.config = config;
        }

        //public async Task<string> InitializeAccount()
        //{
        //    try
        //    {
        //        var account = await GetAccount();
        //        GeographicAddress pickupAddress = new GeographicAddress();
        //        pickupAddress.address1 = "123 Here Street";
        //        pickupAddress.suburb = "SALISBURY";
        //        pickupAddress.state = "QLD";
        //        pickupAddress.postCode = "4107";

        //        GeographicAddress deliveryAddress = new GeographicAddress();
        //        deliveryAddress.address1 = "456 There Street";
        //        deliveryAddress.suburb = "PARRAMATTA";
        //        deliveryAddress.state = "NSW";
        //        deliveryAddress.postCode = "2150";

        //        JobStop pickupStop = new JobStop();
        //        pickupStop.companyName = "Senders R Us";
        //        pickupStop.contact = "Mr. Sender";
        //        pickupStop.geographicAddress = pickupAddress;
        //        pickupStop.phoneNumber = "07 1324 5678";
        //        pickupStop.stopType = "P";
        //        pickupStop.stopNumber = 1;

        //        JobStop deliveryStop = new JobStop();
        //        deliveryStop.companyName ="Receivers R Us";
        //        deliveryStop.contact  ="Mrs Reciever";
        //        deliveryStop.geographicAddress = deliveryAddress;
        //        deliveryStop.phoneNumber="02 9876 5432";
        //        deliveryStop.stopType = "D";
        //        deliveryStop.stopNumber = 2;
        //        JobStop[] jobStops = new JobStop[] { pickupStop, deliveryStop };

        //        // Construct the Item objects
        //        Item jobItem1 = new Item();
        //        jobItem1.dangerous = false;
        //        jobItem1.length= 50; // in centi meter
        //        jobItem1.width =50; // in centi meter
        //        jobItem1.height = 50; // in centi meter
        //        jobItem1.volume = 0.125; // in cubic meter
        //        jobItem1.weight = 20; // in kilo gram
        //        jobItem1.itemCount=2;

        //        Item jobItem2 = new Item();
        //        jobItem2.dangerous = false;
        //        jobItem2.length=360;
        //        jobItem2.width=10;
        //        jobItem2.height=10;
        //        jobItem2.volume=0.036;
        //        jobItem2.weight=40;
        //        jobItem2.itemCount =1;
        //        Item[] jobItems = new Item[] { jobItem1, jobItem2 };

        //        // Construct the reference number array
        //        String[] referenceNumbers = new String[] { "CONREF001" };
        //        // Create the ready date
        //        DateTime readyDate = DateTime.Now;

        //        // Get the total items, weight and volume from the Items array
        //        int totalItems = 0;
        //        double totalWeight = 0;
        //        double totalVolume = 0.000D;
        //        foreach (Item item in jobItems)
        //        {
        //            totalItems += item.itemCount;
        //            totalWeight += item.weight * item.itemCount;
        //            totalVolume += item.volume * item.itemCount;
        //        }

        //        // Construct the Job object
        //        Job job = new Job();
        //        job.account = account;
        //        job.instructions = "Sending something special"; // Optional
        //        job.itemCount = totalItems;
        //        job.cubicWeight = totalWeight;
        //        job.volume = totalVolume;
        //        job.items = jobItems;
        //        job.jobStops = jobStops;
        //        job.serviceLevel = "R";
        //        job.referenceNumbers = referenceNumbers; // Optional
        //        job.bookedBy = "Mr. Sender";
        //        job.readyDate = readyDate;

        //        //var validate = await ValidateBooking(job);

        //        return JsonConvert.SerializeObject(account);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public async Task<string> GetAccount()
        {
            try
            {
                string soapString = @"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                <soap:Body>
                      <getAccountDefaults>
                        <String_1>90b72725def67931544baecd8514ee75</String_1>
                        <String_2>AUSEXP</String_2>
                        <String_3>NSW</String_3>
                        <String_4>AOE</String_4>
                      </getAccountDefaults>
                    </soap:Body>
            </soap:Envelope>";


                //var account = await client.getAccountDefaultsAsync("90b72725def67931544baecd8514ee75", "AUSEXP", "NSW", "AOE");


                HttpResponseMessage response = await CreateSOAPWebRequest(soapString, "getAccountDefaults");

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            //return JsonConvert.DeserializeObject<Account>(content);

        }

        public async Task<ResponseDto> CreateJob(CreateJobRequest.CreateBooking request)
        {
            try
            {
                //TnTWebService.GeographicAddress pickupAddress = new TnTWebService.GeographicAddress();
                //pickupAddress = _mapper.Map<GeographicAddress>(request.Job.)
                //pickupAddress.address1 = "123 Here Street";
                //pickupAddress.suburb = "SALISBURY";
                //pickupAddress.state = "QLD";
                //pickupAddress.postCode = "4107";

                //TnTWebService.GeographicAddress deliveryAddress = new TnTWebService.GeographicAddress();
                //deliveryAddress.address1 = "456 There Street";
                //deliveryAddress.suburb = "PARRAMATTA";
                //deliveryAddress.state = "NSW";
                //deliveryAddress.postCode = "2150";

                JobStop pickupStop = new JobStop();
                pickupStop = _mapper.Map<JobStop>(request.Job.jobStops.Where(x => x.stopNumber == 1).SingleOrDefault());
                //pickupStop.companyName = "Senders R Us";
                //pickupStop.contact = "Mr. Sender";
                //pickupStop.geographicAddress = _mapper.Map<GeographicAddress>(request.Job.jobStops[0]);
                //pickupStop.phoneNumber = "07 1324 5678";
                //pickupStop.stopType = "P";
                //pickupStop.stopNumber = 1;

                JobStop deliveryStop = new JobStop();
                deliveryStop = _mapper.Map<JobStop>(request.Job.jobStops.Where(x => x.stopNumber == 2).SingleOrDefault());
                //deliveryStop.companyName = "Receivers R Us";
                //deliveryStop.contact = "Mrs Reciever";
                //deliveryStop.geographicAddress = deliveryAddress;
                //deliveryStop.phoneNumber = "02 9876 5432";
                //deliveryStop.stopType = "D";
                //deliveryStop.stopNumber = 2;

                JobStop[] jobStops = new JobStop[] { pickupStop, deliveryStop };

                List<Item> jobItems = new();
                // Construct the Item objects
                foreach (var item in request.Job.items)
                {
                    Item jobItem = new Item();
                    jobItem = _mapper.Map<Item>(item);

                    jobItems.Add(jobItem);
                }

                //TnTWebService.Item jobItem1 = new TnTWebService.Item();
                //jobItem1.dangerous = false;
                //jobItem1.length = 50; // in centi meter
                //jobItem1.width = 50; // in centi meter
                //jobItem1.height = 50; // in centi meter
                //jobItem1.volume = 0.125; // in cubic meter
                //jobItem1.weight = 20; // in kilo gram
                //jobItem1.itemCount = 2;

                //TnTWebService.Item jobItem2 = new TnTWebService.Item();
                //jobItem2.dangerous = false;
                //jobItem2.length = 360;
                //jobItem2.width = 10;
                //jobItem2.height = 10;
                //jobItem2.volume = 0.036;
                //jobItem2.weight = 40;
                //jobItem2.itemCount = 1;

                //TnTWebService.Item[] jobItems = new TnTWebService.Item[] { jobItem1, jobItem2 };

                // Construct the reference number array
                String[] referenceNumbers = new String[] { "CONREF001" };
                // Create the ready date
                DateTime readyDate = DateTime.Now;

                // Get the total items, weight and volume from the Items array
                int totalItems = 0;
                double totalWeight = 0;
                double totalVolume = 0.000D;

                foreach (Item item in jobItems)
                {
                    totalItems += item.itemCount;
                    totalWeight += item.weight * item.itemCount;
                    totalVolume += item.volume * item.itemCount;
                }

                // Construct the Job object
                Job job = new Job();
                job.account = request.Job.account;
                job.instructions = request.Job.instructions;
                job.itemCount = totalItems;
                job.weight = totalWeight;
                job.volume = totalVolume;
                job.items = jobItems.ToArray();
                job.jobStops = jobStops;
                job.serviceLevel = request.Job.serviceLevel;
                job.referenceNumbers = referenceNumbers; // Optional
                job.bookedBy = request.Job.bookedBy;
                job.bookedDate = request.Job.bookedDate;
                job.readyDate = readyDate;
                job.price = request.Job.price;

                request.Job = job;

                var xml = MySerializer<CreateJobRequest.CreateBooking>.Serialize(request);

                xml.Replace(@"<?xml version=""1.0"" encoding=""utf-8""?>", "");


                string xmlRequest = String.Concat(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>", xml.Replace(@"<?xml version=""1.0"" encoding=""utf-8""?>", ""),
                    @"</soap:Body>
                </soap:Envelope>");

                HttpResponseMessage response = await CreateSOAPWebRequest(xmlRequest, "validateBooking");

                string content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument doc = XDocument.Parse(content);

                    XElement getResponse = doc.Descendants().Where(x => x.Name.LocalName == "result").SingleOrDefault();
                    XElement jobNumber = doc.Descendants().Where(x => x.Name.LocalName == "jobNumber").SingleOrDefault();
                    XElement docketNumber = doc.Descendants().Where(x => x.Name.LocalName == "docketNumber").SingleOrDefault();
                    string forSaving = getResponse.ToString();

                    string savingXml = String.Concat(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <savePendingJob>
                            <String_1>" + request.String_1 + "</String_1>",
                                forSaving.Replace("result", "Job"),
                        @"  </savePendingJob>
                    </soap:Body>
                </soap:Envelope>");

                    HttpResponseMessage savingResponse = await CreateSOAPWebRequest(savingXml, "savePendingJob");
                    string savingContent = await savingResponse.Content.ReadAsStringAsync();

                    string dispatchXml = String.Concat(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <dispatchPendingJobs>
                           <String_1>" + request.String_1 + "</String_1>",
                                @"<JobIds>
                                    <jobIds>",
                                    jobNumber.Value.ToString(),
                                    @"</jobIds>
                                </JobIds>
                        </dispatchPendingJobs>
                    </soap:Body>
                </soap:Envelope>");

                    HttpResponseMessage dispatchResponse = await CreateSOAPWebRequest(dispatchXml, "dispatchPendingJobs");
                    string dispatchContent = await dispatchResponse.Content.ReadAsStringAsync();
                    if (dispatchResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string labelXml = String.Concat(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                        <getLabel>
                                  <signature>", request.String_1, @"</signature>
                                  <shippingDivision>", request.Job.account.shippingDivision, @"</shippingDivision>
                                  <consignmentNo>",
                                    docketNumber.Value.ToString(),
                                    @"</consignmentNo>
                                  <referenceNo></referenceNo>
                                  <destinationPostcode>", deliveryStop.geographicAddress.postCode,
                                    @"</destinationPostcode>
                                  <labelType>1</labelType>
                                </getLabel>
                    </soap:Body>
                </soap:Envelope>");

                        HttpResponseMessage labelResponse = await CreateSOAPWebRequest(labelXml, "getLabel");
                        string labelContent = await labelResponse.Content.ReadAsStringAsync();

                        XDocument labelDoc = XDocument.Parse(labelContent);

                        XElement labelString = labelDoc.Descendants().Where(x => x.Name.LocalName == "result").SingleOrDefault();

                        return new ResponseDto
                        {
                            Result = labelString.Value.ToString(),
                            ReferenceNumber = docketNumber.Value.ToString(),
                            IsSuccess = true
                        };
                    }

                    return new ResponseDto
                    {
                        DisplayMessage = "Error validating booking",
                        Result = response,
                        ReferenceNumber = "",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    DisplayMessage = "Technical problem occured.",
                    Result = null,
                    ReferenceNumber = "",
                    IsSuccess = false
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<HttpResponseMessage> CreateSOAPWebRequest(string xmlString, string method)
        {
            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(xmlString, Encoding.UTF8, "text/xml");
                httpContent.Headers.Add("SOAPAction", "http://tempuri.org/" + method);

                //return await httpClient.PostAsync("https://neptune.alliedexpress.com.au:8443/ttws-ejb/TTWS", httpContent);
                return await httpClient.PostAsync("http://triton.alliedexpress.com.au:8080/ttws-ejb/TTWS", httpContent);
            }
        }


        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            var xmlWithoutNs = xmlDocumentWithoutNs.ToString();


            return xmlWithoutNs;
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }

    public class MySerializer<T> where T : class
    {
        public static string Serialize(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new Utf8StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = System.Xml.Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}

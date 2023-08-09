using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using Renci.SshNet;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Configuration;
using System.Runtime.Serialization;

namespace BTAS.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api")]
    //[ApiVersion("1.0")]
    public class ManifestController : ControllerBase //: GenericController<tbl_manifestDto>
    {
        protected ManifestResponse _manifestResponse;
        protected TokenResponse _tokenResponse;
        readonly IConfiguration _configuration;
        private readonly ManifestRepository _repository;
        private readonly IAuthenticationRepository _authRepo;
        private List<BTAS.API.Models.Manifest> _manifestTemplate;

        public ManifestController(ManifestRepository repository, IAuthenticationRepository authRepo, IConfiguration configuration) //: base(repository)
        {
            this._manifestResponse = new ManifestResponse();
            this._tokenResponse = new TokenResponse();
            this._manifestTemplate = new List<BTAS.API.Models.Manifest>();
            _repository = repository;
            _authRepo = authRepo;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("manifest")]
        public async Task<ManifestResponse> Manifest([FromBody] ManifestRequest request)
        {
            try
            {
                Dictionary<string, string> requestHeaders = new Dictionary<string, string>();
                foreach (var header in Request.Headers)
                {
                    requestHeaders.Add(header.Key, header.Value);
                }

                bool sendToFtp = Convert.ToBoolean(requestHeaders["sendToFtp"]);
                //var token = await RequestTokenAsync(requestHeaders["apikey"]);
                //TokenResponse serToken = JsonConvert.DeserializeObject<TokenResponse>(token);

                //GeneralResponse apiResponse = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(requestHeaders["apikey"], requestHeaders["apiToken"], request.shipperId));
                //if (apiResponse.success == false)
                //{
                //    _manifestResponse.success = apiResponse.success;
                //    _manifestResponse.response = apiResponse.response;
                //    _manifestResponse.responseDescription = apiResponse.responseDescription;

                //    return _manifestResponse;
                //}

                if (request.consignmentId.Count > 0)
                {
                    BTAS.API.Models.Manifest manifest = new();

                    ManifestMessage manifestMessage = new()
                    {
                        manifested_count = 0,
                        manifested_failed_count = 0
                    };

                    string consignmentNumer = "";

                    tbl_manifestDto entity = new tbl_manifestDto
                    {
                        tbl_manifest_carrier = request.carrier,
                        tbl_manifest_prefix = "M" + request.shipperId
                    };

                    tbl_manifestDto result = new();

                    string references = "";
                    foreach (var consignment in request.consignmentId)
                    {
                        references += string.Concat(consignment, ",");
                    }

                    try
                    {
                        var consignmentDetails = await _repository.GetConsignmentDetailsAsync(references, request.carrier);

                        if (consignmentDetails != null)
                        {
                            result = await _repository.CreateUpdateAsync(entity);

                            foreach (var header in request.consignmentId)
                            {
                                bool isLoaded = false;
                                Consignment c = null;
                                foreach (var details in consignmentDetails.Where(x => x.ConsignmentNumber == header.ToUpper()))
                                {
                                    isLoaded = true;
                                    LoadDetail ld = new LoadDetail
                                    {
                                        ItemReference = details.ItemReference,
                                        NumberOfUnits = details.NumberOfUnits,
                                        LogisticUnit = (details.LogisticUnit.ToUpper().IndexOf("PARCEL") > -1 ? "Parcel" : "Bulk"),
                                        Weight = details.Weight,
                                        Length = details.Length,
                                        Width = details.Width,
                                        Height = details.Height,
                                        Cubic = details.Cubic,
                                        Barcode = details.Barcode
                                    };

                                    if (details.ConsignmentNumber != consignmentNumer)
                                    {
                                        ManifestSenderModel sender = new();
                                        sender.Name = "Austway AU";
                                        sender.Contact = "Luna Cao";
                                        sender.Phone = "+61 452 188 899";
                                        sender.Email = "luna.cao@austwayexpress.com.au";

                                        switch (details.CarrierService.ToUpper())
                                        {
                                            case "BOR.EDI.PARCEL.NSW":
                                            case "BOR.EDI.BULK.NSW":
                                                {
                                                    sender.Address = "24-32 Raymond Ave";
                                                    sender.Suburb = "Matraville";
                                                    sender.State = "NSW";
                                                    sender.PostCode = "2036";
                                                    break;
                                                }
                                            case "BOR.EDI.PARCEL.VIC":
                                            case "BOR.EDI.BULK.VIC":
                                            case "BOR.EDI.PARCEL.VIC.FE":
                                            case "BOR.EDI.BULK.VIC.FE":
                                                {
                                                    sender.Address = "4/8-14 Melverton Drive";
                                                    sender.Suburb = "Hallam";
                                                    sender.State = "VIC";
                                                    sender.PostCode = "3803";
                                                    break;
                                                }
                                            case "BOR.EDI.PARCEL.QLD":
                                            case "BOR.EDI.BULK.QLD":
                                                {
                                                    sender.Address = "30 Woomera Pl";
                                                    sender.Suburb = "Archerfield";
                                                    sender.State = "QLD";
                                                    sender.PostCode = "4108";
                                                    break;
                                                }
                                            case "BOR.EDI.PARCEL.WA":
                                            case "BOR.EDI.BULK.WA":
                                                {
                                                    sender.Address = "9 Ferguson St";
                                                    sender.Suburb = "Kewdale";
                                                    sender.State = "WA";
                                                    sender.PostCode = "6105";
                                                    break;
                                                }
                                            default:
                                                {
                                                    sender.Address = "24-32 Raymond Ave";
                                                    sender.Suburb = "Matraville";
                                                    sender.State = "NSW";
                                                    sender.PostCode = "2036";
                                                    break;
                                                }
                                        }

                                        c = new Consignment()
                                        {
                                            CarrierService = (ld.LogisticUnit.ToUpper().IndexOf("PARCEL") > -1 ? "BEP" : "BEB"), //details.CarrierService == null ? "" : details.CarrierService,
                                            ConsignmentNumber = details.ConsignmentNumber == null ? "" : details.ConsignmentNumber,
                                            ConsignmentDate = details.ConsignmentDate, // request.PickupDate, // details.ConsignmentDate == null ? "" : details.ConsignmentDate,
                                            SenderName = sender.Name, //details.SenderName == null ? "" : details.SenderName,
                                            SenderContact = sender.Contact == null ? "" : sender.Contact, // details.SenderContact == null ? "" : details.SenderContact,
                                            SenderPhone = sender.Phone == null ? "" : sender.Phone, // details.SenderPhone == null ? "" : details.SenderPhone,
                                            SenderEmail = sender.Email == null ? "" : sender.Email, // details.SenderEmail == null ? "" : details.SenderEmail,
                                            SenderStreetAddress = sender.Address == null ? "" : sender.Address, //details.SenderStreetAddress == null ? "" : details.SenderStreetAddress, //"24-32 Raymond Ave", //
                                            SenderStreetAddress1 = sender.Address1 == null ? "" : sender.Address1, //details.SenderStreetAddress1 == null ? "" : details.SenderStreetAddress1,
                                            SenderState = sender.State == null ? "" : sender.State, //details.SenderState == null ? "" : details.SenderState, //"NSW", //
                                            SenderSuburb = sender.Suburb == null ? "" : sender.Suburb, //details.SenderSuburb == null ? "" : details.SenderSuburb, //"Matraville", //
                                            SenderPostcode = sender.PostCode == null ? "" : sender.PostCode, //"2036", //
                                            Pickup = details.Pickup == null ? "" : details.Pickup,
                                            Delivery = details.Delivery == null ? "" : details.Delivery,
                                            DangerousGoods = details.DangerousGoods == null ? "" : details.DangerousGoods,
                                            ReceiverReference = details.ReceiverReference == null ? "" : details.ReceiverReference,
                                            ReceiverName = details.ReceiverName == null ? "" : details.ReceiverName,
                                            ReceiverContact = details.ReceiverContact == null ? "" : details.ReceiverContact,
                                            ReceiverPhone = details.ReceiverPhone == null ? "" : details.ReceiverPhone,
                                            ReceiverEmail = details.ReceiverEmail == null ? "" : details.ReceiverEmail,
                                            ReceiverStreetAddress = details.ReceiverStreetAddress == null ? "" : details.ReceiverStreetAddress,
                                            ReceiverStreetAddress1 = details.ReceiverStreetAddress1 == null ? "" : details.ReceiverStreetAddress1,
                                            ReceiverState = details.ReceiverState == null ? "" : details.ReceiverState,
                                            ReceiverSuburb = details.ReceiverSuburb == null ? "" : details.ReceiverSuburb,
                                            ReceiverPostcode = details.ReceiverPostcode == null ? "" : details.ReceiverPostcode,
                                            TotalWeight = details.TotalWeight == null ? "" : details.TotalWeight,
                                            AccountCode = details.AccountCode == null ? "" : details.AccountCode,
                                            Comments = details.Comments == null ? "ATL" : details.Comments

                                        };

                                        manifestMessage.manifested_count++;
                                    }

                                    if (ld != null)
                                        c.LoadDetails.Add(ld);

                                    var response = await _repository.UpdateManifestAsync(result.idtbl_manifest, details.ConsignmentNumber);

                                    consignmentNumer = details.ConsignmentNumber;
                                };

                                if (!isLoaded)
                                {
                                    manifestMessage.failed_consignments.Add(header);
                                    manifestMessage.manifested_failed_count++;
                                }



                                if (c != null)
                                    manifest.Consignments.Add(c);
                            }
                        }
                        else
                        {
                            manifestMessage.manifested_failed_count += request.consignmentId.Count();

                            manifestMessage.failed_consignments.Add(references);
                        }

                    }
                    catch (Exception ex)
                    {
                        manifestMessage.manifested_failed_count += request.consignmentId.Count();
                        manifestMessage.failed_consignments.Add(references);
                    }

                    _manifestTemplate.Add(manifest);

                    string filename = "M" + request.shipperId + String.Format("{0:0000000000}", result.idtbl_manifest);
                    if (manifestMessage.manifested_count > 0)
                    {
                        if (await CreateXML2(filename + ".xml", _manifestTemplate.Select(x => x).ToList()) == "success")
                        {

                            manifestMessage.manifest_ref = filename;
                            manifestMessage.response += "XML Created|";

                            if (sendToFtp)
                            {
                                if (_repository.SendXmlToSftp("xml/" + filename + ".xml",
                                _configuration.GetValue<string>("SFTPCredentials:HostName"),
                                _configuration.GetValue<string>("SFTPCredentials:UserName"),
                                _configuration.GetValue<string>("SFTPCredentials:Password")))
                                {
                                    manifestMessage.response += "XML Sent to SFTP|";
                                    await _repository.UpdateManifestAsync(result.idtbl_manifest, DateTime.Now.Date);
                                }
                                else
                                {
                                    manifestMessage.response += filename + ".xml NOT sent to SFTP|";
                                }
                            }

                        }
                        else
                        {
                            manifestMessage.response += "XML Not Created|";
                        }
                    }


                    _manifestResponse.dataArray.message.Add(manifestMessage);
                }

            }
            catch (Exception ex)
            {
                _manifestResponse.success = false;
                _manifestResponse.responseDescription = ex.StackTrace.ToString();
            }

            return _manifestResponse;
        }

        /// <summary>
        /// Requests access token from PHP API (used only for testing purposes atm)
        /// </summary>
        /// <param name="apikey">Test API key</param>
        /// <returns></returns>
        [HttpGet]
        private async Task<string> RequestTokenAsync(string apikey)
        {
            using (var client = new HttpClient())
            {
                var url = "https://api.bent63.sg-host.com/";
                var cl = new HttpClient();
                cl.BaseAddress = new Uri(url);
                int _TimeoutSec = 90;
                cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
                string _ContentType = "application/json";
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                client.DefaultRequestHeaders.Add("apikey", apikey);

                var parameters = new Dictionary<string, string>();
                parameters["apiFunctionName"] = "getToken";

                var response = await client.PostAsync(url, new FormUrlEncodedContent(parameters));
                var contents = await response.Content.ReadAsStringAsync();

                return contents;
            }
        }

        /// <summary>
        /// Validates the submitted parameters
        /// </summary>
        /// <param name="apikey">Client's APIKEY</param>
        /// <param name="token">Client's requested token from PHP API</param>
        /// <param name="shipperId">Client's provided Shipper Id</param>
        /// <returns></returns>
        //private async Task<string> ValidateTokenAsync(string apikey, string token, string shipperId)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var url = "https://api.bent63.sg-host.com/"; 
        //        var cl = new HttpClient();
        //        cl.BaseAddress = new Uri(url);
        //        int _TimeoutSec = 90;
        //        cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);
        //        string _ContentType = "application/json";
        //        cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
        //        client.DefaultRequestHeaders.Add("apikey", apikey);
        //        client.DefaultRequestHeaders.Add("apiToken", token);

        //        var parameters = new Dictionary<string, string>();
        //        parameters["apiFunctionName"] = "verifyToken";
        //        parameters["apiFunctionParams"] = "{ \"shipperId\": \"" + shipperId + "\" }";

        //        var response = await client.PostAsync(url, new FormUrlEncodedContent(parameters));
        //        var contents = await response.Content.ReadAsStringAsync();

        //        return contents;
        //    }
        //}


        /// <summary>
        /// CreateXML generates XML file based on provided parameters
        /// </summary>
        /// <param name="filename">file.xml</param>
        /// <param name="template">Manifest class</param>
        /// <returns>success or error</returns>
        private async Task<string> CreateXML(string filename, List<BTAS.API.Models.Manifest> template)
        {
            try
            {
                await Task.Run(() =>
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("    ");
                    settings.CloseOutput = true;
                    settings.OmitXmlDeclaration = true;
                    settings.NewLineOnAttributes = true;
                    settings.Async = true;

                    string path = Path.Combine("xml/", filename);

                    /////PROCESS to generate XML FILE from CLASS.

                    //var overview = new Manifest();
                    //overview.Consignment = new FirstIndent();
                    //overview.Consignment.LoadDetails = new LoadDetail();

                    XmlSerializer s = new XmlSerializer(template.GetType());
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        s.Serialize(writer, template);
                        writer.Close();
                    }

                    XDocument input = XDocument.Load(path);
                    XElement firstChild = input.Root.Elements().First();
                    XDocument output = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                                     firstChild);
                    output.Save(path);

                    XDocument xDocument = XDocument.Load(path);


                    XElement root = xDocument.Element("Manifest");

                    foreach (var attr in root.Attributes())
                    {
                        attr.Remove();
                    }
                    root.Attributes().Remove();

                    IEnumerable<XElement> consignmentsNode = root.Descendants("Consignments");


                    root.Add(consignmentsNode.Elements());
                    consignmentsNode.Remove();

                    IEnumerable<XElement> consignmentNode = root.Descendants("Consignment");

                    IEnumerable<XElement> loadDetailsNode = root.Descendants("LoadDetails");




                    xDocument.Save(path);
                });
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



            return "success";
        }

        private async Task<string> CreateXML2(string filename, List<BTAS.API.Models.Manifest> template)
        {
            try
            {
                await Task.Run(() =>
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("    ");
                    settings.CloseOutput = true;
                    settings.OmitXmlDeclaration = true;
                    settings.NewLineOnAttributes = true;
                    settings.Async = true;

                    string path = Path.Combine("xml/", filename);

                    XmlWriter xmlWriter = XmlWriter.Create(path, settings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Manifest");

                    foreach (var cons in template)
                    {
                        foreach (Consignment c in cons.Consignments)
                        {
                            xmlWriter.WriteStartElement("Consignment");
                            //xmlWriter.WriteAttributeString("age", "42");
                            xmlWriter.WriteStartElement("ConsignmentNumber");
                            xmlWriter.WriteString(c.ConsignmentNumber);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ConsignmentDate");
                            xmlWriter.WriteString(c.ConsignmentDate);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderName");
                            xmlWriter.WriteString(c.SenderName);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderContact");
                            xmlWriter.WriteString(c.SenderContact);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderPhone");
                            xmlWriter.WriteString(c.SenderPhone);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderEmail");
                            xmlWriter.WriteString(c.SenderEmail);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderStreetAddress");
                            xmlWriter.WriteString(c.SenderStreetAddress);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderStreetAddress1");
                            xmlWriter.WriteString(c.SenderStreetAddress1);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderSuburb");
                            xmlWriter.WriteString(c.SenderSuburb);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderState");
                            xmlWriter.WriteString(c.SenderState);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("SenderPostcode");
                            xmlWriter.WriteString(c.SenderPostcode);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("Pickup");
                            xmlWriter.WriteString(c.Pickup);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("Delivery");
                            xmlWriter.WriteString(c.Delivery);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("DangerousGoods");
                            xmlWriter.WriteString(c.DangerousGoods);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverReference");
                            xmlWriter.WriteString(c.ReceiverReference);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverName");
                            xmlWriter.WriteString(c.ReceiverName);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverContact");
                            xmlWriter.WriteString(c.ReceiverContact);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverPhone");
                            xmlWriter.WriteString(c.ReceiverPhone);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverEmail");
                            xmlWriter.WriteString(c.ReceiverEmail);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverStreetAddress");
                            xmlWriter.WriteString(c.ReceiverStreetAddress);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverStreetAddress1");
                            xmlWriter.WriteString(c.ReceiverStreetAddress1);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverSuburb");
                            xmlWriter.WriteString(c.ReceiverSuburb);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverState");
                            xmlWriter.WriteString(c.ReceiverState);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("ReceiverPostcode");
                            xmlWriter.WriteString(c.ReceiverPostcode);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("TotalWeight");
                            xmlWriter.WriteString(c.TotalWeight);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("AccountCode");
                            xmlWriter.WriteString(c.AccountCode);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("CarrierService");
                            xmlWriter.WriteString(c.CarrierService);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteStartElement("Comments");
                            xmlWriter.WriteString(c.Comments);
                            xmlWriter.WriteEndElement();

                            foreach (LoadDetail ld in c.LoadDetails)
                            {
                                xmlWriter.WriteStartElement("LoadDetails");

                                xmlWriter.WriteStartElement("ItemReference");
                                xmlWriter.WriteString(ld.ItemReference);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("NumberOfUnits");
                                xmlWriter.WriteString(ld.NumberOfUnits);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("LogisticUnit");
                                xmlWriter.WriteString(ld.LogisticUnit);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Weight");
                                xmlWriter.WriteString(ld.Weight);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Length");
                                xmlWriter.WriteString(ld.Length);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Width");
                                xmlWriter.WriteString(ld.Width);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Height");
                                xmlWriter.WriteString(ld.Height);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Cubic");
                                xmlWriter.WriteString(ld.Cubic);
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteStartElement("Barcode");
                                xmlWriter.WriteString(ld.Barcode);
                                xmlWriter.WriteEndElement();

                                xmlWriter.WriteEndElement();///end LoadDetails
                            }

                            xmlWriter.WriteEndElement(); ///end Consignment
                        }
                    }


                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();

                });
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }



            return "success";
        }

        [HttpGet]
        [Route("ping")]
        public string PingTest()
        {
            return "success";
        }
    }
}

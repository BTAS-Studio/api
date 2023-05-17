using BTAS.API;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Dto;
using BTAS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using OpenAPIDoc.Main.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace OpenAPIDoc.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            List<JsonPropertyFields> clientHeader = new();

            ViewBag.apgshipping = GenerateProperties<CreateShippingRequest>();
            ViewBag.apglabel = GenerateProperties<CreateLabelRequest>();

            ViewBag.clientHeader = GenerateProperties<tbl_client_headerDto>();

            ViewBag.contactDetails = GenerateProperties<tbl_client_contact_detailDto>();
            
            ViewBag.container = GenerateProperties<tbl_containerDto>();

            ViewBag.hawb = GenerateProperties<tbl_houseDto>();
            ViewBag.hawbItems = GenerateProperties<tbl_house_itemDto>();

            ViewBag.manifest = GenerateProperties<tbl_manifestDto>();

            ViewBag.mawb = GenerateProperties<tbl_masterDto>();

            ViewBag.parcelInfo = GenerateProperties<tbl_shipmentDto>();
            ViewBag.parcelItems = GenerateProperties<tbl_shipment_itemDto>();
            ViewBag.sku = GenerateProperties<tbl_item_skuDto>();

            ViewBag.receptacle = GenerateProperties<tbl_receptacleDto>();

            ViewBag.voyage = GenerateProperties<tbl_voyageDto>();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<JsonPropertyFields> GenerateProperties<T>()
        {
            IContractResolver resolver = new DefaultContractResolver();

            List<JsonPropertyFields> dto = new();
            var props = typeof(T).GetProperties();

            foreach (var propertyInfo in props.Where(p => !p.IsMarkedWith<DoNotIncludeAttribute>()))
            {
                var att = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                var reg = typeof(T).GetProperty(propertyInfo.Name)
                    .GetCustomAttribute<RegularExpressionAttribute>()?.Pattern; //propertyInfo.GetCustomAttributes<RegularExpressionAttribute>();
                var contract = resolver.ResolveContract(typeof(T)) as JsonObjectContract;
                var dType = propertyInfo.PropertyType.GenericTypeArguments;
                bool isOptional = propertyInfo.IsMarkedWith<OptionalAttribute>();
                bool isRequired = propertyInfo.IsMarkedWith<RequiredAttribute>();
                if (att.Length > 0)
                {
                    var attrib = att[0] as DescriptionAttribute;

                    dto.Add(new JsonPropertyFields
                    {
                        name = contract.Properties.Where(p => !p.Ignored && p.UnderlyingName == propertyInfo.Name).Select(x => x.PropertyName).FirstOrDefault(), //propertyInfo.Name,
                        type = dType.Length > 0 ? dType.First().Name : propertyInfo.PropertyType.Name,
                        description = attrib.Description,
                        values = reg != null ? reg.Split("|").ToList() : null,
                        isOptional = (isRequired ? false : true)
                    });
                }
                else
                {
                    dto.Add(new JsonPropertyFields
                    {
                        name = contract.Properties.Where(p => !p.Ignored && p.UnderlyingName == propertyInfo.Name).Select(x => x.PropertyName).FirstOrDefault(), //propertyInfo.Name,
                        type = dType.Length > 0 ? dType.First().Name : propertyInfo.PropertyType.Name,
                        description = "No desc",
                        values = reg != null ? reg.Split("|").ToList() : null,
                        isOptional = (isRequired ? false : true)
                    });
                }

            }

            return dto;
        }
    }

    
}

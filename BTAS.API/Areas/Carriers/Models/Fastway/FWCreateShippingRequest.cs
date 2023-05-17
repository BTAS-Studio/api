using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Fastway
{
    public class FWCreateShippingRequest
    {
        public FWTo To { get; set; }
        public List<FWItem> Items { get; set; }
        public List<FWService> Services { get; set; }
        public string InstructionsPublic { get; set; }
        public string InstructionsPrivate { get; set; }
        public string ExternalRef1 { get; set; }
        public string ExternalRef2 { get; set; }
    }

    public class FWAddress
    {
        public string StreetAddress { get; set; }
        public string AdditionalDetails { get; set; }
        public string Locality { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class FWItem
    {
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public string PackageType { get; set; }
        public int WeightDead { get; set; }
        public double WeightCubic { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class FWService
    {
        public string ServiceCode { get; set; }
        public string ServiceItemCode { get; set; }
    }

    public class FWTo
    {
        public string ContactCode { get; set; }
        public string BusinessName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public FWAddress Address { get; set; }
    }
}

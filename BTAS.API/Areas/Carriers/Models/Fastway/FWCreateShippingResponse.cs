using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Areas.Carriers.Models.Fastway
{

    public class FWCreateShippingResponse
    {
        public Data data { get; set; }
        public string label { get; set; }
    }

    public class Address
    {
        public int addressId { get; set; }
        public string streetAddress { get; set; }
        public string additionalDetails { get; set; }
        public string locality { get; set; }
        public string postalCode { get; set; }
        public string stateOrProvince { get; set; }
        public string country { get; set; }
        public object fmsLocality { get; set; }
        public object fmsPostalCode { get; set; }
        public string placeId { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public bool userCreated { get; set; }
        public string hash { get; set; }
        public DateTime updatedOn { get; set; }
        public object updatedBy { get; set; }
    }

    public class Data
    {
        public List<Service> services { get; set; }
        public int conId { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
        public int itemCount { get; set; }
        public string barcode2D { get; set; }
        public PickupDetails pickupDetails { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public List<Item> items { get; set; }
        public string fromInstructionsPublic { get; set; }
        public string instructionsPublic { get; set; }
        public string instructionsPrivate { get; set; }
        public string externalRef1 { get; set; }
        public string externalRef2 { get; set; }
        public int pickupTypeId { get; set; }
        public int conTypeId { get; set; }
    }

    public class From
    {
        public string displayName { get; set; }
        public string instructions { get; set; }
        public object streetAddressUser { get; set; }
        public object streetAddressSearch { get; set; }
        public int contactId { get; set; }
        public string code { get; set; }
        public string businessName { get; set; }
        public bool isInternational { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public object version { get; set; }
    }

    public class Item
    {
        public int conItemId { get; set; }
        public string subDepotCode { get; set; }
        public string toRf { get; set; }
        public string toCf { get; set; }
        public string label { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
        public List<Service> services { get; set; }
        public string reference { get; set; }
        public string packageType { get; set; }
        public object myItemId { get; set; }
        public object myItemCode { get; set; }
        public string satchelSize { get; set; }
        public double weightDead { get; set; }
        public double weightCubic { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class PickupDetails
    {
        public DateTime preferredPickupDate { get; set; }
        public int preferredPickupCycleId { get; set; }
    }

    public class Service
    {
        public string code { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
    }

    public class To
    {
        public string displayName { get; set; }
        public string instructions { get; set; }
        public object streetAddressUser { get; set; }
        public object streetAddressSearch { get; set; }
        public int contactId { get; set; }
        public string code { get; set; }
        public string businessName { get; set; }
        public bool isInternational { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public object version { get; set; }
    }
}

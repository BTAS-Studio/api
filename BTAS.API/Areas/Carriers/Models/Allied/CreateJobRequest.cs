//using BTAS.WCF.AlliedWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using TnTWebService;

namespace BTAS.API.Areas.Carriers.Models.Allied
{
	public class CreateJobRequest
    {
		//[XmlRoot(ElementName = "account")]
		//public class Account
		//{

		//	[XmlElement(ElementName = "accountCode")]
		//	public object AccountCode { get; set; }

		//	[XmlElement(ElementName = "accountHash")]
		//	public object AccountHash { get; set; }

		//	[XmlElement(ElementName = "accountKey")]
		//	public object AccountKey { get; set; }

		//	[XmlElement(ElementName = "accountLedger")]
		//	public object AccountLedger { get; set; }

		//	[XmlElement(ElementName = "accountName")]
		//	public object AccountName { get; set; }

		//	[XmlElement(ElementName = "accountState")]
		//	public object AccountState { get; set; }

		//	[XmlElement(ElementName = "defaultAddress")]
		//	public object DefaultAddress { get; set; }

		//	[XmlElement(ElementName = "defaultContact")]
		//	public object DefaultContact { get; set; }

		//	[XmlElement(ElementName = "defaultPhoneNo")]
		//	public object DefaultPhoneNo { get; set; }

		//	[XmlElement(ElementName = "defaultPostCode")]
		//	public object DefaultPostCode { get; set; }

		//	[XmlElement(ElementName = "defaultState")]
		//	public object DefaultState { get; set; }

		//	[XmlElement(ElementName = "defaultSuburbName")]
		//	public object DefaultSuburbName { get; set; }

		//	[XmlElement(ElementName = "discountLevel")]
		//	public object DiscountLevel { get; set; }

		//	[XmlElement(ElementName = "priceSuppressed")]
		//	public object PriceSuppressed { get; set; }

		//	[XmlElement(ElementName = "shippingDivision")]
		//	public object ShippingDivision { get; set; }
		//}

		//[XmlRoot(ElementName = "price")]
		//public class Price
		//{

		//	[XmlElement(ElementName = "chargeQuantity")]
		//	public object ChargeQuantity { get; set; }

		//	[XmlElement(ElementName = "cubicFactor")]
		//	public object CubicFactor { get; set; }

		//	[XmlElement(ElementName = "discountClass")]
		//	public object DiscountClass { get; set; }

		//	[XmlElement(ElementName = "discountRate")]
		//	public object DiscountRate { get; set; }

		//	[XmlElement(ElementName = "grossPrice")]
		//	public object GrossPrice { get; set; }

		//	[XmlElement(ElementName = "jobCode")]
		//	public object JobCode { get; set; }

		//	[XmlElement(ElementName = "netPrice")]
		//	public object NetPrice { get; set; }

		//	[XmlElement(ElementName = "rateCode")]
		//	public object RateCode { get; set; }

		//	[XmlElement(ElementName = "reason")]
		//	public object Reason { get; set; }
		//}

		//[XmlRoot(ElementName = "geographicAddress")]
		//public class GeographicAddress
		//{

		//	[XmlElement(ElementName = "address1")]
		//	public object Address1 { get; set; }

		//	[XmlElement(ElementName = "address2")]
		//	public object Address2 { get; set; }

		//	[XmlElement(ElementName = "country")]
		//	public object Country { get; set; }

		//	[XmlElement(ElementName = "postCode")]
		//	public object PostCode { get; set; }

		//	[XmlElement(ElementName = "sortCode")]
		//	public object SortCode { get; set; }

		//	[XmlElement(ElementName = "state")]
		//	public object State { get; set; }

		//	[XmlElement(ElementName = "suburb")]
		//	public object Suburb { get; set; }
		//}

		//[XmlRoot(ElementName = "vehicle")]
		//public class Vehicle
		//{

		//	[XmlElement(ElementName = "geographicAddress")]
		//	public GeographicAddress GeographicAddress { get; set; }

		//	[XmlElement(ElementName = "vehicleID")]
		//	public object VehicleID { get; set; }
		//}

		//[XmlRoot(ElementName = "Job")]
		//public class Job
		//{

		//	[XmlElement(ElementName = "account")]
		//	public Account Account { get; set; }

		//	[XmlElement(ElementName = "bookedBy")]
		//	public object BookedBy { get; set; }

		//	[XmlElement(ElementName = "bookedDate")]
		//	public object BookedDate { get; set; }

		//	[XmlElement(ElementName = "cancelledDate")]
		//	public object CancelledDate { get; set; }

		//	[XmlElement(ElementName = "chargedDate")]
		//	public object ChargedDate { get; set; }

		//	[XmlElement(ElementName = "closeTime")]
		//	public object CloseTime { get; set; }

		//	[XmlElement(ElementName = "cubicWeight")]
		//	public object CubicWeight { get; set; }

		//	[XmlElement(ElementName = "deliveryDate")]
		//	public object DeliveryDate { get; set; }

		//	[XmlElement(ElementName = "dispatchedDate")]
		//	public object DispatchedDate { get; set; }

		//	[XmlElement(ElementName = "docketNumber")]
		//	public object DocketNumber { get; set; }

		//	[XmlElement(ElementName = "instructions")]
		//	public object Instructions { get; set; }

		//	[XmlElement(ElementName = "itemCount")]
		//	public object ItemCount { get; set; }

		//	[XmlElement(ElementName = "jobNumber")]
		//	public object JobNumber { get; set; }

		//	[XmlElement(ElementName = "jobStatus")]
		//	public object JobStatus { get; set; }

		//	[XmlElement(ElementName = "jobType")]
		//	public object JobType { get; set; }

		//	[XmlElement(ElementName = "notes")]
		//	public object Notes { get; set; }

		//	[XmlElement(ElementName = "pickupDate")]
		//	public object PickupDate { get; set; }

		//	[XmlElement(ElementName = "price")]
		//	public Price Price { get; set; }

		//	[XmlElement(ElementName = "readyDate")]
		//	public object ReadyDate { get; set; }

		//	[XmlElement(ElementName = "scheduledDeliveryDate")]
		//	public object ScheduledDeliveryDate { get; set; }

		//	[XmlElement(ElementName = "scheduledPickupDate")]
		//	public object ScheduledPickupDate { get; set; }

		//	[XmlElement(ElementName = "serviceDescription")]
		//	public object ServiceDescription { get; set; }

		//	[XmlElement(ElementName = "serviceLevel")]
		//	public object ServiceLevel { get; set; }

		//	[XmlElement(ElementName = "validatedHash")]
		//	public object ValidatedHash { get; set; }

		//	[XmlElement(ElementName = "Vehicle")]
		//	public Vehicle Vehicle { get; set; }

		//	[XmlElement(ElementName = "volume")]
		//	public object Volume { get; set; }

		//	[XmlElement(ElementName = "weight")]
		//	public object Weight { get; set; }

		//	[XmlElement(ElementName = "items")]
		//	public TnTWebService.Item[] items { get; set; }

		//	[XmlElement(ElementName = "jobStops")]
		//	public TnTWebService.JobStop[] jobStops { get; set; }
		//}

		[XmlRoot(ElementName = "validateBooking")]
		public class CreateBooking
		{

			[XmlElement(ElementName = "String_1")]
			public string String_1 { get; set; }

			[XmlElement(ElementName = "Job")]
			public Job Job { get; set; }
		}
	}
}

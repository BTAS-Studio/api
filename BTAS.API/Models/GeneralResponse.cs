using System.Collections.Generic;

namespace BTAS.API.Models
{
    public class GeneralResponse
    {
        public bool success { get; set; } = true;
        public int response { get; set; } = 200;
        public string referenceNumber { get; set; }
        //Edited by HS on 20/01/2023
        //public string responseDescription { get; set; } = "success";
        public string responseDescription { get; set; }
        public object result { get; set; }
        public ShipmentData shipmentData { get; set; }
        public LabelData labelData { get; set; }
        public List<string> errorMessages { get; set; }
    }

    public class ShipmentData
    {
        public object shipmentResponse { get; set; }
    }

    public class LabelData
    {
        public object labelResponse{ get; set; }
    }
}

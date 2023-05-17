
namespace BTAS.BlazorApp
{
    public static class SD
    {
        public static string ShipmentApiBase { get; set; }
        public static string CarrierInfoApiBase { get; set; }
        public static string ServiceApiBase { get; set; }
        public static string FreightApiBase { get; set; }
        public static string MawbApiBase { get; set; }
        public static string HawbApiBase { get; set; }
        public static string ContainerApiBase { get; set; }
        public static string AddressBookApiBase { get; set; }
        public static string ContactDetailsApiBase { get; set; }
        public static string IncotermsApiBase { get; set; }
        public static string SettingsApiBase { get; set; }
        public static string FiltersApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

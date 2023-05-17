using AutoMapper;
using BTAS.API.Dto;
using BTAS.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using static BTAS.API.Areas.Carriers.Models.Allied.CreateJobRequest;

namespace BTAS.API
{
    public static class RegisterMaps
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<tbl_manifestDto, tbl_manifest>().ReverseMap();
                config.CreateMap<tbl_addressDto, tbl_address>().ReverseMap();
                config.CreateMap<tbl_xml_templateDto, tbl_xml_template>().ReverseMap();
                config.CreateMap<tbl_carrier_infoDto, tbl_carrier_info>().ReverseMap();
                config.CreateMap<tbl_shippersDto, tbl_shippers>().ReverseMap();
                config.CreateMap<tbl_servicesDto, tbl_services>().ReverseMap();
                config.CreateMap<tbl_shipment_searchDto, tbl_shipment_search_response>().ReverseMap();
                //config.CreateMap<tbl_masterDto, tbl_master>().ReverseMap();
                //config.CreateMap<tbl_houseDto, tbl_house>().ReverseMap();
                config.CreateMap<tbl_house_itemDto, tbl_house_item>().ReverseMap();
                config.CreateMap<tbl_item_skuDto, tbl_item_sku>().ReverseMap();
                config.CreateMap<tbl_default_settingDto, tbl_default_setting>().ReverseMap();

                config.CreateMap<tbl_masterDto, tbl_master>()
                    .ForMember(dest => dest.houses, opt => opt.MapFrom(src => src.houses))
                    .ForMember(dest => dest.containers, opt => opt.MapFrom(src => src.containers))
                    .ForMember(dest => dest.originAgent, opt => opt.MapFrom(src => src.originAgent))
                    .ForMember(dest => dest.destinationAgent, opt => opt.MapFrom(src => src.destinationAgent))
                    .ForMember(dest => dest.carrierAgent, opt => opt.MapFrom(src => src.carrierAgent))
                    .ForMember(dest => dest.creditorAgent, opt => opt.MapFrom(src => src.creditorAgent))
                    .ForMember(dest => dest.voyage, opt => opt.MapFrom(src => src.voyage))
                    .ForMember(dest => dest.tbl_master_status, opt => opt.Condition(src => src.tbl_master_status != null))
                    .ForMember(dest => dest.idtbl_master, opt => opt.Ignore())
                    .ReverseMap();

                config.CreateMap<tbl_houseDto, tbl_house>()
                    //.ForMember(dest => dest.tbl_container, opt => opt.MapFrom(src => src.tbl_container))
                    .ForMember(dest => dest.receptacles, opt => opt.MapFrom(src => src.receptacles))
                    .ForMember(dest => dest.houseItems, opt => opt.MapFrom(src => src.houseItems))
                    .ForMember(dest => dest.tbl_house_status, opt => opt.Condition(src => src.tbl_house_status != null))
                    .ForMember(dest => dest.idtbl_house, opt => opt.Ignore())
                    .ReverseMap();

                config.CreateMap<tbl_house_itemDto, tbl_house_item>()
                    .ForMember(dest => dest.itemSkus, opt => opt.MapFrom(src => src.itemSkus))
                    .ForMember(dest => dest.idtbl_house_item, opt => opt.Ignore())
                    .ReverseMap();

                config.CreateMap<tbl_receptacleDto, tbl_receptacle>()
                    .ForMember(dest => dest.house, opt => opt.MapFrom(src => src.house))
                    .ForMember(dest => dest.tbl_house_id, opt => opt.MapFrom(src => src.tbl_house_id))
                   .ForMember(dest => dest.shipments, opt => opt.MapFrom(src => src.shipments))
                   .ForMember(dest => dest.tbl_receptacle_status, opt => opt.Condition(src => src.tbl_receptacle_status != null))
                   .ForMember(dest => dest.idtbl_receptacle, opt => opt.Ignore())
                   .ReverseMap();

                config.CreateMap<tbl_shipmentDto, tbl_shipment>()
                    //.ForMember(dest => dest.parcelItems, opt => opt.MapFrom(src => src.parcelItems))
                    //.ForMember(dest => dest.receptacle, opt => opt.MapFrom(src => src.receptacle))
                    .ForMember(dest => dest.tbl_shipment_status, opt => opt.Condition(src => src.tbl_shipment_status != null))
                    .ForMember(dest => dest.idtbl_shipment, opt => opt.Ignore())
                    .ReverseMap();

                config.CreateMap<tbl_shipment_itemDto, tbl_shipment_item>()
                    //.ForMember(dest => dest.tbl_item_sku, opt => opt.MapFrom(src => src.tbl_item_sku))
                    .ForMember(dest => dest.idtbl_shipment_item, opt => opt.MapFrom(src => src.idtbl_shipment_item))
                    .ReverseMap();

                config.CreateMap<tbl_incotermDto, tbl_incoterm>()
                    .ForMember(dest => dest.idtbl_incoterm, opt => opt.MapFrom(src => src.idtbl_incoterm))
                    .ForMember(dest => dest.tbl_incoterm_code, opt => opt.MapFrom(src => src.tbl_incoterm_code))
                    //.ForMember(dest => dest.ho, opt => opt.MapFrom(src => src.house))
                    .ReverseMap();

                config.CreateMap<tbl_client_headerDto, tbl_client_header>()
                    .ForMember(dest => dest.contactDetails, opt => opt.MapFrom(src => src.contactDetails))
                    //.ForMember(dest => dest.tbl_house_incoterms, opt => opt.MapFrom(src => src.tbl_house_incoterms))
                    //Comment out by HS on 8/12/2022, as house_id in tbl_client_header is deleted in db
                    //.ForMember(dest => dest.tbl_house, opt => opt.MapFrom(src => src.tbl_house))
                    .ReverseMap();

                config.CreateMap<tbl_client_contact_groupDto, tbl_client_contact_group>()
                    .ForMember(dest => dest.idtbl_client_contact_group, opt => opt.MapFrom(src => src.idtbl_client_contact_group))
                    //.ForMember(dest => dest.contactDetails, opt => opt.MapFrom(src => src.contactDetails))
                    .ReverseMap();

                config.CreateMap<tbl_client_contact_detailDto, tbl_client_contact_detail>()
                   .ForMember(dest => dest.idtbl_client_contact_detail, opt => opt.MapFrom(src => src.idtbl_client_contact_detail))
                   //.ForMember(dest => dest.contactGroups, opt => opt.MapFrom(src => src.contactGroups))
                   .ReverseMap();

                config.CreateMap<tbl_routingDto, tbl_routing>()
                   .ForMember(dest => dest.voyage, opt => opt.MapFrom(src => src.voyage))
                    .ForMember(dest => dest.idtbl_routing, opt => opt.Ignore())
                   .ReverseMap();

                config.CreateMap<tbl_containerDto, tbl_container>()
                   .ForMember(dest => dest.houses, opt => opt.MapFrom(src => src.houses))
                   .ForMember(dest => dest.tbl_container_status, opt => opt.Condition(src => src.tbl_container_status != null))
                    .ForMember(dest => dest.idtbl_container, opt => opt.Ignore())
                   .ReverseMap();

                config.CreateMap<tbl_voyageDto, tbl_voyage>()
                    .ForMember(dest => dest.masters, opt => opt.MapFrom(src => src.masters))
                    .ForMember(dest => dest.tbl_voyage_status, opt => opt.Condition(src => src.tbl_voyage_status != null))
                    .ForMember(dest => dest.idtbl_voyage, opt => opt.Ignore())
                    .IgnoreNoMap()
                    .ReverseMap();

                //config.CreateMap<TnTWebService.Account, Account>().ReverseMap();
                //config.CreateMap<TnTWebService.Price, Price>().ReverseMap();
                //config.CreateMap<TnTWebService.Job, Job>().ReverseMap();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }
}

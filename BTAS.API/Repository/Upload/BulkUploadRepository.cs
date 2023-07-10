using AutoMapper;
using BTAS.API.Dto;
using BTAS.Data.Models;
using System;
using System.Threading.Tasks;

namespace BTAS.API.Repository.Upload
{
    public class BulkUploadRepository
    {
        private readonly MainDbContext _context;
        private readonly VoyageRepository _voyageRepository;
        private readonly MasterRepository _masterRepository;
        private readonly ContainerRepository _containerRepository;
        private readonly HouseRepository _houseRepository;
        private readonly HouseItemRepository _houseItemRepository;
        private readonly ReceptacleRepository _reptacleRepository;
        private readonly IncotermRepository _incotermRepository;
        private readonly ShipmentRepository _shipmentRepository;
        private readonly ShipmentItemRepository _shipmentItemRepository;
        private readonly ItemSkuRepository _itemSkuRepository;
        private readonly ClientHeaderRepository _clientHeaderRepository;
        private readonly AddressRepository _addressRepository;


        private IMapper _mapper;

        private int count;

        public BulkUploadRepository (MainDbContext context, IMapper mapper, 
            VoyageRepository voyageRepository, MasterRepository masterRepository, ContainerRepository containerRepository,
            HouseRepository houseRepository, HouseItemRepository houseItemRepository, ReceptacleRepository receptacleRepository,
            IncotermRepository incotermRepository, ShipmentRepository shipmentRepository, ShipmentItemRepository shipmentItemRepository,
            ItemSkuRepository itemSkuRepository, AddressRepository addressRepository, ClientHeaderRepository clientHeaderRepository)
        {
            _context = context;
            _mapper = mapper;
            _voyageRepository = voyageRepository;
            _masterRepository = masterRepository;
            _containerRepository = containerRepository;
            _houseRepository = houseRepository;
            _houseItemRepository = houseItemRepository;
            _reptacleRepository = receptacleRepository;
            _shipmentRepository = shipmentRepository;
            _shipmentItemRepository = shipmentItemRepository;
            _itemSkuRepository = itemSkuRepository;
            _incotermRepository = incotermRepository;
            _clientHeaderRepository = clientHeaderRepository;
            _addressRepository = addressRepository;

            count = 1;
        }

        public async Task<ResponseDto> UploadAsync(tbl_voyageDto entity)
        {
            try
            {
                var result = _mapper.Map<tbl_voyage>(entity);

                string referenceNumber = await _voyageRepository.GetNextId();
                result.tbl_voyage_code = referenceNumber;
                result.tbl_voyage_status = "OPEN";

                if (result.idtbl_voyage > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate voyage record",
                        IsSuccess = false
                    };
                }

                //Added by HS on 26/06/2023
                if (result.houses.Count > 0)
                {

                }
                //Added by HS on 01/02/2023 
                if (result.masters.Count > 0)
                {
                    foreach (var master in result.masters)
                    {
                        //Generate master reference
                        master.tbl_master_code = await _masterRepository.GetNextId();
                        //link master to voyage
                        master.VoyageCode = referenceNumber;
                        //Master Sea
                        if (master.containers.Count != 0)
                        {
                            foreach (var container in master.containers)
                            {
                                container.tbl_container_code = await _containerRepository.GetNextId();
                                container.MasterCode = master.tbl_master_code;
                                if (container.houses.Count != 0)
                                {
                                    foreach (var house in container.houses)
                                    {
                                        house.tbl_house_code = await _houseRepository.GetNextId();
                                        house.ContainerCode = container.tbl_container_code;
                                        house.tbl_master_id = container.tbl_master_id;
                                        house.MasterCode = container.MasterCode;
                                        //if (house.receptacles.Count != 0)
                                        //{
                                        //    foreach (var receptacle in house.receptacles)
                                        //    {
                                        //        receptacle.tbl_receptacle_code = await _receptacleRepo.GetNextId(shipperId);
                                        //        receptacle.HouseCode = house.tbl_house_code;
                                        //    }
                                        //}
                                    }
                                }
                            }
                        }
                        //Master Air
                        else if (master.houses.Count != 0)
                        {
                            foreach (var house in master.houses)
                            {
                                house.tbl_house_code = await _houseRepository.GetNextId();
                                house.MasterCode = master.tbl_master_code;
                                //if (house.receptacles.Count != 0)
                                //{
                                //    foreach (var receptacle in house.receptacles) 
                                //    {
                                //        receptacle.tbl_receptacle_code = await _receptacleRepo.GetNextId(shipperId);
                                //        receptacle.HouseCode = house.tbl_house_code;
                                //    }
                                //}
                            }
                        }
                    }
                }

                await _context.tbl_voyages.AddAsync(result);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Voyage successfully created.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_voyage_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }
        }
    }
}

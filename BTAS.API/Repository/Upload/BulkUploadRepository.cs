using AutoMapper;
using BTAS.API.Dto;
using BTAS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public BulkUploadRepository(MainDbContext context, IMapper mapper,
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

        public async Task<ResponseDto> BulkUploadAsync(tbl_voyageDto entity)
        {
            try
            {
                //if ef core 6 can automatically populate FKs???

                //var result = _mapper.Map<tbl_voyage>(entity);

                string referenceNumber = await _voyageRepository.GetNextId();
                entity.tbl_voyage_code = referenceNumber;
                entity.tbl_voyage_status = "Active";
                //voyage link to master
                if (entity.masters.Count > 0 && entity.houses.Count == 0)
                {
                    await ProcessMastersAsync(entity.masters, referenceNumber);
                }
                //voyage directly link to house case, not implemented
                else if (entity.houses.Count > 0 && entity.masters.Count == 0)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "Unimplemented Case."
                    };
                }
                //both master and house count > 0
                else
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "Invalid Voyage Children."
                    };
                }
                var result = _mapper.Map<tbl_voyage>(entity);
                await _context.tbl_voyages.AddAsync(result);
                await _context.SaveChangesAsync();
                return new ResponseDto
                {
                    DisplayMessage = "Voyage successfully created.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_voyage_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message.ToString()
                };
            }
        }

   
        private async Task ProcessMastersAsync(ICollection<tbl_masterDto> masters, string referenceNumber)
        {
            foreach (var master in masters)
            {
                // Generate master reference
                master.tbl_master_code = await _masterRepository.GetNextId();
                // Link master to voyage
                master.VoyageCode = referenceNumber;

                #region Master.clientHeaders
                // Process FK client header codes
                var agents = new List<(tbl_client_headerDto agent, Action<string> setAgentCode)>
                {
                    (master.originAgent, code => master.originAgentCode = code),
                    (master.destinationAgent, code => master.destinationAgentCode = code),
                    (master.carrierAgent, code => master.carrierAgentCode = code),
                    (master.creditorAgent, code => master.creditorAgentCode = code)
                };
                await SetClientHeaderCode(agents);
                #endregion

                #region Master Sea
                //Master Sea
                if (master.containers.Count > 0 && master.houses.Count == 0)
                {
                    await ProcessContainersAsync(master.containers, master.tbl_master_code);
                }
                #endregion
                #region Master Air
                //Master Air
                if (master.houses.Count > 0 && master.containers.Count == 0)
                {
                    await ProcessHouseseAsync(master.houses, master.tbl_master_code);
                }
                #endregion
            }
        }

        private async Task ProcessContainersAsync(ICollection<tbl_containerDto> containers, string referenceNumber)
        {
            foreach (var container in containers)
            {
                container.tbl_container_code = await _containerRepository.GetNextId();
                container.MasterCode = referenceNumber;
                if (container.houses.Count != 0)
                {
                    await ProcessHouseseAsync(container.houses, container.tbl_container_code);
                }
            }
        }

        private async Task ProcessHouseseAsync(ICollection<tbl_houseDto> houses, string referenceNumber)
        {
            foreach (var house in houses)
            {
                house.tbl_house_code = await _houseRepository.GetNextId();
                house.ContainerCode = referenceNumber;
                #region house.clientHeaders
                var agents = new List<(tbl_client_headerDto agent, Action<string> setAgentCode)>
                {
                    (house.consignor, code => house.ConsigneeCode = code),
                    (house.consignee, code => house.ConsigneeCode = code),
                    (house.pickupClientDetail, code => house.PickupClientCode = code)
                    //(house.deliveryClientDetail, code => house.DeliveryClientCode = code)
                };
                await SetClientHeaderCode(agents);
                #region house.deliveryClientDetail & linked address
                house.pickupClientDetail.tbl_client_header_code = await GetClientHeaderCode(house.pickupClientDetail);
                #endregion

                #endregion house.clientHeaders

                #region house.items 
                // STD(high value)
                if (house.houseItems.Count > 0 && house.receptacles.Count == 0)
                {
                    foreach (var houseItem in house.houseItems)
                    {
                        houseItem.tbl_house_item_code = await _houseItemRepository.GetNextId();
                        houseItem.HouseCode = house.tbl_house_code;
                        //item_skus
                    }
                }
                #endregion

                #region house.receptacles
                // CBD(combined) and HVLV(low value)
                if (house.receptacles.Count > 0 && house.houseItems.Count == 0)
                {
                    await ProcessReceptacleAsync(house.receptacles, house.tbl_house_code);
                }
                #endregion
            }
        }

        private async Task ProcessReceptacleAsync(ICollection<tbl_receptacleDto> receptacles, string referenceNumber)
        {
            foreach (var receptacle in receptacles)
            {
                receptacle.tbl_receptacle_code = await _reptacleRepository.GetNextId();
                receptacle.HouseCode = referenceNumber;
                if (receptacle.shipments.Count > 0)
                {
                    await ProcessShipmentAsync(receptacle.shipments, receptacle.tbl_receptacle_code);
                }
            }
        }
        private async Task ProcessShipmentAsync(ICollection<tbl_shipmentDto> shipments, string referenceNumber)
        {
            foreach (var shipment in shipments)
            {
                shipment.tbl_shipment_code = await _shipmentRepository.GetNextId();
                shipment.ReceptacleCode = referenceNumber;
                //if (shipment.shipmentItems.Count > 0)
                //{
                //    foreach (var shipmentItem in shipment.shipmentItems)
                //    {
                //        shipmentItem.tbl_shipment_item_code = await _shipmentItemRepository.GetNextId();
                //        shipmentItem.ShipmentCode = shipment.tbl_shipment_code;
                //        //item_skus
                //    }
                //}
            }
        }

        private async Task ProcessItemSkuAsync(ICollection<tbl_item_skuDto> itemSkus)
        {
            throw new NotImplementedException();
        }

        private async Task SetClientHeaderCode(List<(tbl_client_headerDto agent, Action<string> setAgentCode)> agents)
        {
            try
            {
                // Use async parallel processing for improved performance
                var tasks = agents.Select(async agentTuple =>
                {
                    var (agent, setAgentCode) = agentTuple;
                    if (agent != null)
                    {
                        var getResult = await _clientHeaderRepository.CreateUpdateAsync(agent);
                        if (getResult.IsSuccess)
                        {
                            setAgentCode(getResult.ReferenceNumber);
                        }
                        else
                        {
                            throw new Exception(getResult.DisplayMessage); // Or handle error as required
                        }
                    }
                });
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private async Task<string> GetClientHeaderCode(tbl_client_headerDto clientHeader)
        {
            try
            {
                //create its delivery address
                var address = new tbl_addressDto();
                address.tbl_address_isDelivery = true;
                address.tbl_address_companyName = clientHeader.tbl_client_header_companyName;
                address.tbl_address_contactName = clientHeader.tbl_client_header_contactName;
                address.tbl_address_email = clientHeader.tbl_client_header_email;
                address.tbl_address_phone = clientHeader.tbl_client_header_phone;
                address.tbl_address_abn = clientHeader.tbl_client_header_abn;
                address.tbl_address_address1 = clientHeader.tbl_client_header_address1;
                address.tbl_address_address2 = clientHeader.tbl_client_header_address2;
                address.tbl_address_suburb = clientHeader.tbl_client_header_suburb;
                address.tbl_address_state = clientHeader.tbl_client_header_state;
                address.tbl_address_postcode = clientHeader.tbl_client_header_postcode;
                address.tbl_address_country = clientHeader.tbl_client_header_country;

                var checkResult = await _clientHeaderRepository.DuplicationCheck(clientHeader);
                //if new
                if (checkResult.IsSuccess == false && checkResult.DisplayMessage == "1")
                {
                    //create this new client header
                    var createResult = await _clientHeaderRepository.CreateAsync(clientHeader);
                    if (!createResult.IsSuccess)
                    {
                        throw new Exception(createResult.DisplayMessage);
                    }
                    //create its linked address
                    var addrResult = await _addressRepository.CreateAsync(address);
                    if (!addrResult.IsSuccess)
                    {
                        throw new Exception(addrResult.DisplayMessage + " Client Header:" + clientHeader.tbl_client_header_code);
                    }

                    //link the address to the client header
                    var linkResult = await _clientHeaderRepository.AddAddressAsync(createResult.ReferenceNumber, addrResult.ReferenceNumber);
                    if (!linkResult.IsSuccess)
                    {
                        throw new Exception(linkResult.DisplayMessage + " Client Header:" + createResult.ReferenceNumber 
                            + " Address:" + addrResult.ReferenceNumber);
                    }

                    return createResult.ReferenceNumber;
                }
                //if existed
                else if (checkResult.IsSuccess == true)
                {
                    clientHeader.tbl_client_header_code = checkResult.ReferenceNumber;
                    //update client header
                    var updateResult = await _clientHeaderRepository.UpdateAsync(clientHeader);
                    if (!updateResult.IsSuccess)
                    {
                        throw new Exception(updateResult.DisplayMessage);
                    }
                    //update its linked address
                    //1. get the address id
                    address.idtbl_address = await _addressRepository.GetIdAsync(address);
                    //2. update with the new address
                    if (address.idtbl_address == 0)
                    {
                        throw new Exception("Failed to update address");
                    }
                    var addrResult = await _addressRepository.UpdateAsync(address);
                    if (!addrResult.IsSuccess)
                    {
                        throw new Exception(addrResult.DisplayMessage);
                    }

                    return clientHeader.tbl_client_header_code;
                }
                else
                {
                    throw new Exception(checkResult.DisplayMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //private async Task<tbl_addressDto> GetAddressCode(tbl_client_headerDto clientHeader)
        //{
        //    var address = new tbl_addressDto();
        //    address.tbl_address_isDelivery = true;
        //    address.tbl_address_companyName = clientHeader.tbl_client_header_companyName;
        //    address.tbl_address_contactName = clientHeader.tbl_client_header_contactName;
        //    address.tbl_address_email = clientHeader.tbl_client_header_email;
        //    address.tbl_address_phone = clientHeader.tbl_client_header_phone;
        //    address.tbl_address_abn = clientHeader.tbl_client_header_abn;
        //    address.tbl_address_address1 = clientHeader.tbl_client_header_address1;
        //    address.tbl_address_address2 = clientHeader.tbl_client_header_address2;
        //    address.tbl_address_suburb = clientHeader.tbl_client_header_suburb;
        //    address.tbl_address_state = clientHeader.tbl_client_header_state;
        //    address.tbl_address_postcode = clientHeader.tbl_client_header_postcode;
        //    address.tbl_address_country = clientHeader.tbl_client_header_country;

        //    var checkResult = await _addressRepository.DuplicationCheck(address);
        //    //if new
        //    if (checkResult.IsSuccess == false && checkResult.DisplayMessage == "1")
        //    {
        //        //create this new client header
        //        var createResult = await _addressRepository.CreateAsync(address);
        //        if (createResult.IsSuccess)
        //        {
        //            address.tbl_address_code = createResult.ReferenceNumber;
        //        }
        //        else
        //        {
        //            throw new Exception(createResult.DisplayMessage);
        //        }
        //    }
        //    //if existed
        //    else if (checkResult.IsSuccess == true)
        //    {
        //        address.tbl_address_code = checkResult.ReferenceNumber;
        //        var updateResult = await _addressRepository.UpdateAsync(address);
        //        if (!updateResult.IsSuccess)
        //        {
        //            throw new Exception(updateResult.DisplayMessage);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Unhandled exception: Failed to get client header code.");
        //    }
        //    return address;
        //}
    }
}

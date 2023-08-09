using AutoMapper;
using BTAS.API.Dto;
using BTAS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Core;

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

        private readonly NoteRepository _noteRepository;
        private readonly NoteCategoryRepository _noteCategoryRepository;
        private readonly MilestoneHeaderRepository _milestoneHeaderRepository;
        private readonly MilestoneLinkRepository _milestoneLinkRepository;

        private IMapper _mapper;
        private int count;
        private static string NOTE_CATEGORY_NAME;
        private static int NOTE_CATEGORY_ID;
        private static string NOTE_CATEGORY_CODE;
        public  BulkUploadRepository(MainDbContext context, IMapper mapper,
            VoyageRepository voyageRepository, MasterRepository masterRepository, ContainerRepository containerRepository,
            HouseRepository houseRepository, HouseItemRepository houseItemRepository, ReceptacleRepository receptacleRepository,
            IncotermRepository incotermRepository, ShipmentRepository shipmentRepository, ShipmentItemRepository shipmentItemRepository,
            ItemSkuRepository itemSkuRepository, AddressRepository addressRepository, ClientHeaderRepository clientHeaderRepository, 
            NoteRepository noteRepository, NoteCategoryRepository noteCategoryRepository, 
            MilestoneHeaderRepository milestoneHeaderRepository, MilestoneLinkRepository milestoneLinkRepository)
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

            _noteRepository = noteRepository;
            _noteCategoryRepository = noteCategoryRepository;
            _milestoneHeaderRepository = milestoneHeaderRepository;
            _milestoneLinkRepository = milestoneLinkRepository;

            count = 1;
            NOTE_CATEGORY_NAME = "Delivery";

        }

        public async Task<ResponseDto> BulkUploadAsync(tbl_voyageDto entity)
        {
            try
            {
                //Get note category id and code first
                (NOTE_CATEGORY_ID, NOTE_CATEGORY_CODE) = await ProcessNoteCategoryAsync(NOTE_CATEGORY_NAME);

                var result = _mapper.Map<tbl_voyage>(entity);

                string referenceNumber = await _voyageRepository.GetNextId();
                result.tbl_voyage_code = referenceNumber;
                result.tbl_voyage_status = "Active";
                //voyage link to master
                if (result.masters.Count > 0 && result.houses.Count == 0)
                {
                    await ProcessMastersAsync(result.masters, referenceNumber);
                }
                //voyage directly link to house case, not implemented
                else if (result.houses.Count > 0 && result.masters.Count == 0)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "Unimplemented Case."
                    };
                }
                //both master and house count > 0
                else if (result.houses.Count > 0 && result.masters.Count > 0)
                {
                    return new ResponseDto
                    {
                        IsSuccess = false,
                        DisplayMessage = "Invalid Voyage Children."
                    };
                }

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
                    DisplayMessage = ex.Message + " " + ex.InnerException.Message
                };
            }
        }

   
        private async Task ProcessMastersAsync(ICollection<tbl_master> masters, string referenceNumber)
        {
            foreach (var master in masters)
            {
                // Generate master reference
                master.tbl_master_code = await _masterRepository.GetNextId();
                // Link master to voyage
                master.VoyageCode = referenceNumber;

                #region Master.clientHeaders
                // Process FK client header codes
                var agents = new List<(tbl_client_header agent, Action<int> setAgentId, Action<string> setAgentCode)>
                {
                    (master.originAgent, (id) => master.tbl_client_header_origin_id = id, (code) => master.originAgentCode = code),
                    (master.destinationAgent, (id) => master.tbl_client_header_destination_id = id, (code) => master.destinationAgentCode = code),
                    (master.carrierAgent, (id) => master.tbl_client_header_carrier_id = id, (code) => master.carrierAgentCode = code),
                    (master.creditorAgent, (id) => master.tbl_client_header_creditor_id = id, (code) => master.creditorAgentCode = code)
                };

                await SetClientHeaderIdNCode(agents);
                #region Master.Notes
                if (master.notes.Count > 0)
                {
                    await ProcessNotesAsync(master.notes, master.tbl_master_code, "MS");
                    //master.notes.Clear();
                }
                #endregion
                // empty master.clentheader while keep master's FK client header
                master.carrierAgent = null;
                master.creditorAgent = null;
                master.originAgent = null;
                master.destinationAgent = null;

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

        private async Task ProcessContainersAsync(ICollection<tbl_container> containers, string referenceNumber)
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

        private async Task ProcessHouseseAsync(ICollection<tbl_house> houses, string referenceNumber)
        {
            try
            {
                foreach (var house in houses)
                {
                    house.tbl_house_code = await _houseRepository.GetNextId();
                    house.ContainerCode = referenceNumber;
                    #region house.clientHeaders
                    var agents = new List<(tbl_client_header agent, Action<int> setAgentId, Action<string> setAgentCode)>
                {
                    (house.consignor, id => house.tbl_consignor_id = id, code => house.ConsignorCode = code),
                    (house.consignee, id => house.tbl_consignee_id = id, code => house.ConsigneeCode = code),
                    (house.pickupClientDetail, id => house.tbl_pickupClient_id = id, code => house.PickupClientCode = code)
                    //(house.deliveryClientDetail, code => house.DeliveryClientCode = code)
                };
                    await SetClientHeaderIdNCode(agents);
                    #region house.deliveryClientDetail & linked address

                    (house.tbl_deliveryClient_id, house.DeliveryClientCode)
                        = await GetClientHeaderCode(house.deliveryClientDetail);
                    #endregion
                    house.consignee = null;
                    house.consignor = null;
                    house.pickupClientDetail = null;
                    house.deliveryClientDetail = null;
                    #endregion house.clientHeaders

                    #region house.items 
                    // STD(high value)
                    if (house.houseItems.Count > 0 && house.receptacles.Count == 0)
                    {
                        await ProcessHouseItemAsync(house.houseItems, house.tbl_house_code);
                    }
                    #endregion

                    #region house.receptacles
                    // CBD(combined) and HVLV(low value)
                    if (house.receptacles.Count > 0 && house.houseItems.Count == 0)
                    {
                        await ProcessReceptacleAsync(house.receptacles, house.tbl_house_code);
                    }
                    #endregion

                    #region house.notes
                    if (house.notes.Count > 0)
                    {
                        await ProcessNotesAsync(house.notes, house.tbl_house_code, "HS");
                        //house.notes.Clear();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException.ToString());
            }
        }

        private async Task ProcessHouseItemAsync(ICollection<tbl_house_item> houseItems, string referenceNumber)
        {
            foreach (var houseItem in houseItems)
            {
                houseItem.tbl_house_item_code = await _houseItemRepository.GetNextId();
                houseItem.HouseCode = referenceNumber;
                //process itemSKU
            }
        }
        private async Task ProcessReceptacleAsync(ICollection<tbl_receptacle> receptacles, string referenceNumber)
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
        private async Task ProcessShipmentAsync(ICollection<tbl_shipment> shipments, string referenceNumber)
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
                #region shipment.notes
                if (shipment.notes.Count > 0)
                {
                    await ProcessNotesAsync(shipment.notes, shipment.tbl_shipment_code, "SM");
                    //shipment.notes.Clear();
                }
                #endregion
            }
        }

        private async Task ProcessItemSkuAsync(ICollection<tbl_item_sku> itemSkus)
        {
            throw new NotImplementedException();
        }

        /* This function create/update the master/house's  client headers,
        *  create the notes linked to the client headers,
        *  and finally set the FK id and code of this master/house linking to its client headers.
        * */
        private async Task SetClientHeaderIdNCode(List<(tbl_client_header agent, Action<int> setAgentId, Action<string> setAgentCode)> agents)
        {
            try
            {
                //ICollection<tbl_note> notes = new Collection<tbl_note>();
                //Use async parallel processing for improved performance

               var tasks = agents.Select(async agentTuple =>
                {
                    var (agent, setAgentId, setAgentCode) = agentTuple;
                    if (agent != null)
                    {
                        //stop notes created by convention when client header is created.
                        //if (agent.notes != null)
                        //{
                        //    notes = agent.notes.ToList();
                        //    agent.notes = null;
                        //}
                        var agentDto = _mapper.Map<tbl_client_headerDto>(agent);
                        var getResult = await _clientHeaderRepository.CreateUpdateAsync(agentDto);

                        if (!getResult.IsSuccess)
                        {
                            throw new Exception(getResult.DisplayMessage); // Or handle error as required
                        }
                        setAgentId(getResult.Id);
                        setAgentCode(getResult.ReferenceNumber);

                        //process client header's notes
                        //if (notes.Count > 0)
                        //{
                        //    await ProcessNotesAsync(notes, getResult.ReferenceNumber, getResult.Id);
                        //}
                    }
                });
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        /* This function create/update the address linked to the delivery client header,
         *  create the notes linked to the delivery client header,
         *  and finally return the id and code of this client header.
         * */
        private async Task<(int, string)> GetClientHeaderCode(tbl_client_header clientHeader)
        {
            try
            {
                //ICollection<tbl_note> notes = new Collection<tbl_note>();
                //stop notes created by convention when client header is created.
                //if (clientHeader.notes != null)
                //{
                //    //notes = clientHeader.notes.ToList();
                //    clientHeader.notes.Clear();
                //}

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

                var clientHeaderDto = _mapper.Map<tbl_client_headerDto>(clientHeader);
                var checkResult = await _clientHeaderRepository.DuplicationCheck(clientHeaderDto);
                //if new
                if (checkResult.IsSuccess == false && checkResult.ReferenceNumber == "1")
                {
                    //create this new client header
                    var createResult = await _clientHeaderRepository.CreateAsync(clientHeaderDto);
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

                    #region deliveryClient.notes
                    //if (notes.Count > 0)
                    //{
                    //    await ProcessNotesAsync(notes, createResult.ReferenceNumber, createResult.Id);
                    //}
                    #endregion
                    return (createResult.Id, createResult.ReferenceNumber);
                }
                //if existed
                else if (checkResult.IsSuccess == true)
                {
                    clientHeader.idtbl_client_header = checkResult.Id;
                    clientHeader.tbl_client_header_code = checkResult.ReferenceNumber;
                    clientHeaderDto.tbl_client_header_code = checkResult.ReferenceNumber;
                    //update client header
                    var updateResult = await _clientHeaderRepository.UpdateAsync(clientHeaderDto);
                    if (!updateResult.IsSuccess)
                    {
                        throw new Exception(updateResult.DisplayMessage);
                    }
                    //update its linked address
                    //1. get the address code
                    address.tbl_address_code = await _addressRepository.GetCodeAsync(address);
                    //2. update with the new address
                    if (address.tbl_address_code == null)
                    {
                        throw new Exception("Failed to update address");
                    }
                    var addrResult = await _addressRepository.UpdateAsync(address);
                    if (!addrResult.IsSuccess)
                    {
                        throw new Exception(addrResult.DisplayMessage);
                    }

                    #region deliveryClient.notes
                    //if (notes.Count > 0)
                    //{
                    //    await ProcessNotesAsync(notes, checkResult.ReferenceNumber, checkResult.Id);
                    //}
                    #endregion
                    return (clientHeader.idtbl_client_header, clientHeader.tbl_client_header_code);
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

        //process client header notes
        private async Task ProcessNotesAsync(ICollection<tbl_note> notes, string referenceNumber, int id)
        {
            try
            {
                foreach (var note in notes)
                {
                    note.tbl_client_header_id = id;
                    note.ClientHeaderCode = referenceNumber;

                    (note.tbl_note_category_id, note.NoteCategoryCode) = (NOTE_CATEGORY_ID, NOTE_CATEGORY_CODE);
                    var noteDto = _mapper.Map<tbl_noteDto>(note);
                    var createResult = await _noteRepository.CreateAsync(noteDto);
                    if (!createResult.IsSuccess)
                    {
                        throw new Exception(createResult.DisplayMessage);
                    }
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message + ex.InnerException.ToString());
            }

        }

        //process jobs(master/house/shipment) notes
        private async Task ProcessNotesAsync(ICollection<tbl_note> notes, string referenceNumber, string tName)
        {
            try
            {
                foreach (var note in notes)
                {

                    note.tbl_note_code = await _noteRepository.GetNextId();
                    note.tbl_note_status = true;
                    note.tbl_note_createdDate = DateTime.Now;
                    (note.tbl_note_category_id, note.NoteCategoryCode) = (NOTE_CATEGORY_ID, NOTE_CATEGORY_CODE);
                    //id is assigned by convention by ef core, deal with code only

                    if (tName == "SM")
                    {
                        note.ShipmentCode = referenceNumber;
                    }
                    else if (tName == "HS")
                    {
                        note.HouseCode = referenceNumber;
                    }
                    else if (tName == "MS")
                    {
                        note.MasterCode = referenceNumber;
                    }
                    else
                    {
                        throw new Exception($"Note {tName}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException.ToString());
            }
        }

        //get note category("Delivery") Id and code
        private async Task<(int, string)> ProcessNoteCategoryAsync(string noteCategoryName)
        {
            try
            {
                //check duplicate
                var checkResult = await _noteCategoryRepository.GetByNameAsync(noteCategoryName);

                //if new => create and return id and code
                if (!checkResult.IsSuccess)
                {
                    tbl_note_categoryDto ncDto = new tbl_note_categoryDto
                    {
                        tbl_note_category_name = noteCategoryName,
                        tbl_note_category_color = "Green",
                        tbl_note_category_value = "#7ed321"
                    };
                    var createResult = await _noteCategoryRepository.CreateAsync(ncDto);

                    if (!createResult.IsSuccess)
                    {
                        throw new Exception(createResult.DisplayMessage);
                    }

                    return (createResult.Id, createResult.ReferenceNumber);
                }
                //else duplicate => get id and code
                return (checkResult.Id, checkResult.ReferenceNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message +  ex.InnerException.ToString());
            }
        }

        internal async Task<ResponseDto> ProcessMileStonesAsync(tbl_voyageDto request)
        {
            try
            {
                if (request.tbl_voyage_etd != null)
                {
                    var (etdId, etdCode) = await ProcessMilestoneHeaderAsync("ETD", "Estimated Time of Departure");
                    tbl_milestone_linkDto etdLinkDto = new tbl_milestone_linkDto
                    {
                        tbl_milestone_link_value = request.tbl_voyage_etd,
                        tbl_milestone_link_createdBy = "AUSTAU.SYS",
                        tbl_milestone_link_createdDate = DateTime.Now,
                        tbl_milestone_header_id = etdId,
                        MilestoneHeaderCode = etdCode
                    };

                    var createETDLinkResult = await _milestoneLinkRepository.CreateAsync(etdLinkDto);
                    if (!createETDLinkResult.IsSuccess)
                    {
                        return new ResponseDto
                        {
                            IsSuccess = false,
                            DisplayMessage = createETDLinkResult.DisplayMessage
                        };
                    }
                }
                if (request.tbl_voyage_eta != null)
                {
                    var (etaId, etaCode) = await ProcessMilestoneHeaderAsync("ETA", "Estimated Time of Arrival");
                    tbl_milestone_linkDto etaLinkDto = new tbl_milestone_linkDto
                    {
                        tbl_milestone_link_value = request.tbl_voyage_eta,
                        tbl_milestone_link_createdBy = "AUSTAU.SYS",
                        tbl_milestone_link_createdDate = DateTime.Now,
                        tbl_milestone_header_id = etaId,
                        MilestoneHeaderCode = etaCode
                    };
                    var createETALinkResult = await _milestoneLinkRepository.CreateAsync(etaLinkDto);
                    if (!createETALinkResult.IsSuccess)
                    {
                        return new ResponseDto
                        {
                            IsSuccess = false,
                            DisplayMessage = createETALinkResult.DisplayMessage
                        };
                    }
                }
                if (request.tbl_voyage_etaDischarge != null)
                {
                    var (etaDisId, etaDisCode) = await ProcessMilestoneHeaderAsync("ETA Discharge", "Estimated Time of Arrival at Discharge Point");
                    tbl_milestone_linkDto etaDisLinkDto = new tbl_milestone_linkDto
                    {
                        tbl_milestone_link_value = request.tbl_voyage_etaDischarge,
                        tbl_milestone_link_createdBy = "AUSTAU.SYS",
                        tbl_milestone_link_createdDate = DateTime.Now,
                        tbl_milestone_header_id = etaDisId,
                        MilestoneHeaderCode = etaDisCode
                    };
                    var createETADisLinkResult = await _milestoneLinkRepository.CreateAsync(etaDisLinkDto);
                    if (!createETADisLinkResult.IsSuccess)
                    {
                        return new ResponseDto
                        {
                            IsSuccess = false,
                            DisplayMessage = createETADisLinkResult.DisplayMessage
                        };
                    }
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    DisplayMessage = "ETD, ETA, ETA Discharge successfully created."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = ex.Message + ex.InnerException.ToString()
                };
            }
        }
        private async Task<(int, string)> ProcessMilestoneHeaderAsync(string headerName, string description)
        {
            try
            {
                //check duplicate
                var checkResult = await _milestoneHeaderRepository.GetByNameAsync(headerName);
                //if new => create and return id and code
                if (!checkResult.IsSuccess)
                {
                    tbl_milestone_headerDto msHeaderDto = new tbl_milestone_headerDto
                    {
                        tbl_milestone_header_name = headerName,
                        tbl_milestone_header_description = description,
                        tbl_milestone_header_createdBy = "AUSTAU.SYS",
                        tbl_milestone_header_createdDate = DateTime.Now
                    };
                    var createResult = await _milestoneHeaderRepository.CreateAsync(msHeaderDto);

                    if (!createResult.IsSuccess)
                    {
                        throw new Exception(createResult.DisplayMessage);
                    }

                    return (createResult.Id, createResult.ReferenceNumber);
                }
                //else duplicate => get id and code
                return (checkResult.Id, checkResult.ReferenceNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException.ToString());
            }
        }
    }
}

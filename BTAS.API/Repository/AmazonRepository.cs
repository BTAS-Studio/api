using AutoMapper;
using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Areas.Carriers.Models.Austway;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class AmazonRepository
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private IAustwayLabelRepository repo;

        public AmazonRepository(MainDbContext context, IMapper mapper, IAustwayLabelRepository repo)
        {
            _context = context;
            _mapper = mapper;
            this.repo = repo;
        }

         public async Task<CreateLabelResponse> CreateLabelAsync(List<LabelItem> items, tbl_addressDto recipient, tbl_client_headerDto shipper = null)
         {
             try
             {
                 var routing = _context.tbl_amazon_routings
                 .Where(x => x.tbl_routings_states == recipient.tbl_address_state && x.tbl_routings_suburbs == recipient.tbl_address_postcode)
                 .FirstOrDefault();
                 if (routing is null)
                 {
                     return new CreateLabelResponse
                     {
                         Status = "Failed",
                         Base64Label = "There was a problem getting routing code."
                     };
                 }
                 var consignment = new tbl_tracking_amazon
                 {
                     tbl_tracking_createDate = DateTime.Now,
                     tbl_tracking_shipmentID = items[0].HouseId > 0 ? items[0].HouseId : items[0].ParcelId,
                     tbl_tracking_prefix = "AUST" + (items[0].HouseId > 0 ? "H" : "L")
                 };
                 _context.tbl_tracking_amazons.Add(consignment);
                 await _context.SaveChangesAsync();

                 int i = 0;
                 foreach (var item in items)
                 {
                     string tracking = "AMA" + String.Format("{0:000000000}", consignment.tbl_tracking_id) + String.Format("{0:0000}", i+1);

                     var barcode = _context.tbl_barcodes.Add(new tbl_barcode
                     {
                         tbl_barcodes_parcel_id = item.ItemId,
                         tbl_barcodes_code = tracking,
                         tbl_barcodes_sequence = (i + 1).ToString(),
                         tbl_barcodes_shipment_id = items[0].HouseId > 0 ? items[0].HouseId : items[0].ParcelId
                     });
                     await _context.SaveChangesAsync();

                     items[i].RoutingCode = routing.tbl_routings_code;
                     items[i].Tracking = tracking;
                     items[i].Consignment = "AMA" + String.Format("{0:00000000}", consignment.tbl_tracking_id);

                     i++;
                 }

                 return await repo.GenerateLabelAsync("Austway Amazon", items, recipient, shipper);
             }
             catch (Exception ex)
             {
                 return new CreateLabelResponse
                 {
                     Status = "Failed",
                     Base64Label = ex.Message
                 };
             }

         }       
    }

}

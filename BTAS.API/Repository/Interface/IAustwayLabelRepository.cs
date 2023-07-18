using BTAS.API.Areas.Carriers.Models.Austway;
using BTAS.API.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTAS.API.Repository.Interface
{
    public interface IAustwayLabelRepository
    {
        Task<CreateLabelResponse> GenerateLabelAsync(string carrier, List<LabelItem> obj, tbl_addressDto recipient, tbl_client_headerDto shipper = null);
    }
}

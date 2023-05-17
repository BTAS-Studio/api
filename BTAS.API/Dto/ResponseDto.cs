using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public int ErrorCode { get; set; } = 200;
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}

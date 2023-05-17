using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTAS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost, Route("UploadExcel")]
        public async Task<IActionResult> UploadExcel()
        {
            var request = HttpContext.Request;

            if (!request.HasFormContentType ||
              !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
              string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }

            var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                    out var contentDisposition);

                if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
                    !string.IsNullOrEmpty(contentDisposition.FileName.Value))
                {
                    var fileuploadPath = "D:\\test\\test.xlsx";

                    using (var targetStream = System.IO.File.Create(fileuploadPath))
                    {
                        await section.Body.CopyToAsync(targetStream);
                    }

                    return Ok();
                }

                section = await reader.ReadNextSectionAsync();
            }

            return Ok();
        }
    }
}

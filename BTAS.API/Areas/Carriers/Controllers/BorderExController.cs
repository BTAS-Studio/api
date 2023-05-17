using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;

namespace BTAS.API.Areas.Carriers.Controllers
{
    [Area("Carriers")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BorderExController : ControllerBase
    {
        [HttpGet]
        public string CreateLabel(string label)
        {
            var Renderer = new ChromePdfRenderer();

            Renderer.RenderingOptions.PaperSize = IronPdf.Rendering.PdfPaperSize.Custom;
            Renderer.RenderingOptions.SetCustomPaperSizeInInches(5f, 5f);

            Renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter()
            {

                MaxHeight = 15, //millimeters
                HtmlFragment = "<center><i>{page} of {total-pages}<i></center>",
                DrawDividerLine = true
            };

            // Build a header using an image asset
            // Note the use of BaseUrl to set a relative path to the assets
            Renderer.RenderingOptions.HtmlFooter = new HtmlHeaderFooter()
            {
                MaxHeight = 20, //millimeters
                HtmlFragment = "<img src='logo.png'>",
                BaseUrl = new Uri(@"C:\assets\images\").AbsoluteUri
            };

            // Create a PDF from a HTML string using C#
            using var pdf = Renderer.RenderHtmlAsPdf("<h1>" + label + "</h1><hr><h3>Deliver To:</h3><br>Francis");

            var ByteArray = pdf.BinaryData;
            var Base64Result = Convert.ToBase64String(ByteArray);

            return Base64Result;
        }
    }
}

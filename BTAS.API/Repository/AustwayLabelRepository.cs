using BTAS.API.Areas.Carriers.Models.Apg;
using BTAS.API.Areas.Carriers.Models.Austway;
using BTAS.API.Dto;
using BTAS.API.Repository.Interface;
using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace BTAS.API.Repository
{
    public class AustwayLabelRepository : IAustwayLabelRepository
    {
        private IConverter _converter;

        public AustwayLabelRepository(IConverter converter)
        {
            _converter = converter;
        }
        
        public async Task<CreateLabelResponse> GenerateLabelAsync(string carrier, List<LabelItem> obj, tbl_addressDto recipient, tbl_client_headerDto shipper = null)
        {
            
            var sb = new StringBuilder();
            sb.Append(@"
                                    <html>
                                        <head>
                                        <link href='/css/styles.css' rel='stylesheet'>
                                        </head>
                                        <body>");
            int itemno = 1;
            foreach (var item in obj)
            {

                sb.AppendFormat(@"
                                    <table style='font-family: Arial; font-size:14px; table-layout:fixed; line-height:1.7;' width='500px' cellspacing='0' cellpadding='0'>
<tbody>
<tr>
<td style='text-align: center; width: 500px; margin:0px; padding:0px; font-size:38px; border-bottom:2px solid #000;' colspan='2'>
<b>{16}</b>
</td>
</tr>
<tr>
<td style='width: 246px; padding-bottom:5px; font-size:12px;' colspan='2'>
<span><strong>Deliver To:</strong><br />{0}</span>
</td>
</tr>
<tr>
<td style='width: 246px; font-size:12px;' colspan='2'>
<span><strong>Tel: {1}</strong><br />{2}<br>{3}</span>
</td>
</tr>
<tr style='padding-bottom:15px; font-size:12px;'>
<td style='width: 30%;'>{4} <br />{5} {6}<br /><strong>Carrier:</strong><br><strong>{16}</strong></td>
<td style='width: 70%;' align='center'>
<table style='width: 87.5%; table-layout: fixed;'>
<tbody>
<tr>
<td style='width: 50%; text-align: center; border: 2px solid #000; font-size:36px; padding:5px;'>
<b>{7}</b>
</td>
<td style='width: 50%; text-align: center; border: 2px solid #000; font-size:36px; padding:5px;'>
<b>{8}</b>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td style='height: 52px; width: 500px; border-top:2px solid #000; border-bottom:2px solid #000; padding: 10 0 10 0; font-size:14px;' colspan='2'><strong>Delivery Instructions:</strong><br />{9}</td>
</tr>
<tr>
<td style='font-size:14px; height: 41px; width: 500px; padding:20 0 20 0;' colspan='2'><strong>Customer Reference: </strong>{10}</td>
</tr>
<tr>
<td style='text-align: center; width: 500px; padding:10 0 10 0;' colspan='2'>
<span style='width:100%; height:200px; margin:0px auto;'>
<img style='height:120px; width: 880px;' src='{11}' alt=''/>
</span>
</td>
</tr>
<tr>
<td style='width: 500px; text-align: center; padding:20 0 20 0;' colspan='2'>
<pre style='font: 12px arial;'>Aviation Security and Dangerous Goods Declaration: Sender acknowledges that this article
may be carried by air and will be subject to aviation security and clearing procedures; and the
sender declares that the article does not contain any dangerous or prohibited goods, explosive
or incendiary devices. A false declaration is a criminal offence.
</pre>
</td>
</tr>
<tr>
<td style='font-size:14px; width: 500px; text-align: center; padding-top: 10px;' colspan='2'><strong>FOR CUSTOMER USE</strong></td>
</tr>
<tr>
<td style='width: 500px; text-align: center;' colspan='2'>
<table style='width: 100%; table-layout: fixed;' cellspacing='2' cellpadding='2'>
<tbody>
<tr>
<td style='border-top: 2px solid #000; font-size: 12px; width: 30%;' align='left'><strong>Sender:</strong><br />Austway<br />24-32 Raymond Ave.<br />Matraville<br />2036 NSW</td>
<td style='border-top: 2px solid #000; border-left:2px solid #000; width: 70%; font-size:11px; text-align:center; padding-top:15px;'><strong>Consignment</strong><br>
<span>
<img style='width:600px; height:70px;' src='{12}' alt=''/>
</span>
</td>
</tr>
</tbody>
</table>
</td>
</tr>
<tr>
<td style='width: 500px; padding-top:40 px;' colspan='2'>
<table width='100%' cellspacing='0' cellpadding='0'>
<tbody>
<tr>
<td align='center' width='50%'><strong>Item No. {13} / {14}</strong></td>
<td align='center' width='50%'><strong>Weight: {15}</strong></td>
</tr>
</tbody>
</table>
</td>
</tr>
</tbody>
</table>
<div style='page-break-after: always;'> </div>
                                    ",
                    recipient.tbl_address_companyName,
                    recipient.tbl_address_phone,
                    recipient.tbl_address_address1,
                    recipient.tbl_address_address2,
                    recipient.tbl_address_suburb,
                    recipient.tbl_address_postcode,
                    recipient.tbl_address_state,
                    item.RoutingCode,
                    item.ParcelPallet,
                    item.Instructions,
                    recipient.tbl_address_code,
                    Barcode39(item.Tracking),
                    Barcode39(item.Consignment),
                    itemno,
                    obj.Count,
                    item.Weight,
                    carrier
                    );

                itemno++;
            }
            sb.Append(@"
                                    </body>
                                    </html>");

            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = DinkToPdf.ColorMode.Grayscale,
                    Orientation = Orientation.Portrait,
                    //PaperSize = PaperKind.A6,
                    PaperSize = new PechkinPaperSize("3.5in", "5.5in"),
                    //Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = "" //@"d:\sample.pdf"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = sb.ToString(),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "CSS", "styles.css") }
                    //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var bytes = await Task.FromResult(_converter.Convert(pdf));

                var Base64Result = Convert.ToBase64String(bytes);

                return new CreateLabelResponse
                {
                    Base64Label = Base64Result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        private string Barcode39(string barcode)
        {
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.
                    //bitMap.Save(ms, ImageFormat.Png);
                    bitMap.Save(ms, ImageFormat.Png);
                    bitMap.Dispose();


                    //The Image is finally converted to Base64 string.
                    result = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                }
            }
            return result;
        }
    }
}

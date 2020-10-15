using System;
using System.IO;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Html2pdf;
using System.Collections.Generic;
using iText.Layout.Font;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using System.Web.Mvc;
using System.Web;

namespace MonthlyReport.Models
{
    public class PageOrientations
    {                
        public void ManipulatePdf( string HtmlContent, string basePath)
        {
         string FONTTABLEHEADER = basePath + @"fonts\Metric-Bold.otf";
        string FONTTABLEGENERAL = basePath + @"fonts\Metric-Regular.otf";
         string FONTPAGEHEADING = basePath + @"fonts\Indian Type Foundry - Zahrah Bold Italic.otf";
         string HOMEPAGEHEADING = basePath + @"fonts\Indian Type Foundry - Zahrah Light.otf";

             ConverterProperties properties = new ConverterProperties();
            properties.SetBaseUri(basePath);
            FontProvider fontProvider = new DefaultFontProvider(false, false,false);
            FontProgram fontTableHeader = FontProgramFactory.CreateFont(FONTTABLEHEADER);
            FontProgram fontTableGeneral = FontProgramFactory.CreateFont(FONTTABLEGENERAL);
            FontProgram fontPageHeading = FontProgramFactory.CreateFont(FONTPAGEHEADING);
            FontProgram homePageHeading = FontProgramFactory.CreateFont(HOMEPAGEHEADING);
                      
            fontProvider.AddFont(homePageHeading);
            fontProvider.AddFont(fontTableHeader);
            fontProvider.AddFont(fontTableGeneral);
            fontProvider.AddFont(fontPageHeading);
            properties.SetFontProvider(fontProvider);
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(basePath + @"Pdf\Test.pdf"));
            pdfDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.LETTER.Rotate());
            HtmlConverter.ConvertToPdf(HtmlContent, pdfDoc, properties);
           
        }

        public string RenderRazorViewToString(Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
            // checking the view inside the controller  
            if (viewResult.View != null)
            {
                using (var sw = new StringWriter())
                {
                    var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
                }
            }
            else
                return "View cannot be found.";
        }



    }
}
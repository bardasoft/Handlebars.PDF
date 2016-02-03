using System.IO;
using HandlebarsPDF.ContentProvider;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace HandlebarsPDF.Creator
{
    public class PDFCreator
    {
        public IHtmlContentProvider ContentProvider { get; set; }
        private IConfigurationProvider ConfigurationProvider { get; set; }

        public PDFCreator(IHtmlContentProvider contentProvider, IConfigurationProvider configurationProvider)
        {
            ContentProvider = contentProvider;
            ConfigurationProvider = configurationProvider;
        }

        public Stream CreatePDF<T>(T data, string template)
        {
           using (var stream = new MemoryStream())
           using (var document = new Document())            
           using (var writer = PdfWriter.GetInstance(document, stream))
           {
                    document.Open();
                    ConfigurationProvider.Configure(document);
                    var htmlString = ContentProvider.GetHtmlContent(data, template);
                    using (var html = new StringReader(htmlString))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, html);
                    }
                    document.Close();                
                return new MemoryStream(stream.ToArray());
            }
        }
    }
}

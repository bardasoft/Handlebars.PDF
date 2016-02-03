using iTextSharp.text;

namespace HandlebarsPDF.Creator.Default
{
    public class DefaultConfigurationProvider: IConfigurationProvider 
    {
        public void Configure(Document document)
        {
            //TODO:Set margins and pagesize
            document.SetPageSize(PageSize.A4);
        }
    }
}

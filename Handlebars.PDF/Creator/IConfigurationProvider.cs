using iTextSharp.text;

namespace HandlebarsPDF.Creator
{
    public interface IConfigurationProvider
    {
        void Configure(Document document);
    }
}

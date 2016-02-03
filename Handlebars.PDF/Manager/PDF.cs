using HandlebarsPDF.ContentProvider.Default;
using HandlebarsPDF.Creator;
using HandlebarsPDF.Creator.Default;

namespace HandlebarsPDF
{
    public static class Manager
    {
        public static PDFCreator Current { get; }

        static Manager()
        {
            Current = new PDFCreator(new HandlebarsHtmlContentProvider(),new DefaultConfigurationProvider());
        }
    }
}

namespace HandlebarsPDF.ContentProvider
{
    public interface IHtmlContentProvider
    {
        string GetHtmlContent<T>(T data,string template);
    }
}

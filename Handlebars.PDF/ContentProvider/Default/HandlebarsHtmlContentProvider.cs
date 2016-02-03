using HandlebarsDotNet;
using System.IO;

namespace HandlebarsPDF.ContentProvider.Default
{
    public class HandlebarsHtmlContentProvider: IHtmlContentProvider
    {
        public string TemplatesPath { get; set; }

        public HandlebarsHtmlContentProvider()
        {
            TemplatesPath = null;
        }
        public HandlebarsHtmlContentProvider(string templatesPath)
        {
            TemplatesPath = templatesPath;
        }

        protected string GetFullPath(string path)
        {
            return TemplatesPath != null ? Path.Combine(TemplatesPath, path) : path;
        }

        public string GetHtmlContent<T>(T data, string template)
        {
            var stringtemplate = File.ReadAllText(GetFullPath(template));
            var ctemplate = Handlebars.Compile(stringtemplate);
            var proccessed = ctemplate(data);
            return proccessed;
        }
    }
}

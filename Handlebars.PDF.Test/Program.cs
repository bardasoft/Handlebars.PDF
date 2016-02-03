using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlebars.PDF.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"Html\test.html";
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            var data = new { Nombre = "Jesus Angulo" };

            var stream = HandlebarsPDF.Manager.Current.CreatePDF(data, fullPath);
            using (var fileStream = File.Create(@"C:\test.pdf"))
            {
                stream.CopyTo(fileStream);
            }
            System.Diagnostics.Process.Start(@"C:\test.pdf");
        }
    }
}

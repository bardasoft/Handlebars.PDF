# Handlebars.PDF
Proyecto para crear documentos en PDF basados en templates HTML usando Handlebars para la sintaxis y iTextSharp para renderizar el PDF en proyectos de .NET.

##Inicio rápido
Lo primero que debemos hacer es instalar el paquete desde nuget.

      PM> Install-Package HandlebarsPDF

Si empleamos la configuracion por defecto ,podemos generar los PDF's pasando como parametro el objeto que servira de modelo para nuestra template, 
es decir el objeto del cual se sacaron los datos para completar la plantilla y la la ruta completa del archivo HTML que usaran como plantilla.

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

##Notas adicionales
Pueden revisar el codigo fuente e implementar sus propios proveedores de plantillas o incluso configurar una ruta base por defecto.

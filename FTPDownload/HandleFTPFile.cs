using System;
using System.IO;
using System.Xml;

namespace FTPDownload
{
    class HandleFTPFile
    {
        static void Main()
        {
            string xmlFilePath = "FTP_Structure.xml";
            string ftpServer = "";

            try
            {
                string usuario, contrasena;
                LeerCredenciales(xmlFilePath, out ftpServer, out usuario, out contrasena);

                string nombreArchivo = DescargarDesdeFTP(ftpServer, usuario, contrasena);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void LeerCredenciales(string filePath, out string server, out string usuario, out string contrasena)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.ReadToFollowing("FTP");

                reader.ReadToFollowing("ip");
                server = reader.ReadElementContentAsString();

                reader.ReadToFollowing("credentials");
                reader.ReadToFollowing("username");
                usuario = reader.ReadElementContentAsString();

                reader.ReadToFollowing("password");
                contrasena = reader.ReadElementContentAsString();
            }
        }

        static void GuardarEnCarpeta(string nombreArchivo)
        {
            string carpetaDestino = Path.Combine(Directory.GetCurrentDirectory(), "EDIOrders");

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            File.Move(nombreArchivo, Path.Combine(carpetaDestino, nombreArchivo));
        }


        static string DescargarDesdeFTP(string server, string usuario, string contrasena)
        {
            string nombreArchivo = "";

            try
            {
                using (var ftpClient = new System.Net.WebClient())
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    Console.Write("Nombre del archivo a descargar: ");
                    nombreArchivo = Console.ReadLine();

                    ftpClient.Credentials = new System.Net.NetworkCredential(usuario, contrasena);

                    Console.WriteLine($"Conectando a {server}...");
                    try
                    {
                        ftpClient.DownloadFile($"ftp://{server}/{nombreArchivo}", nombreArchivo);
                        Console.WriteLine("Conexión exitosa.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error al conectarse al servidor FTP. Verifica las credenciales y la conexión.");
                        return null;
                    }

                    Console.WriteLine("Archivo descargado exitosamente!");

                    GuardarEnCarpeta(nombreArchivo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            return nombreArchivo;
        }

    }
}

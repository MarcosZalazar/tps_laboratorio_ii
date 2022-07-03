using System;
using System.IO;
using System.Xml.Serialization;

namespace Serializacion
{
    public static class ClaseSerializadora<T>
    {
        static string path;
        static ClaseSerializadora()
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Serializa un archivo a formato XML 
        /// </summary>
        /// <param name="datos"> tipo genérico</param>
        /// <param name="nombreFile"> nombre del archivo</param>
        /// <exception cref="Exception"></exception>
        public static void Escribir(T datos, string nombreFile)
        {
            string nombreArchivo = nombreFile;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(nombreFile);
                }

                using (StreamWriter streamWriter = new StreamWriter(nombreArchivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, datos);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }

        /// <summary>
        /// Deserializa un archivo en formato XML
        /// </summary>
        /// <param name="nombre"> nombre del archivo</param>
        /// <returns> devuelve la informacion leida</returns>
        /// <exception cref="Exception"></exception>
        public static T Leer(string nombre)
        {
            string archivo = string.Empty;
            string informacionRecuperada = string.Empty;
            T datos = default;
            try
            {
                if (Directory.Exists(path))
                {
                    string[] archivosEnElPath = Directory.GetFiles(path);
                    foreach (string path in archivosEnElPath)
                    {
                        if (path.Contains(nombre))
                        {
                            archivo = path;
                            break;
                        }
                    }
                    if (archivo != null)
                    {
                        using (StreamReader sr = new StreamReader(archivo))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                            datos = (T)xmlSerializer.Deserialize(sr);
                        }
                    }
                }

                return datos;
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }

        /// <summary>
        /// Escribe un archivo en formato txt
        /// </summary>
        /// <param name="nombreArchivo">nombre del archivo</param>
        /// <param name="contenido">contenido del archivo</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool EscribirEnTxt(string nombreArchivo,string contenido)
        {
            try 
            {
                using (StreamWriter streamWriter = new StreamWriter($"{path}\\{nombreArchivo}"))
                {
                    streamWriter.WriteLine(contenido);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error en la escritura del archivo", ex);
            }
            return true;
        }
    }
}

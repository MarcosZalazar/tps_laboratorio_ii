using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serializacion
{
    public class ClaseSerializadoraJson<T>
    {
        static string path;

        static ClaseSerializadoraJson()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Archivos-Serializacion\";
        }

        /// <summary>
        /// Serializa un archivo a formato JSON 
        /// </summary>
        /// <param name="datos">tipo genérico</param>
        /// <param name="nombre">nombre del archivo</param>
        /// <exception cref="Exception"></exception>
        public static void Escribir(T datos, string nombre)
        {
            string nombreArchivo = path + "SerializandoJson_" + nombre + ".js";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                File.WriteAllText(nombreArchivo, JsonSerializer.Serialize(datos));

            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }

        /// <summary>
        /// Deserializa un archivo en formato JSON
        /// </summary>
        /// <param name="nombre">nombre del archivo</param>
        /// <returns>devuelve la informacion leida</returns>
        /// <exception cref="Exception"></exception>
        public static T Leer(string nombre)
        {
            string archivo = string.Empty;
            string informacionRecuperada = string.Empty;
            T datosRecuperados = default;
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
                        datosRecuperados = JsonSerializer.Deserialize<T>(File.ReadAllText(archivo));
                    }
                }

                return datosRecuperados;
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo ubicado en {path}", e);
            }
        }
    }
}

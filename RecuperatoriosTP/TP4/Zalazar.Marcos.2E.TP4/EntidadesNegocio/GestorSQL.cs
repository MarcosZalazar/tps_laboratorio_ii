using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesNegocio
{
    public class GestorSQL
    {
        private static string cadenaConexion;
        static GestorSQL()
        {
            GestorSQL.cadenaConexion = "Server=.;Database=Gimnasio_DB;Trusted_Connection=True;";
        }

        public static List<Profesor> LeerDatosProfesor()
        {
            List<Profesor> listaProfesoresDB = new List<Profesor>();

            string query = "select * from profesores";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int dni= reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    int sexo = reader.GetInt32(3);
                    DateTime fechaDeContratacion = reader.GetDateTime(4);
                    int salario = reader.GetInt32(5);
                    int actividad = reader.GetInt32(6);
                    bool profesorActivo = reader.GetBoolean(7);
                    Profesor profesor = new Profesor(dni, nombre, apellido, (ECampos.ESexo)sexo, fechaDeContratacion, salario, (ECampos.Actividades)actividad);
                    profesor.ProfesorActivo= profesorActivo;
                    listaProfesoresDB.Add(profesor);
                }
            }

            return listaProfesoresDB;
        }

        public static void AltaProfesor(Profesor profesor)
        {
            string query = "insert into profesores (dni,nombre, apellido, idSexo, fechaDeContratacion, salario,idActividad,profesorActivo) values (@dni,@nombre,@apellido,@idSexo,@fechaDeContratacion,@salario,@idActividad,@profesorActivo)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(GestorSQL.cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("dni", profesor.Dni);
                cmd.Parameters.AddWithValue("nombre", profesor.Nombre);
                cmd.Parameters.AddWithValue("apellido", profesor.Apellido);
                cmd.Parameters.AddWithValue("idSexo", (int)profesor.Sexo);
                cmd.Parameters.AddWithValue("fechaDeContratacion", profesor.FechaDeContratacion);
                cmd.Parameters.AddWithValue("salario", profesor.Salario);
                cmd.Parameters.AddWithValue("idActividad", (int)profesor.Actividad);
                cmd.Parameters.AddWithValue("profesorActivo", profesor.ProfesorActivo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static void BorrarProfesor(int dni)
        {
            string query = "update profesores set profesorActivo=@profesorActivo where dni = @dni";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("dni", dni);
                cmd.Parameters.AddWithValue("profesorActivo", false);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ActualizarProfesor(Profesor profesor, int dni)
        {
            string query = "update profesores set dni=@dni, nombre=@nombre, apellido=@apellido, idSexo=@idSexo, fechaDeContratacion=@fechaDeContratacion, salario=@salario, idActividad=@idActividad where dni = @dni";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("dni", dni);
                cmd.Parameters.AddWithValue("nombre", profesor.Nombre);
                cmd.Parameters.AddWithValue("apellido", profesor.Apellido);
                cmd.Parameters.AddWithValue("idSexo", profesor.Sexo);
                cmd.Parameters.AddWithValue("fechaDeContratacion", profesor.FechaDeContratacion);
                cmd.Parameters.AddWithValue("salario", profesor.Salario);
                cmd.Parameters.AddWithValue("idActividad", profesor.Actividad);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}

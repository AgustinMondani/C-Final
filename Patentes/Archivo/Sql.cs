using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Archivo
{
    public class Sql : IArchivo
    {
        private static SqlCommand _comando;
        private static SqlConnection _conexion;

        static Sql()
        {
            _conexion = new SqlConnection("Server = .; Database = lab_sp; Trusted_Connection = True");
            _comando = new SqlCommand
            {
                Connection = _conexion,
                CommandType = CommandType.Text,
            };
        }

        public bool Guardar(List<Patente> datos)
        {
            try
            {
                using (_conexion)
                {
                    int filas_afectadas = 0;
                    _conexion.Open();
                    foreach (Patente patente in datos)
                    {
                        string query = $"INSERT INTO patentes (codigoPatente, tipoCodigo) VALUES (@codigoPatente, @tipoCodigo)";
                        _comando.CommandText = query;
                        _comando.Parameters.AddWithValue("@codigoPatente", patente.CodigoPatente);
                        _comando.Parameters.AddWithValue("@TipoCodigo", patente.TipoCodigo);
                        filas_afectadas = +_comando.ExecuteNonQuery();
                    }
                    return filas_afectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la base de datos");
            }
        }

        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();

            try
            {
                using (_conexion)
                {
                    _conexion.Open();
                    string query = $"SELECT * FROM patentes";
                    _comando.CommandText = query;
                    SqlDataReader reader = _comando.ExecuteReader();
                    while (reader.Read())
                    {
                        patentes.Add(new Patente(reader["CodigoPatente"].ToString(), (ETipo)Enum.Parse(typeof(ETipo), reader["TipoPatente"].ToString())));
                    }
                }
                return patentes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer de la base de datos");
            }
        }
    }
}

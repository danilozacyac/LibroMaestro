using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using LibroMaestro.Dto;
using ScjnUtilities;

namespace LibroMaestro.Model
{
    public class IntegracionModel
    {

        readonly string connectionString = ConfigurationManager.ConnectionStrings["Libro"].ConnectionString;

        public List<Integracion> GetElementosIntegracion(int conEjecutoria )
        {
            List<Integracion> elementos = new List<Integracion>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Integracion WHERE ConEjecutoria = @ConEjecutoria ORDER BY IdElemento";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@ConEjecutoria", conEjecutoria);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Integracion integra = new Integracion()
                        {
                            BinaryValue = Convert.ToInt64(reader["Binario"]),
                            Descripcion = reader["Descripcion"].ToString()
                        };

                        elementos.Add(integra);
                    }
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionModel", "LibroElectronico");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, IntegracionModel", "LibroElectronico");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return elementos;
        }

    }
}

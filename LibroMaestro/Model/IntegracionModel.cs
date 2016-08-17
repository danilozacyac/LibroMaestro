using System;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// Obtiene el listado de elementos que deben integrar una tesis de acuerdo a las opciones indicadas
        /// </summary>
        /// <param name="tipoDocto">Indica si es una tesis aislada, jurisprudencia, ejecutoria o voto</param>
        /// <param name="elementosIntegracion">Indica los elementos que se requieren de acuerdo a la selección</param>
        /// <returns></returns>
        public ObservableCollection<Integracion> GetElementosIntegracion(int tipoDocto, int elementosIntegracion )
        {
            ObservableCollection<Integracion> elementos = new ObservableCollection<Integracion>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand("SELECT * FROM Integracion WHERE IdDocto = @IdDocto AND Tipo = @Tipo ORDER BY Orden", oleConne);
                cmd.Parameters.AddWithValue("@IdDocto", tipoDocto);
                cmd.Parameters.AddWithValue("@Tipo", elementosIntegracion);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Integracion integra = new Integracion()
                        {
                            BinaryValue = Convert.ToInt64(reader["Binario"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            Tipo = Convert.ToInt32(reader["Tipo"]),
                            EsObligatorio = Convert.ToBoolean(reader["EsObligatorio"]),
                            Orden = Convert.ToInt32(reader["Orden"])
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

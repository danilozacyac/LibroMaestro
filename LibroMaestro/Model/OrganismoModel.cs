using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using LibroMaestro.Dto;
using ScjnUtilities;

namespace LibroMaestro.Model
{
    public class OrganismoModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DirSemanarioApp"].ConnectionString;

        public List<OrganismoLibro> GetOrganismos(CircuitoLibro circuito)
        {
            List<OrganismoLibro> organismos = new List<OrganismoLibro>();

            SqlConnection oleConne = new SqlConnection(connectionString);
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            String sqlCadena = "SELECT fi_Id, fc_NombreComp_TC FROM Catalogos.tbc_TribunalesColegiados WHERE fi_Circuito = @Circuito AND fi_Sala = 7 ORDER BY fi_Ordenvisualizacion";

            try
            {
                oleConne.Open();

                cmd = new SqlCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@Circuito", circuito.IdCircuito);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        OrganismoLibro organismo = new OrganismoLibro();
                        organismo.IdOrganismo = Convert.ToInt32(reader["fi_Id"]);
                        organismo.Organismo = reader["fc_NombreComp_TC"].ToString();
                        organismo.IdInstancia = 7;

                        organismos.Add(organismo);
                    }
                }
            }
            catch (SqlException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "LibroElectronico");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, OrganismosModel", "LibroElectronico");
            }
            finally
            {
                cmd.Dispose();
                reader.Close();
                oleConne.Close();
            }

            return organismos;
        }


        



    }
}

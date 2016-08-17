using LibroMaestro.Dto;
using ScjnUtilities;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace LibroMaestro.Model
{
    public class TesisLibroModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Libro"].ConnectionString;
        private readonly string fileSupporString = ConfigurationManager.AppSettings["ArchivosRespaldo"];


        public ObservableCollection<TesisLibro> GetTesisByOrganismo(OrganismoLibro organismo)
        {
            ObservableCollection<TesisLibro> tesisOrg = new ObservableCollection<TesisLibro>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Tesis WHERE IdOrganismo = @IdOrganismo ORDER BY Tatj desc,NumTesis";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdOrganismo", organismo.IdOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //int age = reader["Age"] as int? ?? -1;
                        TesisLibro tesis = new TesisLibro();
                        tesis.IdTesis = Convert.ToInt32(reader["IdTesis"]);
                        tesis.IdInstancia = Convert.ToInt32(reader["IdInstancia"]);
                        tesis.IdOrganismo = Convert.ToInt32(reader["IdOrganismo"]);
                        tesis.IdEpoca = Convert.ToInt32(reader["IdEpoca"]);
                        tesis.IdMateria = Convert.ToInt32(reader["IdMateria"]);
                        tesis.NumCarpeta = reader["NumCarpeta"].ToString();
                        tesis.TesisInicio = Convert.ToInt32(reader["TesisInicio"]);
                        tesis.TesisFin = Convert.ToInt32(reader["TesisFin"]);
                        tesis.Recibida = reader["ControlRecibida"].ToString();
                        tesis.Aprobada = reader["ControlAprobada"].ToString();
                        tesis.Clave = reader["Clave"].ToString();
                        tesis.NumTesis = Convert.ToInt32(reader["NumTesis"]);
                        tesis.Tatj = Convert.ToInt32(reader["Tatj"]);
                        tesis.Ius = Convert.ToInt32(reader["Ius"]);
                        tesis.Rubro = reader["Rubro"].ToString();
                        tesis.Precedentes = reader["Precedentes"].ToString();
                        tesis.Publicado = reader["Publicado"].ToString();
                        tesis.Fojas = Convert.ToInt32(reader["Fojas"]);
                        tesis.Cancelada = Convert.ToInt32(reader["Cancelada"]);
                        tesis.CambioMateria = Convert.ToBoolean(reader["CambioMateria"]);
                        tesis.FileName = fileSupporString + reader["FileName"].ToString();
                        tesis.TieneEjecutoria = Convert.ToBoolean(reader["Ejecutoria"]);
                        tesis.Elementos = Convert.ToInt64(reader["Elementos"]);
                        tesis.Observaciones = reader["Observaciones"].ToString();
                        tesis.NumEje = Convert.ToInt32(reader["NumEje"]);
                        tesis.NumVotos = Convert.ToInt32(reader["NumVotos"]);

                        tesisOrg.Add(tesis);
                    }
                }
            }
            catch (OleDbException ex)
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

            return tesisOrg;
        }


        public bool InsertaTesis(TesisLibro tesis)
        {
            bool exito = false;

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;
            try
            {
                tesis.IdTesis = DataBaseUtilities.GetNextIdForUse("Tesis", "IdTesis", connection);
                if (tesis.IdTesis != 0)
                {
                    string currentFilePath = tesis.FileName;
                    string newFile = String.Format("{0}{1}_{2}{3}", fileSupporString, tesis.Aprobada, tesis.IdEpoca, Path.GetExtension(tesis.FileName));

                    tesis.IdTesis = tesis.IdTesis;
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Tesis WHERE IdTesis = 0", connection);

                    dataAdapter.Fill(dataSet, "Tesis");

                    dr = dataSet.Tables["Tesis"].NewRow();
                    dr["IdTesis"] = tesis.IdTesis;
                    dr["IdInstancia"] = tesis.IdInstancia;
                    dr["IdOrganismo"] = tesis.IdOrganismo;
                    dr["IdEpoca"] = tesis.IdEpoca;
                    dr["IdMateria"] = tesis.IdMateria;
                    dr["NumCarpeta"] = tesis.NumCarpeta;
                    dr["TesisInicio"] = tesis.TesisInicio;
                    dr["TesisFin"] = tesis.TesisFin;
                    dr["ControlRecibida"] = tesis.Recibida;
                    dr["ControlAprobada"] = tesis.Aprobada;
                    dr["Clave"] = tesis.Clave;
                    dr["NumTesis"] = tesis.NumTesis;
                    dr["Tatj"] = tesis.Tatj;
                    dr["Ius"] = tesis.Ius;
                    dr["Rubro"] = tesis.Rubro;
                    dr["precedentes"] = tesis.Precedentes;
                    dr["Publicado"] = tesis.Publicado;
                    dr["Fojas"] = tesis.Fojas;
                    dr["Cancelada"] = tesis.Cancelada;
                    dr["FileName"] = Path.GetFileName(newFile);
                    dr["Ejecutoria"] = tesis.TieneEjecutoria;
                    dr["NumEje"] = tesis.NumEje;
                    dr["Votos"] = tesis.TieneVotos;
                    dr["NumVotos"] = tesis.NumVotos;
                    dr["Modificacion"] = tesis.SugModificacion;
                    dr["CambioMateria"] = tesis.CambioMateria;
                    dr["Contradiccion"] = tesis.PropContradiccion;
                    dr["NoPublica"] = tesis.NoPublica;
                    dr["Elementos"] = tesis.Elementos;
                    dr["Observaciones"] = tesis.Observaciones;
                    dr["FechaRegistro"] = DateTime.Now;
                    
                    dataSet.Tables["Tesis"].Rows.Add(dr);

                    //dataAdapter.UpdateCommand = connectionEpsOle.CreateCommand();
                    dataAdapter.InsertCommand = connection.CreateCommand();
                    dataAdapter.InsertCommand.CommandText =
                                                           "INSERT INTO Tesis(IdTesis,IdInstancia,IdOrganismo,IdEpoca,IdMateria,NumCarpeta,TesisInicio,TesisFin," +
                                                           "ControlRecibida,ControlAprobada,Clave,NumTesis,Tatj,Ius,Rubro,Precedentes,Publicado,Fojas,Cancelada,FileName," +
                                                           "Ejecutoria,NumEje,Votos,NumVotos,Modificacion,CambioMateria,Contradiccion,NoPublica,Elementos,Observaciones,FechaRegistro)" +
                                                           " VALUES(@IdTesis,@IdInstancia,@IdOrganismo,@IdEpoca,@IdMateria,@NumCarpeta,@TesisInicio,@TesisFin," +
                                                           "@ControlRecibida,@ControlAprobada,@Clave,@NumTesis,@Tatj,@Ius,@Rubro,@Precedentes,@Publicado,@Fojas,@Cancelada,@FileName," +
                                                           "@Ejecutoria,@NumEje,@Votos,@NumVotos,@Modificacion,@CambioMateria,@Contradiccion,@NoPublica,@Elementos,@Observaciones,@FechaRegistro)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdTesis", OleDbType.Numeric, 0, "IdTesis");
                    dataAdapter.InsertCommand.Parameters.Add("@IdInstancia", OleDbType.Numeric, 0, "IdInstancia");
                    dataAdapter.InsertCommand.Parameters.Add("@IdOrganismo", OleDbType.Numeric, 0, "IdOrganismo");
                    dataAdapter.InsertCommand.Parameters.Add("@IdEpoca", OleDbType.Numeric, 0, "IdEpoca");
                    dataAdapter.InsertCommand.Parameters.Add("@IdMateria", OleDbType.Numeric, 0, "IdMateria");
                    dataAdapter.InsertCommand.Parameters.Add("@NumCarpeta", OleDbType.VarChar, 0, "NumCarpeta");
                    dataAdapter.InsertCommand.Parameters.Add("@TesisInicio", OleDbType.Numeric, 0, "TesisInicio");
                    dataAdapter.InsertCommand.Parameters.Add("@TesisFin", OleDbType.Numeric, 0, "TesisFin");
                    dataAdapter.InsertCommand.Parameters.Add("@ControlRecibida", OleDbType.VarChar, 0, "ControlRecibida");
                    dataAdapter.InsertCommand.Parameters.Add("@ControlAprobada", OleDbType.VarChar, 0, "ControlAprobada");
                    dataAdapter.InsertCommand.Parameters.Add("@Clave", OleDbType.VarChar, 0, "Clave");
                    dataAdapter.InsertCommand.Parameters.Add("@NumTesis", OleDbType.Numeric, 0, "NumTesis");
                    dataAdapter.InsertCommand.Parameters.Add("@Tatj", OleDbType.Numeric, 0, "Tatj");
                    dataAdapter.InsertCommand.Parameters.Add("@Ius", OleDbType.Numeric, 0, "Ius");
                    dataAdapter.InsertCommand.Parameters.Add("@Rubro", OleDbType.VarChar, 0, "Rubro");
                    dataAdapter.InsertCommand.Parameters.Add("@Precedentes", OleDbType.VarChar, 0, "Precedentes");
                    dataAdapter.InsertCommand.Parameters.Add("@Publicado", OleDbType.VarChar, 0, "Publicado");
                    dataAdapter.InsertCommand.Parameters.Add("@Fojas", OleDbType.Numeric, 0, "Fojas");
                    dataAdapter.InsertCommand.Parameters.Add("@Cancelada", OleDbType.Numeric, 0, "Cancelada");
                    dataAdapter.InsertCommand.Parameters.Add("@FileName", OleDbType.VarChar, 0, "FileName");
                    dataAdapter.InsertCommand.Parameters.Add("@Ejecutoria", OleDbType.Numeric, 0, "Ejecutoria");
                    dataAdapter.InsertCommand.Parameters.Add("@NumEje", OleDbType.Numeric, 0, "NumEje");
                    dataAdapter.InsertCommand.Parameters.Add("@Votos", OleDbType.Numeric, 0, "Votos");
                    dataAdapter.InsertCommand.Parameters.Add("@NumVotos", OleDbType.Numeric, 0, "NumVotos");
                    dataAdapter.InsertCommand.Parameters.Add("@Modificacion", OleDbType.Numeric, 0, "Modificacion");
                    dataAdapter.InsertCommand.Parameters.Add("@CambioMateria", OleDbType.Numeric, 0, "CambioMateria");
                    dataAdapter.InsertCommand.Parameters.Add("@Contradiccion", OleDbType.Numeric, 0, "Contradiccion");
                    dataAdapter.InsertCommand.Parameters.Add("@NoPublica", OleDbType.Numeric, 0, "NoPublica");
                    dataAdapter.InsertCommand.Parameters.Add("@Elementos", OleDbType.VarChar, 0, "Elementos");
                    dataAdapter.InsertCommand.Parameters.Add("@Observaciones", OleDbType.VarChar, 0, "Observaciones");
                    dataAdapter.InsertCommand.Parameters.Add("@FechaRegistro", OleDbType.Date, 0, "FechaRegistro");

                    dataAdapter.Update(dataSet, "Tesis");

                    dataSet.Dispose();
                    dataAdapter.Dispose();

                    FilesUtilities.CopyToLocalResource(currentFilePath, newFile);
                    tesis.FileName = newFile;
                    exito = true;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, TesisLibroModel", "LibroElectronico");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, TesisLibroModel", "LibroElectronico");
            }
            finally
            {
                connection.Close();
            }
            return exito;
        }// fin InsertarRegistro



    }
}

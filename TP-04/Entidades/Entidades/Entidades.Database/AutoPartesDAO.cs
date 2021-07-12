using Entidades.Entidades.Files;
using Entidades.Entidades.Herencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Database
{
    public class AutoPartesDAO : DataBase_<AutoParte>
    {
        private SqlConnection connection;
        private SqlCommand command;
        private Logger logger;

        /// <summary>
        /// Constructos de la clase DAO
        /// </summary>
        public AutoPartesDAO()
        : base()
        {
            this.logger = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Logging.txt");
        }

        /// <summary>
        /// Metodo para eliminar un dato de la base según su numero de serie.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override bool Delete(string input)
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "DELETE FROM Autopartes WHERE numeroDeSerie=@numeroDeSerie;";
                command.Parameters.AddWithValue("@numeroDeSerie", input);

                connection.Open();
                command.ExecuteNonQuery();

                retorno = true;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Metodo que obtiene una lista de autopartes desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public override List<AutoParte> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM AutoPartes", connection))
                {
                    try
                    {
                        List<AutoParte> autopartes = new List<AutoParte>();

                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                AutoParte autoParte = new AutoParte();

                                switch (dataReader["tipo"].ToString())
                                {
                                    case "Puerta":
                                        autoParte = new Puerta { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), LadoPuerta = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;

                                    case "Panel":
                                        autoParte = new Panel { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), Lado = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;

                                    case "Chasis":
                                        autoParte = new Chasis { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), TipoDeChasis = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;

                                    case "Carroceria":
                                        autoParte = new Carroceria { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), TipoCarroceria = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;

                                    case "Capot":
                                        autoParte = new Capot { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), AperturaDesde = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;

                                    case "Baul":
                                        autoParte = new Baul { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Peso = double.Parse(dataReader["peso"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), Capacidad = dataReader["descripcion"].ToString(), NumeroDeSerie = dataReader["numeroDeSerie"].ToString() };
                                        break;
                                }
                                autopartes.Add(autoParte);
                            }
                        }
                        return autopartes;
                    }
                    catch (Exception ex)
                    {
                        logger.saveReport(ex);
                        throw ex;

                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que realiza una actualizacion en la base de datos, segun las autopartes que se ingresen a la base.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Update(AutoParte item)
        {
            bool output = false;

            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO AutoPartes(tipo,tipoDeMaterial,ID_material,numeroDeSerie,largo,alto,peso,estaDefectuosa,descripcion) VALUES (@tipo,@tipoDeMaterial,@ID_material,@numeroDeSerie,@largo,@alto,@peso,@estaDefectuosa,@descripcion);";

                command.Parameters.AddWithValue("@tipo", item.GetType().Name);
                command.Parameters.AddWithValue("@tipoDeMaterial", item.TipoDeMaterial.ToString());

                if (item.TipoDeMaterial.ToString().Equals("Acero"))
                {
                    command.Parameters.AddWithValue("@ID_material", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@ID_material", 2);
                }
                command.Parameters.AddWithValue("@numeroDeSerie", item.NumeroDeSerie);

                command.Parameters.AddWithValue("@largo", item.Largo);
                command.Parameters.AddWithValue("@alto", item.Alto);
                command.Parameters.AddWithValue("@peso", item.Peso);
                command.Parameters.AddWithValue("@estaDefectuosa", item.EstaDefectuoso);

                switch (item.GetType().Name)
                {
                    case "Puerta":
                        command.Parameters.AddWithValue("@descripcion", ((Puerta)item).LadoPuerta);
                        break;
                    case "Panel":
                        command.Parameters.AddWithValue("@descripcion", ((Panel)item).Lado);
                        break;
                    case "Chasis":
                        command.Parameters.AddWithValue("@descripcion", ((Chasis)item).TipoDeChasis);
                        break;
                    case "Carroceria":
                        command.Parameters.AddWithValue("@descripcion", ((Carroceria)item).TipoCarroceria);
                        break;
                    case "Capot":
                        command.Parameters.AddWithValue("@descripcion", ((Capot)item).AperturaDesde);
                        break;
                    case "Baul":
                        command.Parameters.AddWithValue("@descripcion", ((Baul)item).Capacidad);
                        break;
                }

                connection.Open();
                command.ExecuteNonQuery();

                output = true;
            }
            catch (Exception ex)
            {
                logger.saveReport(ex);
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return output;
        }

    }
}

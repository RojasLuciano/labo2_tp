using Entidades.Entidades.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Database
{
    public class MaterialesDAO : DataBase_<Material>
    {
        private SqlConnection connection;
        private SqlCommand command;
        private Logger logger;

        /// <summary>
        /// Constructor de la clase dao
        /// </summary>
        public MaterialesDAO()
        : base()
        {
            this.logger = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Logging.txt");
        }

        /// <summary>
        /// Metodo que obtiene una lista de materiales provenientes de la base de datos.
        /// </summary>
        /// <returns></returns>
        public override List<Material> GetAll()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Materiales", connection))
                {
                    try
                    {
                        List<Material> materials = new List<Material>();

                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Material material = new Material();

                                switch (dataReader["tipoDeMaterial"].ToString())
                                {
                                    case "Acero":
                                        material = new Material { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Ancho = double.Parse(dataReader["ancho"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), Densidad = double.Parse(dataReader["densidad"].ToString()) };
                                        break;
                                    case "Aluminio":
                                        material = new Material { TipoDeMaterial = (ETipoDeMaterial)Enum.Parse(typeof(ETipoDeMaterial), dataReader["tipoDeMaterial"].ToString()), Largo = double.Parse(dataReader["largo"].ToString()), Ancho = double.Parse(dataReader["ancho"].ToString()), Alto = double.Parse(dataReader["alto"].ToString()), Densidad = double.Parse(dataReader["densidad"].ToString()) };
                                        break;
                                }
                                materials.Add(material);
                            }
                        }
                        return materials;
                    }
                    catch (Exception ex)
                    {
                        logger.saveReport(ex);
                        throw new Exception();
                        
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
        /// Metodo que realiza una actualizacion en la base de datos segun los materiales que se carguen.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool Update(Material item)
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO Materiales(largo,alto,ancho,densidad,tipoDeMaterial) VALUES (@largo,@alto,@ancho,@densidad,@tipoDeMaterial);";

                command.Parameters.AddWithValue("@largo", item.Largo);
                command.Parameters.AddWithValue("@alto", item.Alto);
                command.Parameters.AddWithValue("@ancho", item.Ancho);
                command.Parameters.AddWithValue("@densidad", item.Densidad);
                command.Parameters.AddWithValue("@tipoDeMaterial", item.TipoDeMaterial.ToString());

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected >= 1)
                    retorno = true;
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

            return retorno;
        }

        public bool ClearTable()
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "DROP TABLE Materiales";

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <0)
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


        public bool CleateTable()
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = @"CREATE TABLE Materiales
   (
      ID int IDENTITY(1,1) PRIMARY KEY,
      largo float(53) NOT NULL,
	  ancho float(53) NOT NULL,
	  alto float(53) NOT NULL,
	  densidad float(53) NOT NULL, 
      tipoDeMaterial varchar(MAX) NOT NULL
   )";

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected < 0)
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
        /// Metodo encargado de eliminar un material segun si ID
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

                command.CommandText = "DELETE FROM Materiales WHERE ID=@ID;";
                command.Parameters.AddWithValue("@ID", int.Parse(input));

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected >= 1)
                        retorno = true;
            }
            catch (Exception ex)
            {
                throw new FileException("Hubo un error con la base de datos",ex);
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
    }
}

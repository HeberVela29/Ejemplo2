using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ejemplo2_ProductRepository_2025.Data
{
    public class DataHelper
    {
        //SINGLETON
        private static DataHelper _instance;
        private SqlConnection _connection;

        //CONEXION
        private DataHelper()
        { 
            _connection=new SqlConnection(Properties.Resources.CadenaConexionLocal);

        }

        //Instanciamos
        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParametroSP>? param = null)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = sp;

                //agreguemos los parametros si los hay
                if (param != null)
                {
                    foreach(ParametroSP p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            catch(SqlException e)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }
    }
}

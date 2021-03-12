using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace YouthWebSite
{
    public class SqlHelper
    {
        public static readonly string connstring = ConfigurationManager.ConnectionStrings["Connstr"].ConnectionString;
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public static DataSet GetDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            try
            {
                DataSet objds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(objds);
                    return objds;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                object obj = cmd.ExecuteScalar();
                return obj;
            }

        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    if (parm!=null)
                    {
                        cmd.Parameters.Add(parm);
                    }

            }
        }
    }
}

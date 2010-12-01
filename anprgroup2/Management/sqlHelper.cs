using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Configuration;

namespace WindowsFormsApplication1
{

    public class sqlHelper
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["PNR"].ConnectionString;
        
        public sqlHelper()
        {
            //
            // Constructor
            //
        }

        public static DataTable ExecuteQuery(
            string sql,
            CommandType commandType,
            params object[] pars)
        {
            SqlConnection con = new SqlConnection(ConnectString);

            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = commandType;

            for (int i = 0; i < pars.Length; i += 2)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                com.Parameters.Add(par);
            }

            SqlDataAdapter dad = new SqlDataAdapter(com);

            DataSet dst = new DataSet();
            dad.Fill(dst);

            return dst.Tables[0];
        }

        public static void ExecuteNonQuery(
            string sql,
            CommandType commandType,
            params object[] pars)
        {
            SqlConnection con = new SqlConnection(ConnectString);
            con.Open();

            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = commandType;

            for (int i = 0; i < pars.Length; i += 2)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                com.Parameters.Add(par);
            }

            com.ExecuteNonQuery();
        }
    }
}

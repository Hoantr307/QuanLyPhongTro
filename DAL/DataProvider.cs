using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class DataProvider
    {
		private static DataProvider instance;

        public static DataProvider Instance 
        {   get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value; 
        }

        private DataProvider() { }

        //static readonly string connectionStr = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        string connectionStr = @"Data Source=HOAN\SQLEXPRESS;Initial Catalog=QuanLyPhongTro;Integrated Security=True;TrustServerCertificate=True";

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string param in listPara)
                    {
                        if (param.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                da.Dispose();
            }
            return dt;
        }

        public int ExecuteNonQuery(string Query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(Query, conn);

                if (parameter != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                conn.Close();
            }

            return data;
        }
    }
}

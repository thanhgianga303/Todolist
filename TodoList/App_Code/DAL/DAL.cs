using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TodoList.App_Code.DAL
{
    public class DAL
    {
        public static SqlConnection con;
        public static void connectDB()
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(cnnstring);
            con.Open();
        }
        public static void closeDB()
        {
            con.Close();
        }
    }
}
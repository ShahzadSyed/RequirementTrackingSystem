using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RTS
{
    class ConnectionSql
    {
        public SqlCommand SqlCmd = new SqlCommand();
        public SqlDataReader SqlReader;
        public SqlDataAdapter SqlAdapter;




        //   IT-ORACLE HO-ERP-SHAMROOZ
        public static string serverName = "SHAHZAD\\RGSERVER";
        public static string dbNameFKI_Data = "RTS";
        public static string dbNameFKI = "";
        public static string userName = "HTXERP";
        public static string password = "@HTXERP@";





        public SqlConnection SqlCon = new SqlConnection(
        new SqlConnectionStringBuilder()
        {


            DataSource = serverName,
            InitialCatalog = dbNameFKI_Data,
            UserID = userName,
            Password = password




        }.ConnectionString
        );




        public SqlConnection SqlCon1 = new SqlConnection(
      new SqlConnectionStringBuilder()
      {



          DataSource = serverName,
          InitialCatalog = dbNameFKI,
          UserID = userName,
          Password = password




      }.ConnectionString
      );


    }
}

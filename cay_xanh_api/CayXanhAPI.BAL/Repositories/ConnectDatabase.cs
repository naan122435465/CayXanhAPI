using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CayXanhAPI.BAL.Interfaces
{

    public class ConnectDatabase : IConnectDatabase
    {
        //protected IDbConnection conn;
        //public ConnectDatabase()
        //{
        //    string connectionString = @"Data Source=10.238.200.5\SQLV2016;Initial Catalog=CayXanhDoThi;Persist Security Info=True;User ID=cayxanhdothi";
        //    conn = new SqlConnection(connectionString);

        //}
        public SqlConnection ConnectDataBase()
        {
            try
            {
                var conn = new SqlConnection
                {
                    ConnectionString = //@"Data Source=100.100.1.11;Initial Catalog=CayXanhDoThi;Persist Security Info=True;User ID=cayxanhdothi;Password=Abc@123"
                                         @"Data Source=DESKTOP-GR2F5KU\SQLEXPRESS;Initial Catalog=CayXanhApi;Integrated Security=True"
                };

                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

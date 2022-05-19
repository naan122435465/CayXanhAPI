using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface IConnectDatabase
    {
        SqlConnection ConnectDataBase();
    }
}

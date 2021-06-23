using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevexpresDashboard.Helpers
{
    public static class CustomDBFactory
    {
        public static IDbConnection GetConnection()
        {
            return new SqlConnection("data source=10.10.6.10;initial catalog=nSoft.Document;user id=nilvera;password=EUZtvYimCH@a;MultipleActiveResultSets=True");

        }
    }
}

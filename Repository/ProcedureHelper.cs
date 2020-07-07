using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RSOE.Repository
{
    public class ProcedureHelper
    {
        public SqlDataReader CallReader(string procedureName, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public SqlDataReader CallReader(string procedureName, SqlConnection connection, string parameter, int value)
        {
            SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue(parameter, value);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}

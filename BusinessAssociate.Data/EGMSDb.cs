using System;
using System.Data.SqlClient;

namespace EGMS.BusinessAssociates.Data
{
    public class EGMSDb : IDisposable
    {
        public EGMSDb(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connection { get; }
        
        public void Dispose() => Connection.Dispose();
    }
}
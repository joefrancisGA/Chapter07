using System;
using Microsoft.Data.SqlClient;

namespace EGMS.BusinessAssociates.Data.EF.InMemory
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
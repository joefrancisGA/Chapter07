using System;
using System.Data.SqlClient;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.Enums;


namespace BusinessAssociates.Infrastructure
{
    public class InternalAssociateRepository : IInternalAssociateRepository
    {

        static string ConnectionString = "Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True";

        public void Add(InternalAssociate entity)
        {
            //  insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status])
            //      VALUES(12345678, 'Atlanta Gas Light', 'AGL', 1, 0, 1, 1)

            string sql =
                "insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status]) VALUES( " +
                "@DUNSNumber, @LongName, @ShortName, @IsInternal, @IsParent, @BusinessAssociateType, @Status)";

            // TO DO:  Fix the connection string query through dependency injection
            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["BusinessAssociates"];


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DUNSNumber", entity.Id.Value);
                    cmd.Parameters.AddWithValue("@LongName", entity.LongName);
                    cmd.Parameters.AddWithValue("@ShortName", entity.ShortName);
                    cmd.Parameters.AddWithValue("@IsInternal", true);
                    cmd.Parameters.AddWithValue("@IsParent", entity.IsParent);
                    cmd.Parameters.AddWithValue("@BusinessAssociateType", (int)entity.InternalAssociateType);
                    cmd.Parameters.AddWithValue("@Status", (int)entity.Status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Exists(AssociateId id)
        {
            string sql = "SELECT DUNSNumber FROM BusinessAssociate WHERE DUNSNumber = " + id.Value;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public InternalAssociate Load(AssociateId id)
        {
            //  insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status])
            //      VALUES(12345678, 'Atlanta Gas Light', 'AGL', 1, 0, 1, 1)

            string sql =
                "SELECT DUNSNumber, LongName, ShortName, IsParent, BusinessAssociateType, [Status] FROM BusinessAssociate" +
                " WHERE DUNSNumber = " + id.Value;

            string connString = "Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        InternalAssociate internalAssociate = new InternalAssociate
                        {
                            DUNSNumber = Convert.ToInt32(reader[0]),
                            LongName = reader[1].ToString(),
                            ShortName = reader[2].ToString(),
                            IsParent = Convert.ToBoolean(reader[3]),
                            InternalAssociateType = (InternalAssociateType) reader[4],
                            Status = (Status) reader[5]
                        };


                        return internalAssociate;
                    }
                }
            }
        }
    }
}
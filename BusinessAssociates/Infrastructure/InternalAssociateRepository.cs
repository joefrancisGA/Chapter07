using System;
using System.Data.SqlClient;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;


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
                    cmd.Parameters.AddWithValue("@LongName", entity.LongName.Value);
                    cmd.Parameters.AddWithValue("@ShortName", entity.ShortName.Value);

                    // Because the associate is internal, we can assume this property is always true
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
                        return new InternalAssociate
                        {
                            DUNSNumber = DUNSNumber.Create(Convert.ToInt32(reader[0])),
                            LongName = LongName.Create(reader[1].ToString()),
                            ShortName = ShortName.Create(reader[2].ToString()),
                            IsParent = Convert.ToBoolean(reader[3]),
                            InternalAssociateType = (InternalAssociateType) reader[4],
                            Status = (Status) reader[5]
                        };
                    }
                }
            }
        }
    }
}
using System;
using System.Data.SqlClient;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.Repositories;
using BusinessAssociates.Domain.ValueObjects;


namespace BusinessAssociates.Infrastructure
{

    public class AssociateRepository : IAssociateRepository
    {
        internal EGMSDb Db { get; set; }

        internal AssociateRepository(EGMSDb db)
        {
            Db = db;
        }

        public void Add(Associate entity)
        {
            //  insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status])
            //      VALUES(12345678, 'Atlanta Gas Light', 'AGL', 1, 0, 1, 1)
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status]) VALUES( " +
                                  "@DUNSNumber, @LongName, @ShortName, @IsInternal, @IsParent, @BusinessAssociateType, @Status)";

                Db.Connection.Open();

                cmd.Parameters.AddWithValue("@DUNSNumber", entity.DUNSNumber.Value);
                cmd.Parameters.AddWithValue("@LongName", entity.LongName.Value);
                cmd.Parameters.AddWithValue("@ShortName", entity.ShortName.Value);

                // Because the associate is internal, we can assume this property is always true
                cmd.Parameters.AddWithValue("@IsInternal", true);
                cmd.Parameters.AddWithValue("@IsParent", entity.IsParent);
                cmd.Parameters.AddWithValue("@BusinessAssociateType", (int)entity.AssociateType);
                cmd.Parameters.AddWithValue("@Status", (int)entity.Status);

                cmd.ExecuteNonQuery();
            }
        }

        Associate IAssociateRepository.Load(AssociateId id)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, BusinessAssociateType, [Status] FROM BusinessAssociate" +
                                    " WHERE ID = " + id.Value;

                Db.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    Associate associate = new Associate(new AssociateId(Convert.ToInt32(reader[0])))
                    {
                        DUNSNumber = DUNSNumber.Create(Convert.ToInt32(reader[1])),
                        LongName = LongName.Create(reader[2].ToString()),
                        ShortName = ShortName.Create(reader[3].ToString()),
                        IsParent = Convert.ToBoolean(reader[4]),
                        AssociateType = (AssociateType) reader[5],
                        Status = (Status) reader[6]
                    };

                    return associate;
                }
            }
        }


        public void UpdateDUNSNumber(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET DUNSNumber = @DUNSNumber WHERE Id = @Id";
                Db.Connection.Open();

                cmd.Parameters.AddWithValue("@DUNSNumber", entity.DUNSNumber.Value);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAssociateType(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET BusinessAssociateType = @BusinessAssociateType WHERE Id = @Id";
                Db.Connection.Open();

                cmd.Parameters.AddWithValue("@BusinessAssociateType", (int)entity.AssociateType);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLongName(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET LongName = @LongName WHERE Id = @Id";

                Db.Connection.Open();

                cmd.Parameters.AddWithValue("@LongName", entity.LongName.Value);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateIsParent(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET IsParent = @IsParent WHERE Id = @Id";
                Db.Connection.Open();

                cmd.Parameters.AddWithValue("@IsParent", entity.IsParent);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET Status = @Status WHERE Id = @Id";
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@Status", (int)entity.Status);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateShortName(Associate entity)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE BusinessAssociate SET ShortName = @ShortName WHERE Id = @Id";
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@ShortName", entity.ShortName.Value);
                cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Exists(AssociateId id)
        {
            using (SqlCommand cmd = Db.Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT DUNSNumber FROM BusinessAssociate WHERE DUNSNumber = " + id.Value;

                Db.Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
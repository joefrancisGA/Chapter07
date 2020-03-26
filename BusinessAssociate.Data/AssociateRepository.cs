using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Data
{
    public class AssociateRepository : IAssociateRepository
    {
        internal EGMSDb Db { get; set; }

        public AssociateRepository(EGMSDb db)
        {
            Db = db;
        }

        public void Add(Associate entity)
        {
            //  insert into Associate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status])
            //      VALUES(12345678, 'Atlanta Gas Light', 'AGL', 1, 0, 1, 1)
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);

            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into Associate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status]) VALUES( " +
                              "@DUNSNumber, @LongName, @ShortName, @IsInternal, @IsParent, @BusinessAssociateType, @Status)";

            connection.Open();

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

        public void Delete(Associate entity)
        { 
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);

            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE Associate WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        // TO DO: Use numeric constants below
        public async Task<Associate> Load(AssociateId id)
        {
            await using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            await using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, BusinessAssociateType, StatusId FROM Associate" +
                              " WHERE ID = " + id.Value;

            connection.Open();

            await using SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            Associate associate = new Associate
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


        public void UpdateDUNSNumber(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET DUNSNumber = @DUNSNumber WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@DUNSNumber", entity.DUNSNumber.Value);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public void UpdateAssociateType(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET BusinessAssociateType = @BusinessAssociateType WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@BusinessAssociateType", (int)entity.AssociateType);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public void UpdateLongName(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET LongName = @LongName WHERE Id = @Id";

            connection.Open();

            cmd.Parameters.AddWithValue("@LongName", entity.LongName.Value);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public void UpdateIsParent(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET IsParent = @IsParent WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@IsParent", entity.IsParent);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public void UpdateStatus(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET Status = @Status WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@Status", (int)entity.Status);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public void UpdateShortName(Associate entity)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Associate SET ShortName = @ShortName WHERE Id = @Id";
            connection.Open();

            cmd.Parameters.AddWithValue("@ShortName", entity.ShortName.Value);
            cmd.Parameters.AddWithValue("@Id", entity.Id.Value);

            cmd.ExecuteNonQuery();
        }

        public bool Exists(AssociateId id)
        {
            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT DUNSNumber FROM Associate WHERE DUNSNumber = " + id.Value;

            connection.Open();

            using SqlDataReader reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public void AddOperatingContext(AssociateId id, OperatingContext entity)
        {
            //  insert into BusinessAssociate(DUNSNumber, LongName, ShortName, IsInternal, IsParent, BusinessAssociateType, [Status])
            //      VALUES(12345678, 'Atlanta Gas Light', 'AGL', 1, 0, 1, 1)

            using SqlConnection connection = new SqlConnection(Db.Connection.ConnectionString);
            using SqlCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.Transaction = connection.BeginTransaction("AddOperatingContext");

            try
            {
                cmd.CommandText =
                    "insert into OperatingContext(ActingBATypeId, CertificationId, FacilityId, IsDeactivating, LegacyId, OperatingContextTypeId, ProviderTypeId) VALUES( " +
                    "@ActingBATypeId, @CertificationId, @FacilityId, @IsDeactivating, @LegacyId, @OperatingContextTypeId, @ProviderTypeId)";

                cmd.Parameters.AddWithValue("@ActingBATypeId", (int) entity.ActingBAType);
                cmd.Parameters.AddWithValue("@CertificationId", entity.CertificationId == null ? entity.CertificationId : null);
                cmd.Parameters.AddWithValue("@FacilityId", entity.FacilityId.Value);
                cmd.Parameters.AddWithValue("@IsDeactivating", entity.IsDeactivating);
                cmd.Parameters.AddWithValue("@LegacyId", entity.LegacyId);
                cmd.Parameters.AddWithValue("@OperatingContextTypeId", (int) entity.OperatingContextType);
                cmd.Parameters.AddWithValue("@ProviderTypeId", (int) entity.ProviderType);

                int operatingContextId = (int) cmd.ExecuteScalar();

                cmd.CommandText =
                    "INSERT INTO AssociateOperatingContext (AssociateId, OperatingContextId) VALUES ( " +
                    "@AssociateId, @OperatingContextId)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AssociateId", id);
                cmd.Parameters.AddWithValue("@OperatingContextId", operatingContextId);

                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();

                throw;
            }
        }
    }
}
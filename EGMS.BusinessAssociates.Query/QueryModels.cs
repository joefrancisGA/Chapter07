namespace EGMS.BusinessAssociates.Query
{
    public static class QueryModels
    {
        // contains standard grid list query options.
        public class BaseQueryParams
        {
            public string Sort { get; set; }
            public int? Page { get; set; }
            public int? PageSize { get; set; }
        }

        public class AssociateQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class AddressQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class AgentRelationshipQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class ContactQueryParams : BaseQueryParams
        {
            public int? AssociateId { get; set; }
            public int? Id { get; set; }
        }

        public class CertificationQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class ContactConfigurationQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class CustomerQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class EMailQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class OperatingContextQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }
        
        public class PhoneQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class RoleQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class EGMSPermissionQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }
        
        public class RoleEGMSPermissionQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

        public class UserQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }


    }
}

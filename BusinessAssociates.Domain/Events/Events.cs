﻿using EGMS.BusinessAssociates.Domain.Enums;

namespace EGMS.BusinessAssociates.Domain.Events
{
    public static class Events
    {
        public class InternalAssociateCreated
        {
            public int Id { get; set; }

            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public AssociateType InternalAssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class InternalAssociateDUNSNumberUpdated
        {
            public int Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class InternalAssociateTypeUpdated
        {
            public int Id { get; set; }
            public int InternalAssociateType { get; set; }
        }

        public class InternalAssociateLongNameUpdated
        {
            public int Id { get; set; }
            public string LongName { get; set; }
        }

        public class InternalAssociateIsParentUpdated
        {
            public int Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class InternalAssociateStatusUpdated
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }

        public class InternalAssociateShortNameUpdated
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
        }

        public class AssociateCreated
        {
            public int Id { get; set; }

            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public AssociateType AssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class AssociateDUNSNumberUpdated
        {
            public int Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class AssociateTypeUpdated
        {
            public int Id { get; set; }
            public int AssociateType { get; set; }
        }

        public class AssociateLongNameUpdated
        {
            public int Id { get; set; }
            public string LongName { get; set; }
        }

        public class AssociateIsParentUpdated
        {
            public int Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class AssociateStatusUpdated
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }

        public class AssociateShortNameUpdated
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
        }

        public class ExternalAssociateCreated
        {
            public int Id { get; set; }

            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public AssociateType ExternalAssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class ExternalAssociateDUNSNumberUpdated
        {
            public int Id { get; set; }

            public int DUNSNumber { get; set; }
        }

        public class ExternalAssociateTypeUpdated
        {
            public int Id { get; set; }
            public int ExternalAssociateType { get; set; }
        }

        public class ExternalAssociateLongNameUpdated
        {
            public int Id { get; set; }
            public string LongName { get; set; }
        }

        public class ExternalAssociateIsParentUpdated
        {
            public int Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class ExternalAssociateStatusUpdated
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }

        public class ExternalAssociateShortNameUpdated
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
        }
    }
}
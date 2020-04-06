using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Associates
    {
        public Associates()
        {
            AgentRelationshipsAgent = new HashSet<AgentRelationships>();
            AgentRelationshipsPrincipal = new HashSet<AgentRelationships>();
            AgentUsers = new HashSet<AgentUsers>();
            AssociateCustomers = new HashSet<AssociateCustomers>();
            AssociateOperatingContexts = new HashSet<AssociateOperatingContexts>();
            AssociateUsers = new HashSet<AssociateUsers>();
            Customers = new HashSet<Customers>();
            OperatingContexts = new HashSet<OperatingContexts>();
            PredecessorBusinessAssociatesAssociate = new HashSet<PredecessorBusinessAssociates>();
            PredecessorBusinessAssociatesPredecessorAssociate = new HashSet<PredecessorBusinessAssociates>();
            UserOperatingContexts = new HashSet<UserOperatingContexts>();
        }

        public int Id { get; set; }
        public int Dunsnumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public bool IsInternal { get; set; }
        public bool IsParent { get; set; }
        public int AssociateTypeId { get; set; }
        public int StatusCodeId { get; set; }
        public bool IsDeactivating { get; set; }

        public virtual AssociateTypes AssociateType { get; set; }
        public virtual StatusCodes StatusCode { get; set; }
        public virtual ICollection<AgentRelationships> AgentRelationshipsAgent { get; set; }
        public virtual ICollection<AgentRelationships> AgentRelationshipsPrincipal { get; set; }
        public virtual ICollection<AgentUsers> AgentUsers { get; set; }
        public virtual ICollection<AssociateCustomers> AssociateCustomers { get; set; }
        public virtual ICollection<AssociateOperatingContexts> AssociateOperatingContexts { get; set; }
        public virtual ICollection<AssociateUsers> AssociateUsers { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
        public virtual ICollection<PredecessorBusinessAssociates> PredecessorBusinessAssociatesAssociate { get; set; }
        public virtual ICollection<PredecessorBusinessAssociates> PredecessorBusinessAssociatesPredecessorAssociate { get; set; }
        public virtual ICollection<UserOperatingContexts> UserOperatingContexts { get; set; }
    }
}

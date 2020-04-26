using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class User : Entity<int>
    {
        private User()
        {
            Initialize();
        }

        public User(Action<object> applier) : base(applier)
        {
            Initialize();
        }

        private void Initialize()
        {
            AgentUsers = new HashSet<AgentUser>();
            AssociateUsers = new HashSet<AssociateUser>();
        }


        public static User Create(int userId, int contactId, IDMSSID idmssid, int departmentCodeId, bool isInternal,
            bool isActive, bool hasEGMSAccess, DateTime deactivationDate)
        {
            return new User
            {
                Id = userId,
                ContactId = contactId,
                IDMSSID = idmssid,
                DepartmentCodeId = departmentCodeId,
                IsInternal = isInternal,
                IsActive = isActive,
                HasEGMSAccess = hasEGMSAccess,
                DeactivationDate = deactivationDate
            };
        }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public IDMSSID IDMSSID { get; set; }
        public int DepartmentCodeId { get; set; }

        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }
        public bool HasEGMSAccess { get; set; }
        public DateTime DeactivationDate { get; set; }

        public HashSet<AgentUser> AgentUsers { get; set; }
        public HashSet<AssociateUser> AssociateUsers { get; set; }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Role : Entity<int>
    {
        public RoleName RoleName { get; set; }
        public RoleDescription RoleDescription { get; set; }

        // Collections
        public IEnumerable<Permission> Permissions { get; set; }

        public Role(Action<object> applier) : base(applier)
        {
        }

        public Role()
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class RolePermission : Entity<DatabaseId>
    {
        public DatabaseId RoleId { get; set; }
        public DatabaseId PermissionId { get; set; }

        public RolePermission(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
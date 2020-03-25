using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class EMail// : Entity<DatabaseId>
    {
        public DatabaseId UserId { get; set; }
        public EMailAddress EMailAddress { get; set; }
        public bool IsPrimary { get; set; }

        //public EMail(Action<object> applier) : base(applier)
        //{
        //}

        //protected override void When(object @event)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
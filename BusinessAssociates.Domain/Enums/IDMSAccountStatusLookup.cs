using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{

    public class IDMSAccountStatusLookup : Entity<int>
    {
        public enum IDMSAccountStatusEnum { }

        public static readonly
            IReadOnlyDictionary<int, IDMSAccountStatusLookup> IDMSAccountStatusTypes =
                new Dictionary<int, IDMSAccountStatusLookup>
                {
                };

        public int AccountStatusId { get; private set; }

        public AccountStatusName Name { get; private set; }
        public AccountStatusDesc Desc { get; private set; }

        protected IDMSAccountStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(IDMSAccountStatusLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
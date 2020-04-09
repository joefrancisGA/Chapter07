using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class AccountStatusLookup : Entity<int>
    {
        public enum AccountStatusEnum { }

        public static readonly
            IReadOnlyDictionary<int, AccountStatusLookup> AccountStatusTypes =
                new Dictionary<int, AccountStatusLookup>
                {
                };

        public int AccountStatusId { get; private set; }

        public AccountStatusName Name { get; private set; }
        public AccountStatusDesc Desc { get; private set; }

        protected AccountStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(AccountStatusLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
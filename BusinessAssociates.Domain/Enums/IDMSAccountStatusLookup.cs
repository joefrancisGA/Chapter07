using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{

    public class IDMSAccountStatusLookup : Entity<int>
    {
        public enum IDMSAccountStatusEnum
        {
            Active = 1,
            Disabled = 2
        }

        public static readonly
            IReadOnlyDictionary<int, IDMSAccountStatusLookup> IDMSAccountStatusTypes =
                new Dictionary<int, IDMSAccountStatusLookup>
                {
                    {
                        (int) IDMSAccountStatusEnum.Active,
                        new IDMSAccountStatusLookup
                        {
                            Id = (int) IDMSAccountStatusEnum.Active,
                            AccountStatusId = (int) IDMSAccountStatusEnum.Active,
                            Name = AccountStatusName.FromString("Active"),
                            Desc = "Active Description"
                        }
                    },
                };

        public int AccountStatusId { get; private set; }

        public AccountStatusName Name { get; private set; }
        public string Desc { get; private set; }

        protected IDMSAccountStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(IDMSAccountStatusLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
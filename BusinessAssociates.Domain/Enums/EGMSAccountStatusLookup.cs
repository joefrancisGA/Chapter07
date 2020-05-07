using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class EGMSAccountStatusLookup : Entity<int>
    {
        public enum EGMSAccountStatusEnum
        {
            Active = 1,
            Disabled = 2
        }

        public static readonly
            IReadOnlyDictionary<int, EGMSAccountStatusLookup> EGMSAccountStatusTypes =
                new Dictionary<int, EGMSAccountStatusLookup>
                {
                    {
                        (int) EGMSAccountStatusEnum.Active,
                        new EGMSAccountStatusLookup
                        {
                            Id = (int) EGMSAccountStatusEnum.Active,
                            EGMSAccountStatusId = (int) EGMSAccountStatusEnum.Active,
                            Name = AccountStatusName.FromString("Active"),
                            Desc = "Active Description"
                        }
                    },
                    {
                        (int) EGMSAccountStatusEnum.Disabled,
                        new EGMSAccountStatusLookup
                        {
                            Id = (int) EGMSAccountStatusEnum.Disabled,
                            EGMSAccountStatusId = (int) EGMSAccountStatusEnum.Disabled,
                            Name = AccountStatusName.FromString("Disabled"),
                            Desc = "Disabled Description"
                        }
                    }
                };

        public int EGMSAccountStatusId { get; private set; }

        public AccountStatusName Name { get; private set; }
        public string Desc { get; private set; }

        protected EGMSAccountStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(EGMSAccountStatusLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}
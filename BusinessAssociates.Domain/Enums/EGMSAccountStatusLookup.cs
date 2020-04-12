﻿using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class EGMSAccountStatusLookup : Entity<int>
    {
        public enum EGMSAccountStatusEnum { }

        public static readonly
            IReadOnlyDictionary<int, EGMSAccountStatusLookup> EGMSAccountStatusTypes =
                new Dictionary<int, EGMSAccountStatusLookup>
                {
                };

        public int EGMSAccountStatusId { get; private set; }

        public AccountStatusName Name { get; private set; }
        public AccountStatusDesc Desc { get; private set; }

        protected EGMSAccountStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(EGMSAccountStatusLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}
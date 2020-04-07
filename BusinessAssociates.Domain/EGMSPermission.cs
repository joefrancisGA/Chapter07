﻿using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class EGMSPermission : Entity<int>
    {
        public PermissionName PermissionName { get; set; }
        public PermissionDescription PermissionDescription { get; set; }
        public bool IsActive { get; set; }

        
        public EGMSPermission() { }

        public EGMSPermission(Action<object> applier) : base(applier)
        {
        }
        
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
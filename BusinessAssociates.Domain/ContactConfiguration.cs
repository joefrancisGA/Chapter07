﻿using System;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class ContactConfiguration
    {
        public DatabaseId Id { get; set; }

        public DatabaseId ContactId { get; set; }
        public DatabaseId FacilityId { get; set; }
        public ContactType ContactType { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
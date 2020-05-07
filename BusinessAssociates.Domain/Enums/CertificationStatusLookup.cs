using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


// TO DO:  Need to fix up ValueObjects
namespace EGMS.BusinessAssociates.Domain.Enums
{
    public class CertificationStatusLookup : Entity<int>
    {
        public enum CertificationStatusEnum
        {
            Certified = 1,
            Decertified = 2,

            // JOEF added NOT_CERTIFIED to cover a specification gap
            NotCertified = 3
        }

        public static readonly
            IReadOnlyDictionary<int, CertificationStatusLookup> BalancingLevelTypes =
                new Dictionary<int, CertificationStatusLookup>
                {
                    {
                        (int) CertificationStatusEnum.Certified,
                        new CertificationStatusLookup
                        {
                            Id = (int) CertificationStatusEnum.Certified,
                            CertificationLevelId = (int) CertificationStatusEnum.Certified,
                            Name = CertificationLevelTypeName.FromString("Certified"),
                            Desc = "Decertified Description"
                        }
                    },
                    {
                        (int) CertificationStatusEnum.Decertified,
                        new CertificationStatusLookup
                        {
                            Id = (int) CertificationStatusEnum.Decertified, 
                            CertificationLevelId = (int) CertificationStatusEnum.Decertified,
                            Name = CertificationLevelTypeName.FromString("Decertified"),
                            Desc = "Decertified Description"
                        }
                    },
                    {
                        (int) CertificationStatusEnum.NotCertified,
                        new CertificationStatusLookup
                        {
                            Id = (int) CertificationStatusEnum.NotCertified,
                            CertificationLevelId = (int) CertificationStatusEnum.NotCertified,
                            Name = CertificationLevelTypeName.FromString("NotCertified"),
                            Desc = "NotCertified Description"
                        }
                    },
                };

        public int CertificationLevelId { get; private set; }

        public CertificationLevelTypeName Name { get; private set; }
        public string Desc { get; private set; }

        public List<Certification> Certifications { get; set; }

        protected CertificationStatusLookup() { }

        protected override void When(object @event)
        {
            throw new InvalidOperationException($"{nameof(BalancingLevelTypeLookup)} events not supported.");
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}

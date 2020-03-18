namespace BusinessAssociates.Domain.Enums
{
    public enum CertificationStatus
    {
        Certified = 1,
        Decertified = 2,

        // JOEF added NOT_CERTIFIED to cover a specification gap
        NotCertified = 3
    }
}
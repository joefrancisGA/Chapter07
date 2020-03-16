namespace BusinessAssociates.Domain.Enums
{
    public enum CertificationStatus
    {
        CERTIFIED = 1,
        DECERTIFIED = 2,

        // JOEF added NOT_CERTIFIED to cover a specification gap
        NOT_CERTIFIED = 3
    }
}
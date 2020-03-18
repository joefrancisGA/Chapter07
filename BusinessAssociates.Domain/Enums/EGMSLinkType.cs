using System.Diagnostics.CodeAnalysis;

namespace BusinessAssociates.Domain.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum EGMSLinkType
    { 
        ConfigureUser = 1,
        ModifyUser = 2
    }
}
using System.ComponentModel;

namespace PortalApi.DTO.Enum
{
    public enum LegalStatus
    {
        [Description("Open Work Permit")]
        OpenWorkPermit,
        [Description("Closed Work Permit")]
        ClosedWorkPermit,
        [Description("Permanent Resident")]
        PermanentResident,
        [Description("Citizen")]
        Citizen,
        [Description("None")]
        None
    }
}

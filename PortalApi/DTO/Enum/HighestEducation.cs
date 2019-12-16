using System.ComponentModel;

namespace PortalApi.DTO.Enum
{
    public enum HighestEducation
    {
        [Description("Diploma")]
        Diploma,
        [Description("Bachelors")]
        Bachelors,
        [Description("Master or higher")]
        MasterOrHigher,
        [Description("None")]
        None
    }
}

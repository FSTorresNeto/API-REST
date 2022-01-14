using System.ComponentModel;

namespace api_rest.Domain.Helpers
{
    public enum EUnitOfPlatform : byte
    {
        [Description("Xbox")]
        Xbox = 1,

        [Description("PlayStation")]
        PlayStation = 2,

        [Description("Nitendo")]
        Nitendo = 3,

        [Description("PC")]
        PC = 4,

        [Description("AllPlatforms")]
        AllPlatforms = 5
    }

}

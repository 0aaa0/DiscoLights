using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DiscoLights
{
    public class Translations : ITranslation
    {
        [Description("Response in the console when enabling disco.")]
        public string DiscoEnabledCommandResponse { get; set; } = "The disco party started.";

        [Description("Response in the console when disabling disco.")]
        public string DiscoDisabledCommandResponse { get; set; } = "The disco party ended.";

        [Description("Response in the console when player doesnt have permission to execute the command.")]
        public string NoPermissionCommandResponse { get; set; } = "You don't have permission to execute this command.";
    }
}

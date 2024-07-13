using CommandSystem;
using System;

namespace DiscoLights.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class DiscoLightsParentCommand : ParentCommand
    {
        public override string Command => "discolights";

        public override string[] Aliases => new string[] { "disco" };

        public override string Description => "DiscoLights parent command.";

        public bool SanitizeResponse => false;

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new DiscoPlayerCommand());
            RegisterCommand(new DiscoRoomCommand());
        }

        public DiscoLightsParentCommand() => LoadGeneratedCommands();

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}

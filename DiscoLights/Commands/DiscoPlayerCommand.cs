using CommandSystem;
using DiscoLights.Components;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;
using System;
using UnityEngine;

using Object = UnityEngine.Object;

namespace DiscoLights.Commands
{
    public class DiscoPlayerCommand : ICommand
    {
        public string Command => "player";

        public string[] Aliases => new string[] { };

        public string Description => "Turns you into a disco ball.";

        public bool SanitizeResponse => false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(!(sender is PlayerCommandSender playerCommandSender))
            {
                response = "This command must be executed in-game.";
                return false;
            }
            if (!playerCommandSender.CheckPermission("discolights.player"))
            {
                response = Plugin.Instance.Translation.NoPermissionCommandResponse;
                return false;
            }

            GameObject playerGameObject = Player.Get(playerCommandSender.ReferenceHub).GameObject;

            if(playerGameObject.TryGetComponent(out DiscoPlayer discoPlayer))
            {
                Object.Destroy(discoPlayer);

                response = Plugin.Instance.Translation.DiscoDisabledCommandResponse;
                return true;
            }
            else
            {
                playerGameObject.AddComponent<DiscoPlayer>();
                playerGameObject.GetComponent<DiscoPlayer>().player = Player.Get(playerCommandSender.ReferenceHub);

                response = Plugin.Instance.Translation.DiscoEnabledCommandResponse;
                return true;
            }
        }
    }
}

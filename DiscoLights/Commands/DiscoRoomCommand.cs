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
    public class DiscoRoomCommand : ICommand
    {
        public string Command => "room";

        public string[] Aliases => new string[] { };

        public string Description => "Turns the room you are currently in into a disco party.";

        public bool SanitizeResponse => false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(!(sender is PlayerCommandSender playerCommandSender))
            {
                response = "This command must be executed in-game.";
                return false;
            }
            if (!playerCommandSender.CheckPermission("discolights.room"))
            {
                response = Plugin.Instance.Translation.NoPermissionCommandResponse;
                return false;
            }

            Player player = Player.Get(playerCommandSender.ReferenceHub);

            if(player.CurrentRoom.gameObject.TryGetComponent(out DiscoRoom discoRoom))
            {
                Object.Destroy(discoRoom);

                response = Plugin.Instance.Translation.DiscoDisabledCommandResponse;
                return true;
            }
            else
            {
                player.CurrentRoom.gameObject.AddComponent<DiscoRoom>();
                player.CurrentRoom.gameObject.GetComponent<DiscoRoom>().room = player.CurrentRoom;

                response = Plugin.Instance.Translation.DiscoEnabledCommandResponse;
                return true;
            }
        }
    }
}

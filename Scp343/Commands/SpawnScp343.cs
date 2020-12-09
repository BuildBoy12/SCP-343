namespace Scp343.Commands
{
    using CommandSystem;
    using Components;
    using Exiled.API.Features;
    using Exiled.Permissions.Extensions;
    using System;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnScp343 : ICommand
    {
        public string Command => "spawn343";

        public string[] Aliases => new[] {"343"};

        public string Description => "Spawns a Scp343.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((sender as CommandSender)?.SenderId);
            if (!player.CheckPermission("scp343.spawn"))
            {
                response = "You do not have permissions to run this command!";
                return false;
            }

            if (arguments.Count < 1)
            {
                player.GameObject.AddComponent<Scp343Component>();
                response = "You spawned yourself as SCP-343";
                return true;
            }

            Player target = Player.Get(arguments.At(0));
            if (target == null)
            {
                response = $"Could not find a player from argument: {arguments.At(0)}";
                return false;
            }

            target.GameObject.AddComponent<Scp343Component>();
            response = $"{target.Nickname} is now SCP-343";
            return true;
        }
    }
}
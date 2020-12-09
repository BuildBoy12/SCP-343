using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using Respawning;
using SCP_343;
using System;
using System.Linq;

namespace Commands.SpawnSCP343
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    class SpawnSCP343 : ParentCommand
    {

        public SpawnSCP343() => LoadGeneratedCommands();

        public override string Command { get; } = "spawnscp343";

        public override string[] Aliases { get; } = new string[] { "343", "spawn343" };

        public override string Description { get; } = "Spawn SCP-343!";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            if (!((CommandSender)sender).CheckPermission("scp343.spawn"))
            {
                response = "You do not have permissions to run this command!";
                return false;
            }

            switch (arguments.Count)
            {
                case 0:
                    if (EventHandlers.scp343.Count != 0)
                    {
                        response = "There is already a living SCP-343";
                        return false;
                    }
                    else
                    {
                        player.SetRole(RoleType.ClassD);
                        Timing.CallDelayed(1f, () =>
                        {
                            EventHandlers.spawn343(player);
                        });
                        response = "You spawned yourself as SCP-343";
                        return true;
                    }
                case 1:
                    Player target = Player.Get(arguments.At(0));

                    if(target == null)
                    {
                        response = $"The player {arguments.At(1)} is invalid";
                        return false;
                    }

                    target.SetRole(RoleType.ClassD);
                    Timing.CallDelayed(1f, () =>
                    {
                        EventHandlers.spawn343(target);
                    });
                    response = $"The player {arguments.At(1)} is now SCP-343";
                    return true;
                default:
                    response = "Usage: spawn343";
                    return false;
            }
            


        }
    }
}

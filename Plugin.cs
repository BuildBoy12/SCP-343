using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerEvents = Exiled.Events.Handlers.Server;
using PlayerEvents = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;
using NukeEvents = Exiled.Events.Handlers.Warhead;

namespace SCP_343
{
    class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Developed by TheVoidNebula";
        public override string Name { get; } = "SCP-343";
        public override string Prefix { get; } = "SCP-343";
        public override Version Version { get; } = new Version(1, 0, 0);

        public static Plugin Singleton;

        internal EventHandlers EventHandlers { get; set; }
        public override void OnEnabled()
        {
            Singleton = this;
            Log.Info(Name + " " + Author + " Version: " + Version);
            EventHandlers = new EventHandlers();
            PlayerEvents.ChangingRole += EventHandlers.onRoleChange;
            PlayerEvents.Died += EventHandlers.onDeath;
            PlayerEvents.Left += EventHandlers.onLeave;
            PlayerEvents.Handcuffing += EventHandlers.onDetain;
            PlayerEvents.DroppingItem += EventHandlers.onItemDrop;
            PlayerEvents.PickingUpItem += EventHandlers.onItemGrab;
            MapEvents.Decontaminating += EventHandlers.onDecontamination;
            NukeEvents.Detonated += EventHandlers.onWarheadExplosion;
            ServerEvents.RoundEnded += EventHandlers.onRoundEnd;

        }


        public override void OnDisabled()
        {

            EventHandlers = null;

            PlayerEvents.ChangingRole -= EventHandlers.onRoleChange;
            PlayerEvents.Died -= EventHandlers.onDeath;
            PlayerEvents.Left -= EventHandlers.onLeave;
            PlayerEvents.Handcuffing -= EventHandlers.onDetain;
            PlayerEvents.DroppingItem -= EventHandlers.onItemDrop;
            PlayerEvents.PickingUpItem -= EventHandlers.onItemGrab;
            MapEvents.Decontaminating -= EventHandlers.onDecontamination;
            NukeEvents.Detonated -= EventHandlers.onWarheadExplosion;
            ServerEvents.RoundEnded -= EventHandlers.onRoundEnd;
        }

        public override void OnReloaded() { }


    }
}

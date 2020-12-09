namespace Scp343
{
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        [Description("Enable or Disable the SCP-343 Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The maximum amount of Scp343's that can spawn.")] 
        public int MaxScp343s { get; private set; } = 1;

        [Description("The chance that SCP-343 spawns in a round.")]
        public int SpawnChance { get; private set; } = 33;

        [Description("Should SCP-343 be able to pickup items?")]
        public bool CanGrab { get; private set; } = false;

        [Description("Should SCP-343 be able to drop items?")]
        public bool CanDrop { get; private set; } = false;

        [Description("Should SCP-343 be able to open any door?")]
        public bool HasBypass { get; private set; } = true;

        [Description("Should SCP-343 be in godmode?")]
        public bool IsInvincible { get; private set; } = true;

        [Description("Broadcast that plays when Scp343 spawns.")]
        public Broadcast SpawnBroadcast { get; private set; } = new Broadcast(
            "<b>You have spawned as <color=red>SCP-343</color></b>\n<i>Help your fellow <color=orange>Class-D</color> to escape!</i>");

        [Description("The Items SCP-343 spawns with.")]
        public List<ItemType> Scp343Inventory { get; private set; } = new List<ItemType>
        {
            ItemType.Flashlight
        };
    }
}
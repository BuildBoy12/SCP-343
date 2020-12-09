using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCP_343
{
    class Config : IConfig
    {

        [Description("Enable or Disable the SCP-343 Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The chance that SCP-343 spawns in a round.")]
        public int spawnChance { get; set; } = 33;

        [Description("Should SCP-343 be able to pickup items?")]
        public bool canGrab { get; set; } = false;

        [Description("Should SCP-343 be able to drop items?")]
        public bool canDrop { get; set; } = false;

        [Description("Should SCP-343 be able to open any door?")]
        public bool hasBypass { get; set; } = true;

        [Description("Should SCP-343 be in godmode?")]
        public bool isInvincible { get; set; } = true;

        [Description("Customize the broadcast SCP-343 gets when he spawns in.")]
        public string spawnBroadcast { get; set; } = "<b>You have spawned as <color=red>SCP-343</color></b>\n<i>Help your fellow <color=orange>Class-D</color> to escape!</i>";

        [Description("How long should Broadcast be? (in seconds)")]
        public ushort broadcastLength { get; set; } = 10;

        [Description("Customize the broadcast SCP-343 gets when he dies to the nuke.")]
        public string nukeDeath343 { get; set; } = "<b>The Powers of the Alpha Warhead have weakend you</b>";

        [Description("Customize the broadcast SCP-343 gets when he dies to the nuke.")]
        public string deconDeath343 { get; set; } = "<b>The Decontamination has bring you down to your knees!</b>";

        [Description("Should SCP-343 spawn with items?")]
        public bool spawnItemsEnabled { get; set; } = false;

        [Description("The Items SCP-343 spawns with.")]
        public List<ItemType> scp343Inventory { get; set; } = new List<ItemType>()

            {
                ItemType.None, ItemType.None, ItemType.None, ItemType.None, ItemType.None, ItemType.None, ItemType.None, ItemType.None
            };

        
    }
}

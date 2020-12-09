
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;

namespace SCP_343
{
    class EventHandlers
    {
        public static List<Player> scp343 = new List<Player>();

        public void onRoleChange(ChangingRoleEventArgs ev)
        {
            Random r = new Random();
            int spawnChance = r.Next(0, 101);
            if(ev.NewRole == RoleType.ClassD && scp343.Count < 1)
            {
                if(spawnChance <= Plugin.Singleton.Config.spawnChance)
                    spawn343(ev.Player);
                    return;
                
            }




            if (scp343.Contains(ev.Player))
                kill343(ev.Player);



        }

        public void onItemGrab(PickingUpItemEventArgs ev)
        {
            if (scp343.Contains(ev.Player) && Plugin.Singleton.Config.canGrab == false)
                ev.IsAllowed = false;
        }


        public void onDetain(HandcuffingEventArgs ev)
        {
            if (scp343.Contains(ev.Target))
            {
                ev.IsAllowed = false;
                ev.Cuffer.Broadcast(3, "You cannot cuff <color=red>SCP-343</color>");
            }
                

        }

        public void onItemDrop(DroppingItemEventArgs ev)
        {
            if (scp343.Contains(ev.Player) && Plugin.Singleton.Config.canDrop == false)
                ev.IsAllowed = false;
        }




        public static void spawn343(Player p)
        {
            scp343.Add(p);
            p.Broadcast(Plugin.Singleton.Config.broadcastLength, Plugin.Singleton.Config.spawnBroadcast);
            p.CustomPlayerInfo = "SCP-343";

            if (Plugin.Singleton.Config.isInvincible)
                p.IsGodModeEnabled = true;

            if (Plugin.Singleton.Config.hasBypass)
                p.IsBypassModeEnabled = true;


            if (Plugin.Singleton.Config.spawnItemsEnabled == true)
            {
                Timing.CallDelayed(1f, () =>
                {
                    foreach (ItemType item in Plugin.Singleton.Config.scp343Inventory)
                    {
                        if (item != ItemType.None)
                            p.Inventory.AddNewItem(item);
                    }
                });
                
            }
                
            
        }

        public void onLeave(LeftEventArgs ev)
        {
            if (scp343.Contains(ev.Player))
                kill343(ev.Player);
        }


        public void onWarheadExplosion()
        {
            foreach(Player players in scp343)
            {
                players.Kill(DamageTypes.Nuke);
                players.Broadcast(Plugin.Singleton.Config.broadcastLength, Plugin.Singleton.Config.nukeDeath343);
                if(scp343.Contains(players))
                kill343(players);
            }
        }

        public void onDecontamination(DecontaminatingEventArgs ev)
        {
            foreach (Player players in scp343)
            {
                players.Kill(DamageTypes.Decont);
                players.Broadcast(Plugin.Singleton.Config.broadcastLength, Plugin.Singleton.Config.deconDeath343);
                if (scp343.Contains(players))
                    kill343(players);
            }
        }



        public void onRoundEnd(RoundEndedEventArgs ev)
        {
                scp343.Clear();
        }

        public void onDeath(DiedEventArgs ev)
        {
            if (scp343.Contains(ev.Target))
                kill343(ev.Target);
        }



        public void kill343(Player p)
        {
            if (scp343.Contains(p))
                scp343.Remove(p);

            if (Plugin.Singleton.Config.isInvincible)
                p.IsGodModeEnabled = false;

            if (Plugin.Singleton.Config.hasBypass)
                p.IsBypassModeEnabled = false;

            p.CustomPlayerInfo = null;
        }
    }
}

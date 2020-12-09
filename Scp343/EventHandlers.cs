namespace Scp343
{
    using Components;
    using Exiled.Events.EventArgs;
    using System;

    public class EventHandlers
    {
        private readonly Random _random = new Random();

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleType.ClassD && _random.Next(101) < Scp343.Singleton.Config.SpawnChance &&
                Scp343.Singleton.Config.MaxScp343s > Scp343.Singleton.Scp343s.Count)
                ev.Player.GameObject.AddComponent<Scp343Component>();
        }
    }
}
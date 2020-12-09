namespace Scp343
{
    using Exiled.API.Features;
    using System;
    using System.Collections.Generic;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    public class Scp343 : Plugin<Config>
    {
        internal static Scp343 Singleton;
        private EventHandlers _eventHandlers;
        public readonly List<Player> Scp343s = new List<Player>();

        public override void OnEnabled()
        {
            Singleton = this;
            _eventHandlers = new EventHandlers();
            PlayerEvents.ChangingRole += _eventHandlers.OnChangingRole;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerEvents.ChangingRole -= _eventHandlers.OnChangingRole;
            _eventHandlers = null;
            base.OnDisabled();
        }

        public override string Author => "TheVoidNebula";
        public override string Name => "Scp343";
        public override Version Version => new Version(1, 0, 0);
    }
}
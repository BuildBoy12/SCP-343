namespace Scp343.Components
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using UnityEngine;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    public class Scp343Component : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            RegisterEvents();
            _player = Player.Get(gameObject);
            Scp343.Singleton.Scp343s.Add(_player);
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            _player.Role = RoleType.ClassD;
            _player.Broadcast(Scp343.Singleton.Config.SpawnBroadcast.Duration,
                Scp343.Singleton.Config.SpawnBroadcast.Content);
            if (Scp343.Singleton.Config.HasBypass)
                _player.IsBypassModeEnabled = true;
            Timing.CallDelayed(0.2f, () =>
                _player.ResetInventory(Scp343.Singleton.Config.Scp343Inventory));
        }

        private void Update()
        {
            if (_player == null || _player.Role != RoleType.ClassD)
                Destroy();
        }

        public void Destroy()
        {
            Scp343.Singleton.Scp343s.Remove(_player);
            UnregisterEvents();
            if (_player != null && Scp343.Singleton.Config.HasBypass)
                _player.IsBypassModeEnabled = false;

            Destroy(this);
        }

        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            if (ev.Player == _player && !Scp343.Singleton.Config.CanDrop)
                ev.IsAllowed = false;
        }

        public void OnHandcuffing(HandcuffingEventArgs ev)
        {
            if (ev.Target != _player)
                return;

            ev.IsAllowed = false;
            ev.Cuffer.Broadcast(3, "You cannot cuff <color=red>SCP-343</color>");
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Target != _player || !Scp343.Singleton.Config.IsInvincible)
                return;

            if (ev.DamageType != DamageTypes.Decont ||
                ev.DamageType != DamageTypes.Nuke)
                ev.IsAllowed = false;
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Player == _player && !Scp343.Singleton.Config.CanGrab)
                ev.IsAllowed = false;
        }

        private void RegisterEvents()
        {
            PlayerEvents.DroppingItem += OnDroppingItem;
            PlayerEvents.Handcuffing += OnHandcuffing;
            PlayerEvents.Hurting += OnHurting;
            PlayerEvents.PickingUpItem += OnPickingUpItem;
        }

        private void UnregisterEvents()
        {
            PlayerEvents.DroppingItem -= OnDroppingItem;
            PlayerEvents.Handcuffing -= OnHandcuffing;
            PlayerEvents.Hurting -= OnHurting;
            PlayerEvents.PickingUpItem -= OnPickingUpItem;
        }
    }
}
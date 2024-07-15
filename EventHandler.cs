namespace GeneratorLockPlugin
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Exiled.Events.EventArgs.Item;
    using Exiled.Events.EventArgs.Player;
    using MEC;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        private bool isLocked;

        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStarted()
        {
            isLocked = true;
            Timing.CallDelayed(plugin.Config.LockDuration, () => isLocked = false);
        }

        public void OnInteractingGenerator(UnlockingGeneratorEventArgs ev)
        {
            if (isLocked)
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint(plugin.Translation.GeneratorLockedHint);
            }
        }
    }
}

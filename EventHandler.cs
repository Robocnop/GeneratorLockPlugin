namespace GeneratorLockPlugin
{
    using System;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using System.Collections.Generic;
    using Exiled.Events.EventArgs.Player;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        private bool isLocked;
        private int initialSeed;
        private DateTime roundStartTime;
        private CoroutineHandle lockCoroutine;

        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStarted()
        {
            isLocked = true;
            initialSeed = Map.Seed;
            roundStartTime = DateTime.Now;
            lockCoroutine = Timing.RunCoroutine(UnlockGeneratorsAfterDelay());
        }

        private IEnumerator<float> UnlockGeneratorsAfterDelay()
        {
            for (int remainingTime = plugin.Config.LockDuration; remainingTime > 0; remainingTime--)
            {
                if (Map.Seed != initialSeed)
                {
                    Log.Info("The server restarted before the generators unlocked. The countdown has been reset for the next game.");
                    yield break;
                }

                yield return Timing.WaitForSeconds(1f);
            }

            isLocked = false;
        }

        public void OnInteractingGenerator(UnlockingGeneratorEventArgs ev)
        {
            if (isLocked)
            {
                ev.IsAllowed = false;
                int elapsedTime = (int)(DateTime.Now - roundStartTime).TotalSeconds;
                int remainingTime = plugin.Config.LockDuration - elapsedTime;
                ev.Player.ShowHint(string.Format(plugin.Translation.GeneratorLockedTimeHint, remainingTime), 5);
            }
        }
    }
}

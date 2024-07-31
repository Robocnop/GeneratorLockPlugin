// File path: GeneratorLockPlugin/Plugin.cs
namespace GeneratorLockPlugin
{
    using Exiled.API.Features;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;
    using System;

    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "GeneratorLockPlugin";
        public override string Author => "Robocnop";
        public override Version Version => new Version(1, 0, 2);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(this);
            ServerEvents.RoundStarted += EventHandlers.OnRoundStarted;
            PlayerEvents.UnlockingGenerator += EventHandlers.OnInteractingGenerator;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvents.RoundStarted -= EventHandlers.OnRoundStarted;
            PlayerEvents.UnlockingGenerator -= EventHandlers.OnInteractingGenerator;
            EventHandlers = null;

            base.OnDisabled();
        }
    }
}

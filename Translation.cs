namespace GeneratorLockPlugin
{
    using Exiled.API.Interfaces;

    public class Translation : ITranslation
    {
        public string GeneratorLockedHint { get; set; } = "You can't open this now.";
    }
}

namespace GeneratorLockPlugin
{
    using Exiled.API.Interfaces;

    public class Translation : ITranslation
    {
        public string GeneratorLockedTimeHint { get; set; } = "You can't open this now. The generator will unlock in {0} seconds.";
    }
}

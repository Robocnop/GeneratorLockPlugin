namespace GeneratorLockPlugin
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        [Description("Whether the plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Duration in seconds for which the generators are locked at the start of the game.")]
        public int LockDuration { get; set; } = 180;

        [Description("Debug mode.")]
        public bool Debug { get; set; } = false;
    }
}

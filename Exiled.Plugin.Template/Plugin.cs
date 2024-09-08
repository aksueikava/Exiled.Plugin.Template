using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace Exiled.Plugin.Template
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Exiled.Plugin.Template";
        public override string Prefix => "Exiled.Plugin.Template";
        public override string Author => "aksueikava";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public static Plugin Instance;
        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();

            Log.Debug("Exiled.Plugin.Template has been enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            UnregisterEvents();

            Log.Debug("Exiled.Plugin.Template has been disabled.");
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();
        }

        private void UnregisterEvents()
        {
            _handlers = null;
        }
    }
}
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;

namespace Exiled.Plugin.Template.Patches
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Exiled.Plugin.Template.Patches";
        public override string Prefix => "Exiled.Plugin.Template.Patches";
        public override string Author => "aksueikava";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Default;

        private Harmony _harmony = new Harmony("Exiled.Plugin.Template.Patches");
        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            _harmony.PatchAll();

            Log.Debug($"{base.Name} has been enabled.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            _harmony.UnpatchAll();

            Log.Debug($"{base.Name} has been disabled.");
            base.OnDisabled();
        }
    }
}
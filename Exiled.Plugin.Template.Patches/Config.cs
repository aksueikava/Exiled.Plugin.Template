using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Exiled.Plugin.Template.Patches
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Are debug messages displayed?")]
        public bool Debug { get; set; } = false;

        [Description("Should command execution logs be sent?")]
        public bool LogCommands { get; set; } = true;
    }
}
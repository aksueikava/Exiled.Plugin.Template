using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Exiled.Plugin.Template
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Are debug messages displayed?")]
        public bool Debug { get; set; } = false;
    }
}
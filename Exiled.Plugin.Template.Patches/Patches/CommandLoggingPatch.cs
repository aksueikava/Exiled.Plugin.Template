using static HarmonyLib.AccessTools;
using System.Collections.Generic;
using System.Reflection.Emit;
using Exiled.API.Features;
using NorthwoodLib.Pools;
using HarmonyLib;
using RemoteAdmin;

namespace Exiled.Plugin.Template.Patches
{
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal class CommandLoggingPatch
    {
        private static Config Config => Plugin.Instance.Config;

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            newInstructions.InsertRange(0, new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Call, Method(typeof(CommandLoggingPatch), nameof(LogCommand))),
            });

            foreach (var instruction in newInstructions)
                yield return instruction;

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }

        static void LogCommand(string query, CommandSender sender)
        {
            if (sender == null || !Config.LogCommands) return;

            if (IsRaPanelCommand(query)) return;

            if (sender.SenderId != "SERVER CONSOLE" && !query.Contains("REQUEST_DATA"))
            {
                var player = Player.Get(sender as PlayerCommandSender);
                var groupName = player?.GroupName ?? "Unknown";

                var formattedQuery = FormatQuery(query);
                Log.Info($"Administrator {sender.Nickname} ({sender.SenderId} - {groupName}) executed command: {formattedQuery}.");
            }
        }

        static bool IsRaPanelCommand(string query)
        {
            return query.Contains("$7") || query.Contains("$0");
        }

        static string FormatQuery(string query)
        {
            return query;
        }
    }
}
using BepInEx;
using BepInEx.IL2CPP;
using BulwarkStudios.Stanford.Common.GameStates;
using HarmonyLib;

namespace IXION.NoPauseOnFocusLoss
{
    // BepInEx is a plugin framework for Unity games, and this attribute tells it to load this plugin
    [BepInPlugin("org.bepinex.plugins.IXION.PauseGameOption", "IXION.PauseGameOption", "1.0.0.0")]
    public class Plugin : BasePlugin
    {
        // Harmony is a library for modifying the behavior of existing code through "patches"
        private static Harmony harmony = new Harmony("IXION.PauseGameOption");

        // This method is called when the plugin is loaded
        public override void Load()
        {
            // Log a message to the console indicating that the plugin has been loaded
            Log.LogInfo($"PLugin {PluginInfo.PLUGIN_GUID} is Loaded");

            // Apply all patches created with Harmony in this plugin
            harmony.PatchAll();
        }

        // This class is a Harmony patch that modifies the behavior of the OnApplicationFocus method in the GameViewCommon class
        [HarmonyPatch(typeof(GameViewCommon), nameof(GameViewCommon.OnApplicationFocus))]
        private class OnApplicationFocus
        {
            // This method is called before the original OnApplicationFocus method is executed
            private static void Prefix(GameViewCommon __instance, ref bool __0)
            {
                // Set the value of the parameter __0 to false, effectively preventing the game from pausing when the application loses focus
                __0 = false;
            }
        }
    }
}

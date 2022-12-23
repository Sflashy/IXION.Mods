using BepInEx;
using BepInEx.IL2CPP;
using BulwarkStudios.Stanford.Common.GameStates;
using HarmonyLib;
using Stanford.Settings;
using UnityEngine;

namespace IXION.PauseGameOption;

[BepInPlugin("org.bepinex.plugins.IXION.PauseGameOption", "IXION.PauseGameOption", "1.0.0.0")]
public class Plugin : BasePlugin
{
    private static Harmony harmony = new Harmony("IXION.PauseGameOption");
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private static BepInEx.Logging.ManualLogSource Log;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public override void Load()
    {
        Log = base.Log;
        Log.LogInfo($"PLugin {PluginInfo.PLUGIN_GUID} is Loaded");
        harmony.PatchAll();
        InitializeMain();
    }

    private void InitializeMain()
    {
    }

    #region Patches

    [HarmonyPatch(typeof(Stanford.Settings.GameSettingsManager), nameof(Stanford.Settings.GameSettingsManager.Awake))]
    private class GameSettingsManager
    {
        private static void Postfix(Stanford.Settings.GameSettingsManager __instance)
        {
            Log.LogInfo("GameSettingsManager Initialized");
            var gameSettingData = new PauseGameOption();
            //gameSettingData.data.
            //gameSettingData.CreateState();
            //gameSettingData.applyBehaviour = GameSettingData.APPLY_BEHAVIOUR.EVERY_TIME;
            //gameSettingData.descriptionId = "Patch_2/AccessibilityMisophoniaDescription";
            //gameSettingData.displayNameId = "Settings/Misophonia";
            //gameSettingData.mainCategory = new GameSettingCategory();
            //gameSettingData.mainCategory.displayNameId = "Settings/Accessibility";
            //gameSettingData.mainCategory.name = "AccessibilitySettingCategory";
            //__instance.data.datas.Add(gameSettingData.data);
        }
    }

    [HarmonyPatch(typeof(GameViewCommon), nameof(GameViewCommon.OnApplicationFocus))]
    private class OnApplicationFocus
    {
        private static void Prefix(GameViewCommon __instance, ref bool __0)
        {
            __0 = false;
        }
    }

    #endregion Patches
}
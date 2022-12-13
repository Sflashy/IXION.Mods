using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BulwarkStudios.Stanford.Common.GameStates;
using UnityEngine;
using UnityEngine.UI;
using UnhollowerRuntimeLib;

namespace IXION.PauseGameOption;

[BepInPlugin("org.bepinex.plugins.IXION.PauseGameOption", "IXION.PauseGameOption", "1.0.0.0")]
public class Plugin : BasePlugin
{
    private static bool bPause;
    private Harmony harmony = new Harmony("IXION.PauseGameOption");

    public override void Load()
    {
        harmony.PatchAll();
        InitializeMain();
    }

    private void InitializeMain()
    {
        ClassInjector.RegisterTypeInIl2Cpp<Main>();
        GameObject main = new("Main");
        Object.DontDestroyOnLoad(main);
        main.hideFlags = HideFlags.HideAndDontSave;
        main.AddComponent<Main>();
    }

    #region Patches

    [HarmonyPatch(typeof(GameViewCommon), nameof(GameViewCommon.OnApplicationFocus))]
    private class OnApplicationFocus
    {
        private static void Prefix(GameViewCommon __instance, ref bool __0)
        {
            __0 = bPause;
        }
    }

    #endregion Patches
}
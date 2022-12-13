using BepInEx;
using BepInEx.IL2CPP;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace IXION.CreativeMode;

[BepInPlugin("org.bepinex.plugins.IXION.CreativeMod", "IXION.CreativeMod", "1.0.0.0")]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        ClassInjector.RegisterTypeInIl2Cpp<Main>();
        GameObject main = new("Main");
        Object.DontDestroyOnLoad(main);
        main.hideFlags = HideFlags.HideAndDontSave;
        main.AddComponent<Main>();
    }
}
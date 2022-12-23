using BepInEx;
using BepInEx.IL2CPP;
using Mono.Cecil.Cil;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using Object = UnityEngine.Object;

namespace IXION.CreativeMode
{
    // Declares the plugin and specifies its name, GUID, and version
    [BepInPlugin("org.bepinex.plugins.IXION.CreativeMod", "IXION.CreativeMod", "1.0.0.0")]
    public class BepInExLoader : BasePlugin
    {
        // Declares a static log source that can be used throughout the plugin
        public static BepInEx.Logging.ManualLogSource log;

        public BepInExLoader()
        {
            // Registers an event handler for unhandled exceptions
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;

            // Allows the application to run in the background
            Application.runInBackground = true;

            // Assigns the log source to the instance variable
            log = Log;
        }

        // Event handler for unhandled exceptions
        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs e) => log.LogError("\r\n\r\nUnhandled Exception:" + (e.ExceptionObject as Exception).ToString());

        public override void Load()
        {
            // Logs a message indicating that C# types are being registered in IL2CPP
            log.LogMessage("Registering C# Type's in Il2Cpp");

            // Registers the Main class in the IL2CPP environment
            ClassInjector.RegisterTypeInIl2Cpp<Main>();

            // Creates a new GameObject and adds the Main component to it
            GameObject main = new("Main");
            Object.DontDestroyOnLoad(main);

            // Hides the GameObject and prevents it from being saved
            main.hideFlags = HideFlags.HideAndDontSave;
            main.AddComponent<Main>();
        }
    }
}

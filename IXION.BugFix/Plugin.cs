using BepInEx;
using BepInEx.IL2CPP;
using UnityEngine;
using BulwarkStudios.Stanford.Configs;
using BulwarkStudios.Stanford.Saves;
using UnhollowerRuntimeLib;
using System;

namespace IXION.MissingReferencesFinder
{
    // Declares the plugin and specifies its name, GUID, and version
    [BepInPlugin("org.bepinex.plugins.IXION.MissingReferencesFinder", "IXION.MissingReferencesFinder", "1.0.0.0")]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            // Logs that the plugin has been loaded
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            // Registers the MissingReferencesFinder class in the IL2CPP environment
            ClassInjector.RegisterTypeInIl2Cpp<MissingReferencesFinder>();

            // Creates a new GameObject and adds the MissingReferencesFinder component to it
            GameObject missingReferenceFinder = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(missingReferenceFinder);

            // Hides the GameObject and prevents it from being saved
            missingReferenceFinder.hideFlags = HideFlags.HideAndDontSave;
            missingReferenceFinder.AddComponent<MissingReferencesFinder>();
        }
    }

    public class MissingReferencesFinder : MonoBehaviour
    {
        public MissingReferencesFinder(IntPtr handle) : base(handle)
        {
        }

        private void Update()
        {
            try
            {
                // Gets the list of reference objects and the asset database from the SaveDataBaseObject instance
                var refObjects = SaveDataBaseObject.Instance.refObjects;
                var assetDataBase = SaveDataBaseObject.Instance.assetDataBase;
                var assetDataBaseReversed = SaveDataBaseObject.Instance.assetDataBaseReversed;

                // Iterates through each reference object
                foreach (SaveDataBaseObject.RefObject refObject in refObjects)
                {
                    // If the reference object is null, log an error message
                    if (refObject.refObj == null)
                    {
                        Log.Error("SaveDataBaseObject refObject null: " + refObject.path, LogConfigStanford.TAG.DEFAULT);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

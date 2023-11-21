using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TinyCompany.Components;
using UnityEngine;

namespace TinyCompany;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    // private Harmony _harmony = new(PluginInfo.PLUGIN_GUID);
    private GameObject _object;
    public static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;

        Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loading...");

        // Log.LogInfo("Loading Harmony patches...");
        // _harmony.PatchAll();
        // Log.LogInfo("Loaded Harmony patches!");

        LC_API.ServerAPI.ModdedServer.SetServerModdedOnly();
    }

    private void OnDestroy()
    {
        Log.LogInfo("Loading Tinyifier script...");
        _object = new GameObject("Tinyifier");
        DontDestroyOnLoad(_object);
        _object.AddComponent<Tinyifier>();
        Log.LogInfo("Loaded Tinyifier script!");

        Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");
    }
}

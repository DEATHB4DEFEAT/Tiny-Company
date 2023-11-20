using BepInEx;
using HarmonyLib;

namespace TinyCompany;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public Harmony Harmony = new(PluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        Harmony.PatchAll();

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
}

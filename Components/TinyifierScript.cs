using GameNetcodeStuff;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyCompany.Components;

public class TinyifierScript : MonoBehaviour
{
    public PlayerControllerB player;

    public void Update()
    {
        // TODO I hate this, use a UI with direct size inputs instead
        if (Keyboard.current.f3Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 0.1x");
            player.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (Keyboard.current.f4Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 0.25x");
            player.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        else if (Keyboard.current.f5Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 0.5x");
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Keyboard.current.f6Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 0.75x");
            player.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        else if (Keyboard.current.f7Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 1x");
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Keyboard.current.f8Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 1.25x");
            player.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        else if (Keyboard.current.f9Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 1.5x");
            player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (Keyboard.current.f10Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 1.75x");
            player.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        }
        else if (Keyboard.current.f11Key.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("Scaling to 2x");
            player.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    public void OnDestroy()
    {
        Plugin.Log.LogInfo("Undoing Scaling");
        player.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}

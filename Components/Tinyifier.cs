using GameNetcodeStuff;
using UnityEngine;

namespace TinyCompany.Components;

public class Tinyifier : MonoBehaviour
{
    public void Update()
    {
        var players = FindObjectsOfType<PlayerControllerB>();

        foreach (var player in players)
        {
            if (player == null ||
                player.gameObject.GetComponentInChildren<TinyifierScript>() != null)
                continue;

            if (!player.IsOwner || !player.isPlayerControlled)
                continue;

            Plugin.Log.LogMessage("Adding TinyifierScript to a player");
            player.gameObject.AddComponent<TinyifierScript>().player = player;
            Plugin.Log.LogMessage("Added TinyifierScript to a player");
        }
    }

    public void OnDestroy()
    {
        var players = FindObjectsOfType<PlayerControllerB>();

        foreach (var player in players)
        {
            var script = player.gameObject.GetComponentInChildren<TinyifierScript>();
            if (script == null)
                continue;

            Plugin.Log.LogMessage("Destroying Tinyifier");
            Destroy(script);
        }
    }
}

using GameNetcodeStuff;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyCompany.Components;

public class TinyifierScript : MonoBehaviour
{
    public PlayerControllerB player;
    public ScaleUIController scaleUIController;


    public void Start()
    {
        scaleUIController = new GameObject("ScaleUIController").AddComponent<ScaleUIController>();
        scaleUIController.player = player;
    }

    public void Update()
    {
        // Open the UI when pressing F4
        if (!ScaleUIController.IsUIActive && Keyboard.current.f4Key.wasPressedThisFrame)
        {
            scaleUIController.ShowUI();
        }

        // Halve the change caused by scaling
        var scaleChange = scaleUIController.ScaleAverage - 1f;
        var adjustedScale = 1f + (scaleChange * 0.5f);

        // Change player speed and jump height based on adjusted scale
        player.movementSpeed = 4.6f * adjustedScale;
        player.climbSpeed = 3f * adjustedScale;
        player.sprintTime = 11f / adjustedScale;
        player.jumpForce = 13f * adjustedScale;
        player.grabDistance = 3f * adjustedScale;
    }
}

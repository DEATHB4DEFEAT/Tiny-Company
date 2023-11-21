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

        // Change player speed and jump height based on scale
        player.movementSpeed = 4.6f * scaleUIController.ScaleAverage;
        // player.drunknessSpeed = 0.4f * scaleUIController.ScaleAverage; // TODO What does this do? I'm leaving this untouched until I figure it out
        player.climbSpeed = 3f * scaleUIController.ScaleAverage;
        player.jumpForce = 13f * scaleUIController.ScaleAverage;
    }
}

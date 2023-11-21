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
        if (!ScaleUIController.IsUIActive && Keyboard.current.f4Key.wasPressedThisFrame)
        {
            scaleUIController.ShowUI();
        }
    }
}

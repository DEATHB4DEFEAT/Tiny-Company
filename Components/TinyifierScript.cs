using System;
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
        if (scaleUIController.IsUIActive())
            return;

        if (Keyboard.current.f4Key.wasPressedThisFrame)
        {
            Plugin.Log.LogWarning("F4 pressed, showing UI...");
            scaleUIController.ShowUI();
        }
    }

    public void OnDestroy()
    {
        Plugin.Log.LogFatal("TinyifierScript.OnDestroy() called!");
    }
}

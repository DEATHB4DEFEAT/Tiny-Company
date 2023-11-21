using GameNetcodeStuff;
using UnityEngine;

namespace TinyCompany.Components;

public class ScaleUIController : MonoBehaviour
{
    public PlayerControllerB player;
    private Vector3 scale = Vector3.one;
    private bool showUI = false;


    public void ShowUI()
    {
        showUI = true;
    }

    public void HideUI()
    {
        showUI = false;
    }

    public bool IsUIActive()
    {
        return showUI;
    }


    public void ApplyScale()
    {
        player.transform.localScale = scale;
    }


    private void Update()
    {
        if (!showUI)
            return;

        if (Event.current.isKey && Event.current.keyCode == KeyCode.Tab)
        {
            GUI.FocusControl(null);
        }
        else if (Event.current.isKey && (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter))
        {
            ApplyScale();
            HideUI();
        }
    }

    private void OnGUI()
    {
        if (!showUI)
            return;

        float width = 600;
        float height = 300;
        float left = (Screen.width - width) / 2;
        float top = (Screen.height - height) / 2;
        GUILayout.BeginArea(new Rect(left, top, width, height));
        GUILayout.BeginVertical();
        scale.x = float.Parse(GUILayout.TextField(scale.x.ToString(), GUILayout.Height(50)));
        scale.y = float.Parse(GUILayout.TextField(scale.y.ToString(), GUILayout.Height(50)));
        scale.z = float.Parse(GUILayout.TextField(scale.z.ToString(), GUILayout.Height(50)));
        if (GUILayout.Button("Apply", GUILayout.Height(50)))
        {
            ApplyScale();
            HideUI();
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}

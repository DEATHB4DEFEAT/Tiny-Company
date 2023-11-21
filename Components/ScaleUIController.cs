using System.Globalization;
using GameNetcodeStuff;
using UnityEngine;

namespace TinyCompany.Components;

public class ScaleUIController : MonoBehaviour
{
    public PlayerControllerB player;
    private Vector3 _scale = Vector3.one;
    private bool _showUI;
    public static bool IsUIActive { get; private set; }
    private const int UIWidth = 600;
    private const int UIHeight = 333;


    /// <summary>
    ///     Opens the <see cref="OnGUI"/>
    /// </summary>
    public void ShowUI()
    {
        Plugin.Log.LogInfo("Showing Tinyifier UI");
        _showUI = true;
        IsUIActive = true;
    }

    /// <summary>
    ///     Closes the <see cref="OnGUI"/>
    /// </summary>
    public void HideUI()
    {
        Plugin.Log.LogInfo("Hiding Tinyifier UI");
        _showUI = false;
        IsUIActive = false;
    }


    /// <summary>
    ///     Changes the size of the player
    /// </summary>
    public void ApplyScale()
    {
        if (_scale.x == 0 || _scale.y == 0 || _scale.z == 0)
        {
            Plugin.Log.LogWarning($"Player tried to set their scale to {_scale}, which is invalid. Setting to {Vector3.one} instead.");
            _scale = Vector3.one;
        }

        Plugin.Log.LogInfo($"Applying scale {_scale}.");
        player.transform.localScale = _scale;
    }


    private void Update()
    {
        if (!_showUI)
            return;

        // Switch between text fields when pressing tab
        if (Event.current.isKey && Event.current.keyCode == KeyCode.Tab)
        {
            GUI.FocusControl(null);
        }
        // Apply scale and close the UI when pressing enter
        else if (Event.current.isKey && (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter))
        {
            ApplyScale();
            HideUI();
        }
    }


    private void OnGUI()
    {
        if (!_showUI)
            return;

        // Center the UI
        var left = (Screen.width - UIWidth) / 2;
        var top = (Screen.height - UIHeight) / 2;
        var margin = 15;
        var innerMargin = 10;

        // Background box
        GUI.skin.box.normal.background = MakeTexture(2, 2, new Color(0.1f, 0.1f, 0.1f, 0.75f));
        GUI.Box(new Rect(left - margin, top - margin, UIWidth + 2 * margin, UIHeight + 2 * margin), "");
        GUI.skin.box.normal.background = MakeTexture(2, 2, new Color(0.35f, 0.35f, 0.35f, 0.75f));
        GUI.Box(new Rect(left, top, UIWidth + 2, UIHeight + 2), "");

        GUILayout.BeginArea(new Rect(left + innerMargin, top + innerMargin, UIWidth - 2 * innerMargin, UIHeight - 2 * innerMargin));
        GUILayout.BeginVertical();

        // Title text
        GUILayout.BeginHorizontal();
        GUI.skin.label.fontSize = 44;
        GUILayout.Label("Tiny Company", GUILayout.Height(58));
        GUILayout.EndHorizontal();

        // Description text
        GUILayout.BeginHorizontal();
        GUI.skin.label.fontSize = 30;
        GUILayout.Label("Press TAB to cycle between the text fields and press ENTER or click \"Apply\" to confirm size");
        GUILayout.EndHorizontal();

        // Scale inputs
        GUI.skin.label.fontSize = 38;
        GUI.skin.textField.fontSize = 38;
        GUILayout.BeginHorizontal();
        GUILayout.Label("X", GUILayout.Width(30));
        _scale.x = ParseInput(GUILayout.TextField(GetDisplayString(_scale.x), GUILayout.Height(50)));
        GUILayout.Label("Y", GUILayout.Width(30));
        _scale.y = ParseInput(GUILayout.TextField(GetDisplayString(_scale.y), GUILayout.Height(50)));
        GUILayout.Label("Z", GUILayout.Width(30));
        _scale.z = ParseInput(GUILayout.TextField(GetDisplayString(_scale.z), GUILayout.Height(50)));
        GUILayout.EndHorizontal();

        // Apply button
        GUI.skin.button.fontSize = 40;
        if (GUILayout.Button("Apply Scaling", GUILayout.Height(50)))
        {
            ApplyScale();
            HideUI();
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private string GetDisplayString(float value)
    {
        return value % 1 == 0 ? $"{value}.0" : value.ToString();
    }

    private float ParseInput(string input)
    {
        input = SanitizeInput(input);
        float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var result);
        return result;
    }

    private string SanitizeInput(string input)
    {
        var index = input.IndexOf('.');
        if (index == -1)
            return input;

        return input.Substring(0, index + 1) + input.Substring(index + 1).Replace(".", "");
    }

    /// <summary>
    ///     Creates a texture of the specified size and color
    /// </summary>
    private Texture2D MakeTexture(int width, int height, Color color)
    {
        var pix = new Color[width * height];
        for (var i = 0; i < pix.Length; i++)
            pix[i] = color;

        var result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }
}

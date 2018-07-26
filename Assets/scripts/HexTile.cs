using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    static HexTile selectedTile;

    static readonly Color[] COLOR_OPTIONS = new Color[] { Color.green, Color.blue, Color.red, Color.yellow };
    static readonly int MAX_COLOR_INDEX = COLOR_OPTIONS.Length;

    Color currentColor = Color.green;

    void OnEnable()
    {
        GameController.Active.GameModeChangedEvent += OnGameModeChanged;
    }

    void OnMouseOver()
    {
        if (GameController.Active.CurrentMode == GameMode.MAP_EDIT) {
            if (Input.GetMouseButtonDown(0)) {
                if (selectedTile == this) {
                    var currentColorIndex = Array.IndexOf(COLOR_OPTIONS, currentColor);
                    var newColorIndex = (currentColorIndex + 1) % COLOR_OPTIONS.Length;
                    var newColor = COLOR_OPTIONS[newColorIndex];
                    SetColor(3, newColor);
                    currentColor = newColor;
                } else {
                    if (selectedTile) { selectedTile.UnHighlight(); }
                    SetColor(2, Color.yellow);
                    selectedTile = this;
                }
            }
        }
    }

    // TODO: This currently fires once per HexTile; it need fire only once.
    void OnGameModeChanged(GameModeChangedEventArgs e)
    {
        if (selectedTile) {
            selectedTile.UnHighlight();
            selectedTile = null;
        }
    }

    void UnHighlight()
    {
        SetColor(2, Color.black);
    }

    void SetColor(int index, Color color)
    {
        var materials = GetComponent<MeshRenderer>().materials;
        var newMat = new Material(Shader.Find("Specular")) { color = color };
        materials[index] = newMat;
        GetComponent<MeshRenderer>().materials = materials;
    }
}

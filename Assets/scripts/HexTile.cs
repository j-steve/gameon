using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    static HexTile selectedTile;



    void OnEnable()
    {
        GameController.Active.GameModeChangedEvent += OnGameModeChanged;
    }

    void OnMouseOver()
    {
        if (GameController.Active.CurrentMode == GameMode.MAP_EDIT) {
            if (Input.GetMouseButtonDown(0)) {
                if (selectedTile) { selectedTile.UnHighlight(); }
                Highlight(Color.yellow);
                selectedTile = this;
            }
        }
    }

    // TODO: This currently fires once per HexTile; it need fire only once.
    void OnGameModeChanged(GameModeChangedEventArgs e)
    {
        if (selectedTile) {
            selectedTile.Highlight(Color.black);
            selectedTile = null;
        }
    }

    void UnHighlight()
    {
        Highlight(Color.black);
    }

    void Highlight(Color color)
    {
        var materials = GetComponent<MeshRenderer>().materials;
        var newMat = new Material(Shader.Find("Specular")) { color = color };
        materials[2] = newMat;
        GetComponent<MeshRenderer>().materials = materials;
    }
}

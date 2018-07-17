using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    static HexTile selectedTile;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (selectedTile) { selectedTile.Highlight(Color.black); }
            Highlight(Color.yellow);
            selectedTile = this;
        }
    }

    void Highlight(Color color)
    {
        var materials = GetComponent<MeshRenderer>().materials;
        var newMat = new Material(Shader.Find("Specular")) { color = color };
        materials[2] = newMat;
        GetComponent<MeshRenderer>().materials = materials;
    }
}

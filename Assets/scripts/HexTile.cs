using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
    public Texture highlight;

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
            Debug.LogFormat("Clicked {0}", transform.parent.name);
            var materials = GetComponent<MeshRenderer>().materials;
            var newMat = new Material(Shader.Find("Specular"));
            newMat.color = Color.yellow;
            materials[2] = newMat;
            GetComponent<MeshRenderer>().materials = materials;
            //var shaders = transform.parent.GetComponentsInChildren<Shader>();
            //Debug.LogFormat("{0}", r.materials.Length);
        }
    }
}

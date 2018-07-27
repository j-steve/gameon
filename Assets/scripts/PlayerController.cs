using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    void OnEnable()
    {
        foreach (HexTile tile in FindObjectsOfType(typeof(HexTile))) {
            if (tile.Character == null) {
                PositionOnTile(tile);
                return;
            }
        }
    }

    void PositionOnTile(HexTile tile)
    {
        transform.position = new Vector3(
            tile.transform.position.x,
            tile.transform.position.y + HexTile.HEIGHT,
            tile.transform.position.z);
        tile.Character = gameObject;
    }

    void Update()
    {
        if (!isLocalPlayer) {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
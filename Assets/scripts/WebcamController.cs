using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class WebcamController : NetworkBehaviour
{
    private RawImage rawImage;
    private WebCamTexture rawWebcamFeed;
    private Texture2D webcamTexture2d;
    private float timeBack;

    // Use this for initialization
    void Start()
    {
        rawImage = GetComponentInParent<RawImage>();
        if (NetworkServer.active) {
            rawWebcamFeed = new WebCamTexture {
                requestedFPS = 10,
                requestedWidth = 160,
                requestedHeight = 90
            };
            rawWebcamFeed.Play();
            webcamTexture2d = new Texture2D(
                rawWebcamFeed.width, rawWebcamFeed.height,
                TextureFormat.RGB24, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkServer.active) { // Is Server
            if (rawWebcamFeed != null && Time.time > timeBack + 0.1f) {
                webcamTexture2d.SetPixels(rawWebcamFeed.GetPixels());
                webcamTexture2d.Apply();
                CmdVideoTextureUpdate(webcamTexture2d.EncodeToPNG());
                timeBack = Time.time;
            }
        } else { // Is Client
        }
    }

    [Command]
    void CmdVideoTextureUpdate(byte[] data)
    {
        RpcUpdateVideoTexture(data);
    }

    [ClientRpc]
    void RpcUpdateVideoTexture(byte[] data)
    {
        var destTexture = new Texture2D(64, 48, TextureFormat.RGB24, false);
        destTexture.LoadImage(data);
        destTexture.Apply();
        rawImage.texture = destTexture;

    }
}
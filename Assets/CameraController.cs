using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private ARCameraBackground arCameraBackground;
    [SerializeField] private RawImage previewImage;
    [SerializeField] private int maxSize = 512;

    private Texture2D _lastCameraTexture;
    
    public void TakeNormalPic()
    {
        if(NativeCamera.IsCameraBusy()) return;
        
        NativeCamera.Permission permission = NativeCamera.TakePicture( ( path ) =>
        {
            Debug.Log( "Image path: " + path );
            if( path != null )
            {
                // Create a Texture2D from the captured image
                previewImage.texture = NativeCamera.LoadImageAtPath( path, maxSize );
            }
        }, maxSize );

        Debug.Log( "Permission result: " + permission );
    }

    public void TakeARPic()
    {
        previewImage.texture = CameraCapturer.Capture(arCamera);

    }
}

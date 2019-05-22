using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Common;
using System.IO;

namespace Assets.Scripts.Scenes.VideoCaptureScene
{

    public class WebCamController : MonoBehaviour
    {
        /// <summary>
        /// カメラから取得したテクスチャを保持する
        /// </summary>
        private WebCamTexture WebCamTexture;

        /// <summary>
        /// カメラからの画像を表示するテクスチャ
        /// </summary>
        private RawImage RawImage;

        void Start()
        {
            WebCamTexture = SingletonWebCamManager.Instance.Factory(Screen.width, Screen.height, 60);
            RawImage = GetComponent<RawImage>();
            RawImage.texture = WebCamTexture;
            //WebCamTexture.Play();
        }

        private void Update()
        {
            //if (WebCamTexture.isPlaying && Input.GetKey(KeyCode.Space))
            //{
            //    try
            //    {
            //        SingletonWebCamManager.Instance.CaptureWebCam(CameraDefines.MY_FACE_PHOTO_PATH);
            //        Debug.Log("Photo saved");
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.Log($"Error: {e}");
            //    }
            //}
            if (Input.GetMouseButtonDown(0))
            {
                if (NativeCamera.IsCameraBusy())
                {
                    return;
                }
                Record();
            }
        }

        private void Record()
        {
            NativeCamera.Permission permission = NativeCamera.RecordVideo((path) => {
                Debug.Log($"path: {path}");
                if (path != null)
                {
                    Handheld.PlayFullScreenMovie(path);
                }
            });
            Debug.Log($"Permission: {permission}");
        }
    }
}
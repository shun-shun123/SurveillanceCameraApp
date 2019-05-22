using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System;
namespace Assets.Scripts.Common
{
    public class SingletonWebCamManager
    {
        private static SingletonWebCamManager instance = new SingletonWebCamManager();

        /// <summary>
        /// SingletonWebCamManagerのコンストラクタ
        /// </summary>
        private SingletonWebCamManager()
        {
            Debug.Log("SingletonWebCamManager has created");
        }

        /// <summary>
        /// Singletonのインスタンスにアクセスする
        /// </summary>
        /// <value>The instance.</value>
        public static SingletonWebCamManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonWebCamManager();
                    return instance;
                }
                return instance;
            }
        }

        /// <summary>
        /// Directoryの存在を確認しているかどうかのキャッシュデータ
        /// </summary>
        bool hasDirectoryExistChecked;

        /// <summary>
        /// 全体でWebCamTextureを複数生成しないようにするためにこの一つで管理する。
        /// </summary>
        private WebCamTexture WebCamTexture;

        /// <summary>
        /// 設定に従ったWebCamTextureを返す
        /// 幅x高さ、FPSを設定する。
        /// </summary>
        /// <returns>The factory.</returns>
        /// <param name="width">Width</param>
        /// <param name="height">Height.</param>
        /// <param name="fps">Fps.</param>
        public WebCamTexture Factory(int width, int height, int fps)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            WebCamTexture = new WebCamTexture(devices[0].name, width, height, fps);
            return WebCamTexture;
        }

        public void CaptureWebCam(string path)
        {
            Texture2D tex2D = TextureConverter.ConvertTextureToTexture2D(WebCamTexture);
            byte[] png = tex2D.EncodeToPNG();
            if (!hasDirectoryExistChecked && Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                hasDirectoryExistChecked = true;
            }
            File.WriteAllBytes($"{CameraDefines.MY_FACE_PHOTO_PATH}-sample{DateTime.Now.Second}-{DateTime.Now.Millisecond}.png", png);
        }
    }
}
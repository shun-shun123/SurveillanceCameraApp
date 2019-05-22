public static class CameraDefines 
{
    /// <summary>
    /// 自分の画像を撮影し、保存するディレクトリのパス
    /// </summary>
    public static readonly string MY_FACE_PHOTO_PATH = "Photos/MyFace/";

    /// <summary>
    /// 写真を保存する際に用いるステータス
    /// </summary>
    public enum SAVE_PHOTO_STATUS {
        MY_FACE,
        OTHER
    };
}

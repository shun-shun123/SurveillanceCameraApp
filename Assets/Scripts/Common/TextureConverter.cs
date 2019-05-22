using UnityEngine;

namespace Assets.Scripts.Common
{
    public static class TextureConverter
    {

        /// <summary>
        /// TextureをTexture2Dに変換する静的メソッド
        /// [使い方]
        /// 引数に変換したいTextureを与えると、変換されたTexture2Dが返ってくる
        /// </summary>
        /// <returns>The texture to texture2 d.</returns>
        /// <param name="self">Self.</param>
        public static Texture2D ConvertTextureToTexture2D(Texture self)
        {
            int sw = self.width;
            int sh = self.height;
            var format = TextureFormat.RGBA32;
            Texture2D result = new Texture2D(sw, sh, format, false);
            RenderTexture currentRt = RenderTexture.active;
            RenderTexture rt = new RenderTexture(sw, sh, 24);
            // 作成したrtにTextureを書き込む
            Graphics.Blit(self, rt);
            RenderTexture.active = rt;
            Rect source = new Rect(0, 0, rt.width, rt.height);
            result.ReadPixels(source, 0, 0);
            result.Apply();
            RenderTexture.active = currentRt;
            return result;
        }
    }
}
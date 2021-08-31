using UnityEngine;

namespace HassakuLab.Utils.Vectors
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// ベクトルのx要素を変更した新しいベクトルを取得する
        /// </summary>
        /// <param name="v">元のベクトル</param>
        /// <param name="x">新しいx要素の値</param>
        /// <returns></returns>
        public static Vector2 WithX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }
        
        /// <summary>
        /// ベクトルのy要素を変更した新しいベクトルを取得する
        /// </summary>
        /// <param name="v">元のベクトル</param>
        /// <param name="y">新しいy要素の値</param>
        /// <returns></returns>
        public static Vector2 WithY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }
    }
}
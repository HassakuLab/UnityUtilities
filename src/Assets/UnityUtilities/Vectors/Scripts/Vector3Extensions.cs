using UnityEngine;

namespace HassakuLab.Utils.Vectors
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Vector3をVector2に変換する
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
    }
}

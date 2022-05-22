using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace Utils
{
    public static class Util
    {

        public static bool GetChanceBool(float chanceOfSuccess)
        {
            return Random.Range(0f, 1f) < chanceOfSuccess;
        }
        public static int GetChance(float chanceOfSuccess)
        {
            int successes = 0;
            if (chanceOfSuccess >= 1) successes = Mathf.FloorToInt(chanceOfSuccess);

            if (GetChanceBool(chanceOfSuccess - successes)) successes++;

            return successes;
        }

        public static int GetRandomInt(int minInclusive, int maxInclusive)
        {
            return Random.Range(minInclusive, maxInclusive + 1);
        }
        public static int GetRandomInt(int max)
        {
            return Random.Range(0, max);
        }
        public static float GetRandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }
        public static int GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            int angle = Mathf.RoundToInt(n);

            return angle;
        }



        #region List
        public static T GetRandomValue<T>(this IList<T> list)
        {
            return list[GetRandomInt(list.Count - 1)];
        }
        public static T GetRandomValue<T>(this T[] array)
        {
            return array[GetRandomInt(array.Length - 1)];
        }
        #endregion

        public static Vector2 GetRandomPosition(int xMin, int xMax, int yMin, int yMax)
        {
            return new Vector2(GetRandomFloat(xMin, xMax), GetRandomFloat(yMin, yMax));
        }

        #region Print
        public static string ToDebugString<T>(this T[] array, string delimiter = "\t")
        {
            var s = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                s.Append(array[i]).Append(delimiter);
            }
            return s.ToString();
        }
        public static string ToMatrixString<T>(this T[,] matrix, string delimiter = "\t")
        {
            var s = new StringBuilder();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s.Append(matrix[i, j]).Append(delimiter);
                }

                s.AppendLine();
            }

            return s.ToString();
        }
        #endregion


    }
}
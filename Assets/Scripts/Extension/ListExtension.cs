using System;
using System.Collections.Generic;

namespace FallingBalls.Extension {
    public static class ListExtension {
        public static T RandomItem<T>(this List<T> list) {
            var index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }
    }
}
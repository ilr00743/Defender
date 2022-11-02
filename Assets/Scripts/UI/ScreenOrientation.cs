using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace FallingBalls.UI
{
    public class ScreenOrientation : MonoBehaviour
    {
        private void Start()
        {
#if UNITY_STANDALONE
            UnityEngine.Screen.SetResolution(1080, 1920, true);
#endif
        }
    }
}
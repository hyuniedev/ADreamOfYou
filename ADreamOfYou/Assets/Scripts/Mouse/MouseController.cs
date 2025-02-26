using System;
using Enum;
using Sound;
using UnityEngine;

namespace Mouse
{
    public class MouseController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundController.Instance.PlaySound(ESound.Click_Mouse);
            }
        }
    }
}
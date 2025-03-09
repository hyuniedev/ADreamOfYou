using System;
using Manager;
using Sound;
using UnityEngine;

namespace UI.Settings
{
    public class MusicGroup : GroupChangeValue
    {
        private void Start()
        {
            Value = GameManager.Instance.Volume.Music;
            SetTextUI();
        }

        public override void OnChangeValue(int value)
        {
            if (Value + value is < 0 or > 10) return;
            base.OnChangeValue(value);
            SetTextUI();
            GameManager.Instance.Volume = new Volume(Value,GameManager.Instance.Volume.Sound);
            SoundController.Instance.UpdateVolumeMusic();
        }

        private void SetTextUI()
        {
            textUI.text = "Âm Nhạc: " + Value;
        }
    }
}
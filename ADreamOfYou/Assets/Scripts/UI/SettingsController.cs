using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsController : MonoBehaviour
    {
        private static SettingsController _instance;

        public static SettingsController Instance { get { return _instance; } }

        private int SoundVolume { get; set; }
        private bool IsSoundOn { get; set; }
        private ELanguage Language { get; set; }
        
        //--------------------------------------------------
        [SerializeField] private Slider soundVolumeSlider;
        [SerializeField] private Toggle soundOnToggle;
        [SerializeField] private Dropdown languageDropdown;
        //--------------------------------------------------
        private void Awake()
        {
            _instance = this;
        }

        public void CloseSettings()
        {
            this.gameObject.SetActive(false);
        }

        public void ChangeVolume()
        {
            this.SoundVolume = (int)(soundVolumeSlider.value * 100);
        }

        public void ChangeLanguage()
        {
            this.Language = (ELanguage)languageDropdown.value;
        }

        public void ChangeSoundOn()
        {
            this.IsSoundOn = !this.IsSoundOn;
        }
    }
}
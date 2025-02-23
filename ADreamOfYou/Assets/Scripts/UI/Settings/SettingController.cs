using System;
using Camera;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private Text txtLanguage;
        [SerializeField] private GroupChangeValue musicVolumeGroup;
        [SerializeField] private GroupChangeValue soundVolumeGroup;

        private void Update()
        {
            txtLanguage.text = "Ngôn ngữ: " + GameManager.Instance.Language.ToString();
        }

        public void ChangeMusicVolume(int volume)
        {
            musicVolumeGroup.OnChangeValue(volume);
        }

        public void ChangeSoundVolume(int volume)
        {
            soundVolumeGroup.OnChangeValue(volume);
        }
        
        public void OnClickLanguageButton()
        {
            CameraUI.Instance.Next();
        }

        public void OnClickGraphicButton()
        {
            CameraUI.Instance.Next();
        }
    }
}
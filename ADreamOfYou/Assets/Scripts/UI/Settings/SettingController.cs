using System;
using Camera;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SettingController : MonoBehaviour
    {
        [SerializeField] private Text txtLanguage;
        [SerializeField] private Text txtGraphic;
        [SerializeField] private GroupChangeValue musicVolumeGroup;
        [SerializeField] private GroupChangeValue soundVolumeGroup;
        [SerializeField] private GameObject languageScreen;
        [SerializeField] private GameObject graphicScreen;
        private void Update()
        {
            txtLanguage.text = "Ngôn ngữ: " + GameManager.Instance.Language.ToString();
            txtGraphic.text = "Đồ họa: " + GameManager.Instance.Resolution.ToString();
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
            graphicScreen.SetActive(false);
            languageScreen.SetActive(true);
        }

        public void OnClickGraphicButton()
        {
            CameraUI.Instance.Next();
            graphicScreen.SetActive(true);
            languageScreen.SetActive(false);
        }
    }
}
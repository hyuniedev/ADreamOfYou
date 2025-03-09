using System;
using Camera;
using Enum;
using Manager;
using UnityEngine;

namespace UI.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private GameObject continueButton;

        [SerializeField] private GameObject settingsScreen;
        [SerializeField] private GameObject aboutScreen;

        private void Start()
        {
            continueButton.SetActive(false);
            settingsScreen.SetActive(false);
            aboutScreen.SetActive(false);
        }

        public void OnClickContinue()
        {
            
        }

        public void OnClickNewGame()
        {
            SceneManager.Instance.ChangeScene(EScene.Chapter1S1);
        }
        
        public void OnClickSettings()
        {
            aboutScreen.SetActive(false);
            settingsScreen.SetActive(true);
            CameraUI.Instance.Next();
        }

        public void OnClickAbout()
        {
            settingsScreen.SetActive(false);
            aboutScreen.SetActive(true);
            CameraUI.Instance.Next();
        }
    
        public void OnClickQuit()
        {
            Application.Quit();
        }
    }
}
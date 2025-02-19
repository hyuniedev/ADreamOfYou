using UnityEngine;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        //---------------------------------------------------
        [SerializeField] private GameObject settingsCanvas;
        [SerializeField] private GameObject gameScene;
        [SerializeField] private GameObject aboutCanvas;
        //---------------------------------------------------
        public void ContinueButtonEvent()
        {
            // TODO: Load data scene of player
            gameScene.SetActive(true);
        }

        public void NewGameButtonEvent()
        {
            // TODO: Create new game
            gameScene.SetActive(true);
        }

        public void SettingsButtonEvent()
        {
            settingsCanvas.SetActive(true);
        }

        public void AboutButtonEvent()
        {
            aboutCanvas.SetActive(true);
        }

        public void QuitButtonEvent()
        {
            Application.Quit();
        }
    }   
}
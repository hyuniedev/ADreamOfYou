using System;
using DesignPattern;
using Enum;
using UnityEngine;

namespace Manager
{
    public class SceneManager:Singleton<SceneManager>
    {
        [HideInInspector]
        public GameObject[] Scenes;
        private int currentScene;
        private void Start()
        {
            currentScene = 0;
            Scenes[currentScene].SetActive(true);
            for(int i = 1; i < Scenes.Length; i++)
                Scenes[i].SetActive(false);
        }

        public void ChangeScene(EScene scene)
        {
            Scenes[currentScene].SetActive(false);
            currentScene = (int) scene;
            Scenes[currentScene].SetActive(true);
        }
        public void BackToHome()
        {
            Scenes[currentScene].SetActive(false);
            currentScene = 0;
            Scenes[currentScene].SetActive(true);
        }
    }
}
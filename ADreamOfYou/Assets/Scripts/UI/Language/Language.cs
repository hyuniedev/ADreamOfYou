using System;
using Enum;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Language
{
    public class Language : MonoBehaviour
    {
        [SerializeField] private ELanguage language;
        public void OnChangeLanguage()
        {
            GameManager.Instance.Language = language;
        }

        private void Update()
        {
            if (GameManager.Instance.Language == language)
                gameObject.GetComponent<Image>().color = Color.yellow;
            else
                gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
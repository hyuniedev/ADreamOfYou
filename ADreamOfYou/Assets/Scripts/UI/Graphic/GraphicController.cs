using System;
using Manager;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Graphic
{
    public class GraphicController : MonoBehaviour
    {
        [SerializeField] private ResolutionGroup resolutionGroup;
        [SerializeField] private Text txtFullscreen;
        [SerializeField] private RectTransform rectTransformCamera;
        [SerializeField] private Image buttonApplyChange;
        private bool _isFullscreen;
        public static bool ChangedGraphic = false;
        private static bool _changedFullScreen = false;
        private void Start()
        {
            InitSetup();
        }

        private void Update()
        {
            if (rectTransformCamera.anchoredPosition.x > -1200) InitSetup();
            
            if (_changedFullScreen || ChangedGraphic)
                buttonApplyChange.color = Color.white;
            else
                buttonApplyChange.color = Color.gray;
            
        }
        
        private void InitSetup()
        {
            resolutionGroup.ResetResolution();
            _isFullscreen = GameManager.Instance.IsFullscreen;
            UpdateTextFullscreen();
            _changedFullScreen = false;
            ChangedGraphic = false;
        }

        public void OnChangeFullscreen()
        {
            _isFullscreen = !_isFullscreen;
            UpdateTextFullscreen();
            _changedFullScreen = _isFullscreen != GameManager.Instance.IsFullscreen;
        }

        private void UpdateTextFullscreen()
        {
            txtFullscreen.text = "Toàn Màn Hình: " + (_isFullscreen ? "Bật" : "Tắt");
        }
        
        public void OnApplyChanges()
        {
            GameManager.Instance.IsFullscreen = _isFullscreen;
            GameManager.Instance.Resolution = resolutionGroup.GetResolution();
            GameManager.Instance.ApplyResolution();
            InitSetup();
        }
    }
}
using System;
using UnityEngine;

namespace Camera
{
    public class CameraUI : MonoBehaviour
    {
        private static CameraUI _instance;

        public static CameraUI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindFirstObjectByType<CameraUI>();
                return _instance;
            }
        }

        [SerializeField] private RectTransform cam;
        [SerializeField] private float speed = 10f;
        private Vector2 _nextPosition = Vector2.zero;
        public void Next()
        {
            _nextPosition = new Vector2(_nextPosition.x-800,0);
        }

        public void Previous()
        {
            _nextPosition = new Vector2(_nextPosition.x+800,0);
        }

        private void Update()
        {
            cam.anchoredPosition = Vector2.Lerp(cam.anchoredPosition, _nextPosition, Time.deltaTime*speed);
        }
    }
}
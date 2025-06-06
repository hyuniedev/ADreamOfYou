using UnityEngine;

namespace Chapters.Chapter1
{
    public class StackProcess : MonoBehaviour
    {
        [SerializeField] private RectTransform slider;

        private void Start()
        {
            slider.sizeDelta = new Vector2(0,slider.sizeDelta.y);
        }

        public void Push(float value)
        {
            var newValue = slider.sizeDelta.x + value > 100 ? 100 : slider.sizeDelta.x + value;
            slider.sizeDelta = new Vector2(newValue, slider.sizeDelta.y);
        }

        public void Pop(float value)
        {
            var newValue = slider.sizeDelta.x - value < 0 ? 0 : slider.sizeDelta.x - value;
            slider.sizeDelta = new Vector2(newValue, slider.sizeDelta.y);
        }

        public bool IsFull()
        {
            return slider.sizeDelta.x >= 100;
        }
    }
}
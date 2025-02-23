using UnityEngine;

namespace UI.Settings
{
    public class SoundGroup: GroupChangeValue
    {
        private void Start()
        {
            Value = GameManager.Instance.Volume.Sound;
            SetTextUI();
        }
        public override void OnChangeValue(int value)
        {
            if (Value + value is < 0 or > 10) return;
            base.OnChangeValue(value);
            SetTextUI();
            GameManager.Instance.Volume = new Volume(GameManager.Instance.Volume.Music,Value);
        }
        private void SetTextUI()
        {
            textUI.text = "Âm thanh: " + Value;;
        }
    }
}
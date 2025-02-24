using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Graphic
{
    public class ResolutionGroup : GroupChangeValue
    {
        private List<String> _lsGraphicSize = new List<String> { "1920x1080", "1280x720", "800x600"};

        public override void OnChangeValue(int value)
        {
            if(Value + value >= _lsGraphicSize.Count || Value + value < 0)
                Value = (_lsGraphicSize.Count + (Value + value)%_lsGraphicSize.Count) % _lsGraphicSize.Count;
            else
                base.OnChangeValue(value);
            UpdateGraphicSize();
        }

        public void ResetResolution()
        {
            Value = _lsGraphicSize.IndexOf(GameManager.Instance.Resolution.ToString());
            UpdateGraphicSize();
        }

        public Resolution GetResolution()
        {
            var size = _lsGraphicSize[Value].Split("x").Select(int.Parse).ToList();
            return new Resolution(size[0], size[1]);
        }
        
        private void UpdateGraphicSize()
        {
            GraphicController.ChangedGraphic = !_lsGraphicSize[Value].Equals(GameManager.Instance.Resolution.ToString());
            textUI.text = _lsGraphicSize[Value];
        }
    }
}
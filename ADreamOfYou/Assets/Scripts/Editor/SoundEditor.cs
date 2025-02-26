using System;
using Enum;
using Sound;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SoundController))]
    public class SoundEditor : UnityEditor.Editor
    {
        private bool _isExpanded = true;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var names = System.Enum.GetNames(typeof(ESound));
            
            SoundController obj = (SoundController) target;
            Array.Resize(ref obj.clips, names.Length);
            _isExpanded = EditorGUILayout.Foldout(_isExpanded, "Sound list");
            if (_isExpanded)
            {
                for(var i = 0; i < names.Length; i++)
                {
                    obj.clips[i] = (AudioClip) EditorGUILayout.ObjectField(names[i], obj.clips[i], typeof(AudioClip), false);
                }
            }
        }
    }
}
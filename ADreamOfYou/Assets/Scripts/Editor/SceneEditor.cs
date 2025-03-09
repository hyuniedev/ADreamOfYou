using System;
using Enum;
using Manager;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SceneManager))]
    public class SceneEditor : UnityEditor.Editor
    {
        private bool _isExpanded = false;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var scenes = System.Enum.GetNames(typeof(EScene));
            SceneManager sceneManager = (SceneManager) target;
            Array.Resize(ref sceneManager.Scenes, scenes.Length);
            _isExpanded = EditorGUILayout.Foldout(_isExpanded, "Scenes");
            if (_isExpanded)
            {
                for (int i = 0; i < scenes.Length; i++)
                {
                    sceneManager.Scenes[i] = (GameObject)
                        EditorGUILayout.ObjectField(scenes[i], sceneManager.Scenes[i], typeof(GameObject), true);
                }
            }
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class GroupChangeValue : MonoBehaviour
    {
        [SerializeField] protected Text textUI;
        
        protected int Value{get; set;}

        public virtual void OnChangeValue(int value)
        {
            Value += value;
        }
    }
}
using System;
using DG.Tweening;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chapters.Chapter1
{
    public class TowableObject : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private GameObject boundLimit;
        private Vector3 _startPosition;

        private bool _isScaled = false;
        
        private void Start()
        {
            _startPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!boundLimit.GetComponent<BoxCollider2D>().bounds.Contains(eventData.position))
                return;
            transform.position = eventData.position;
            transform.SetAsLastSibling();
            if (!_isScaled)
            {
                _isScaled = true;
                transform.DOScale(Vector3.one * 1.5f, .2f).SetEase(Ease.Linear);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isScaled)
            {
                _isScaled = false;
                transform.DOScale(Vector3.one, .2f).SetEase(Ease.Linear);
            }
            if (!boundLimit.GetComponent<BoxCollider2D>().bounds.Contains(eventData.position))
            {
                transform.position = _startPosition;
                return;
            }
            _startPosition = transform.position;
        }
    }
}
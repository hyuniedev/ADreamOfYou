using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Chapter1
{
    public class Toothbrush : MonoBehaviour,IDragHandler, IEndDragHandler
    {
        private Vector3 _brush;
        [SerializeField] private GameObject boundLimit;
        private bool _isStopDrag = false;
        [SerializeField]
        private Slider slider;
        private float _curStack = 0;
        private Vector3 _prevPos;
        private void Start()
        {
            _curStack = 0;
            _prevPos = transform.position;
            slider.value = 0;
            _brush = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _isStopDrag = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isStopDrag) return;
            transform.position = eventData.position;
            _curStack += Time.deltaTime * 2;
            if (_curStack >= 1f)
            {
                if (Vector3.Distance(transform.position, _prevPos) > 100f)
                {
                    _curStack = 0;
                    slider.value += Random.Range(5f, 8f);
                    _prevPos = transform.position;
                }
            }
            if (!boundLimit.GetComponent<BoxCollider2D>().bounds.Contains(transform.position))
            {
                ComebackToOrigin();
                _isStopDrag = true;
            }
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            ComebackToOrigin();
        }
        public void ComebackToOrigin()
        {
            transform.position = _brush;
            _curStack = 0;
            _prevPos = transform.position;
        }
    }
}
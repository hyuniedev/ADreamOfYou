using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Chapters.Chapter1
{
    public class Toothbrush : MonoBehaviour,IDragHandler, IEndDragHandler
    {
        private Vector3 _brush;
        [SerializeField] private GameObject boundLimit;
        private bool _isStopDrag = false;
        [SerializeField]
        private RectTransform slider;
        [SerializeField]
        private int maxValue = 150;
        private float _curStack = 0;
        private Vector3 _prevPos;
        private void Start()
        {
            _curStack = 0;
            _prevPos = transform.position;
            slider.sizeDelta = new Vector2(0,slider.sizeDelta.y);
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
            if (!boundLimit.GetComponent<BoxCollider2D>().bounds.Contains(eventData.position))
            {
                _isStopDrag = true;
            }
            else
            {
                _isStopDrag = false;
                transform.position = eventData.position;
            }
            if (_isStopDrag) return;
            _curStack += Time.deltaTime * 2;
            if (_curStack >= 1f)
            {
                if (Vector3.Distance(transform.position, _prevPos) > 100f)
                {
                    _curStack = 0;
                    var newValue = slider.sizeDelta.x + Random.Range(15f, 20f);
                    if(newValue > maxValue) newValue = maxValue;
                    slider.sizeDelta = new Vector2(newValue,slider.sizeDelta.y);
                    _prevPos = transform.position;
                }
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
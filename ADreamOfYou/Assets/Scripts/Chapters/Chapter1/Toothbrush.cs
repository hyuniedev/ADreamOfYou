using Enum;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Chapters.Chapter1
{
    public class Toothbrush : MonoBehaviour,IDragHandler, IEndDragHandler, ISceneManager
    {
        private Vector3 _originalPosition;
        [SerializeField] private GameObject boundLimit;
        [SerializeField] private GameObject tooth;
        [SerializeField] private StackProcess stack;
        
        [Range(0f,1f)]
        [SerializeField] private float durationCheck = 1f;
        [SerializeField] private float addValuePerPush = 20f;

        private float _curValueCheck;
        private Vector2 _prevDirection = Vector2.one;
        private Vector3 _currentToothPosition;
        private void Start()
        {
            _originalPosition = tooth.transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!boundLimit.GetComponent<BoxCollider2D>().bounds.Contains(eventData.position))
                return;
            tooth.transform.position = eventData.position;

            _curValueCheck += Time.deltaTime * 2f;
            if (_curValueCheck >= durationCheck)
            {
                _curValueCheck = 0;
                var direc = (tooth.transform.position - _originalPosition).normalized;
                if (direc.x * _prevDirection.x < 0 || direc.y * _prevDirection.y < 0)
                {
                    stack.Push(addValuePerPush);
                    _currentToothPosition = tooth.transform.position;
                    _prevDirection = direc;
                    if (stack.IsFull())
                    {
                        Invoke(nameof(NextScene),1f);
                    }
                }
            }
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            ComebackToOrigin();
        }
        
        public void ComebackToOrigin()
        {
            tooth.transform.position = _originalPosition;
            _currentToothPosition = tooth.transform.position;
        }

        public void NextScene()
        {
            SceneManager.Instance.ChangeScene(EScene.Chapter1S3);
        }
    }
}
using Enum;
using Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chapters.Chapter1
{
    public class Clock : MonoBehaviour, IPointerDownHandler, ISceneManager
    {
        private Animator _animator;
        private readonly string ANIMATION_CLOCK = "clock";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.enabled = true;
            _animator.Play(ANIMATION_CLOCK);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _animator.enabled = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Invoke(nameof(NextScene),1f);
        }

        public void NextScene()
        {
            SceneManager.Instance.ChangeScene(EScene.Chapter1S2);
        }
    }
}
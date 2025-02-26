using System.Collections;
using System.Collections.Generic;
using DesignPattern;
using Enum;
using UnityEngine;

namespace Sound
{
    public class SoundController : Singleton<SoundController>
    {
        [SerializeField]
        private AudioSource audioSource;

        [HideInInspector]
        public AudioClip[] clips;
        
        private Queue<AudioSource> _objAudioPool = new Queue<AudioSource>();
        
        public void PlaySound(ESound sound)
        {
            StartCoroutine(PlaySoundCoroutine(sound));
        }

        private IEnumerator PlaySoundCoroutine(ESound sound)
        {
            AudioSource objAudio =_objAudioPool.Count == 0? Instantiate(audioSource, transform):_objAudioPool.Dequeue();
            objAudio.gameObject.SetActive(true);
            objAudio.PlayOneShot(clips[(int)sound]);
            yield return new WaitUntil(()=>!objAudio.isPlaying);
            objAudio.gameObject.SetActive(false);
            _objAudioPool.Enqueue(objAudio);
        } 
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Manager;
using UnityEngine;
using DesignPattern;

namespace Sound
{
    public class SoundController : Singleton<SoundController>
    {
        [SerializeField]
        private AudioSource audioSource;

        [HideInInspector]
        public AudioClip[] clips;
        
        private Queue<AudioSource> _objAudioPool = new Queue<AudioSource>();

        private AudioSource _audioBackground;
        private ESound _curSoundBg;

        private void Start()
        {
            var obj = Instantiate(audioSource, transform);
            _audioBackground = obj.GetComponent<AudioSource>();
            _audioBackground.loop = true;
            PlayMusic(ESound.Music_On_Menu);
        }
        public void UpdateVolumeMusic()
        {
            _audioBackground.volume = GameManager.Instance.Volume.Music/10f;
        }
        public void PlayMusic(ESound sound)
        {
            if (sound == _curSoundBg) return;
            _curSoundBg = sound;
            _audioBackground.clip = clips[(int)_curSoundBg];
            _audioBackground.Play();
        }
        public void PlaySound(ESound sound)
        {
            StartCoroutine(PlaySoundCoroutine(sound));
        }

        private IEnumerator PlaySoundCoroutine(ESound sound)
        {
            AudioSource objAudio =_objAudioPool.Count == 0? Instantiate(audioSource, transform):_objAudioPool.Dequeue();
            objAudio.gameObject.SetActive(true);
            objAudio.volume = GameManager.Instance.Volume.Sound/10f;
            objAudio.PlayOneShot(clips[(int)sound]);
            yield return new WaitUntil(()=>!objAudio.isPlaying);
            objAudio.gameObject.SetActive(false);
            _objAudioPool.Enqueue(objAudio);
        } 
    }
}

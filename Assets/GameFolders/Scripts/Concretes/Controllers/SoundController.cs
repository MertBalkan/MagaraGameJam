using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class SoundController : MonoBehaviour
    {
        private AudioSource _audioSource;
        public bool IsPlaying => _audioSource.isPlaying;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetClip(AudioClip clip){
            _audioSource.clip = clip;
        }
        public void PlaySound()
        {
            if(IsPlaying) return;
            _audioSource.Play();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Concretes.Controllers;
using MagaraGameJam.Utilities.Patterns;
using UnityEngine;

namespace MagaraGameJam.Concretes.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioClip[] _clips;
        private SoundController[] _soundControllers;
        public SoundController[] SoundControllers => _soundControllers;

        private bool _canFootstepPlay;
        public bool CanFootstepPlay { get => _canFootstepPlay; set => _canFootstepPlay = value; }

        private void Awake()
        {
            SingletonObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        public void FootstepSound()
        {
            _canFootstepPlay = true;
            int ranIndex = Random.Range(0, 2);

            if (_canFootstepPlay)
            {
                _soundControllers[ranIndex].PlaySound();
            }
        }

        public void HitSound()
        {
            _soundControllers[2].PlaySound();
        }

        public void GunFireSound(){
            _soundControllers[3].PlaySound();
        }
    }
}
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

        /// <summary>
        /// Footstep sound.
        /// </summary>
        public void FootstepSound()
        {
            _canFootstepPlay = true;
            int ranIndex = Random.Range(0, 2);
            Debug.Log("ranIndex: " + ranIndex);

            if (_canFootstepPlay)
            {
                _soundControllers[ranIndex].PlaySound();
            }
        }
        /// <summary>
        /// Hit sound.
        /// </summary>
        public void HitSound()
        {
            _soundControllers[2].PlaySound();
        }

        /// <summary>
        /// Guns fire sound.
        /// </summary>
        public void GunFireSound()
        {
            _soundControllers[3].PlaySound();
        }

        /// <summary>
        /// Alarm sound.
        /// </summary>
        public void AlarmSound()
        {
            _soundControllers[4].PlaySound();
        }

        /// <summary>
        /// Desert footstep sound.
        /// </summary>
        public void DesertFootstepSound()
        {
            _soundControllers[5].PlaySound();
        }
        
        /// <summary>
        /// Mumbling sound.
        /// </summary>
        public void MumblingSound()
        {
            _soundControllers[6].PlaySound();
        }

        public void StopSound(){
            _soundControllers[4].StopSound();
        }
    }
}
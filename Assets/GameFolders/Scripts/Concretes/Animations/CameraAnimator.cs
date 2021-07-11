using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Animations
{
    public class CameraAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void ShakeCameraAnimation()
        {
            _animator.SetTrigger("shakeCamera");
        }
    }
}
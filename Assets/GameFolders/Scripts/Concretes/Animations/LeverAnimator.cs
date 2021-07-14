using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Animations
{
    public class LeverAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayLeverAnimation()
        {
            _animator.Play("LeverAnimation");
            _animator.SetTrigger("lever");
        }
    }
}
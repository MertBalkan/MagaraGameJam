using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace MagaraGameJam.Concretes.Controllers
{
    public class LeverController : MonoBehaviour
    {
        private Light2D _light;
        private Animator _animator;
        private Color _startColor = Color.green;
        private Color _endColor = Color.red;

        private void Awake()
        {
            _light = GetComponentInChildren<Light2D>();
            _animator = GetComponent<Animator>();
        }

        public void ChangeColor()
        {
            _animator.SetTrigger("lever");
            _light.color = Color.Lerp(_startColor, _endColor, Time.deltaTime);
        }
    }
}
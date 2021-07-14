using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Concretes.Animations;
using MagaraGameJam.Concretes.Inputs;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace MagaraGameJam.Concretes.Controllers
{
    public class LightController : MonoBehaviour
    {
        [SerializeField] private Light2D[] _lights;
        [SerializeField] private Light2D _sunLight;
        private IInputAction _input;
        private PlayerController _playerController;
        private LeverAnimator _leverController;

        private void Awake()
        {
            _input = new PcInput();
            _lights = GetComponentsInChildren<Light2D>();
            _playerController = FindObjectOfType<PlayerController>();
            _leverController = FindObjectOfType<LeverAnimator>();
        }

        private void Start()
        {
            SetLights(0);
        }

        private void Update()
        {
            if (_input.InteractButton && _playerController != null && _playerController.IsOnTrigger)
            {
                SetLights(1);
                _leverController?.PlayLeverAnimation();
                _sunLight.intensity = 1;
            }
        }

        public void SetLights(int lightIntensity)
        {
            foreach (var light in _lights)
                light.intensity = lightIntensity;
        }
    }
}
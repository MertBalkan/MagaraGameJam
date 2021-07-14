using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Concretes.Controllers;
using MagaraGameJam.Concretes.Inputs;
using MagaraGameJam.Concretes.Movements;
using UnityEngine;
using UnityEngine.UI;

namespace MagaraGameJam.Concretes.UIs
{
    public class FuelSlider : MonoBehaviour
    {
        private Slider _slider;
        private FuelController _fuelController;
        private IInputAction _input;
        private OnGround _onGround;

        private void Awake()
        {
            _slider = GetComponent<Slider>();

            _fuelController = FindObjectOfType<FuelController>();
            _onGround = FindObjectOfType<OnGround>();

            _input = new PcInput();
        }

        private void Start()
        {
            _fuelController.FuelAmount = _slider.value;
        }

        private void Update()
        {
            FuelDecrease();
            FuelIncrease();
            
        }

        private void FuelDecrease()
        {
            if (_input.JumpButton)
                _fuelController.FuelAmount -= Time.deltaTime * _fuelController.FuelDownSpeed;

            if(_fuelController.FuelAmount <= 0) _fuelController.FuelAmount = 0;
            SetSlider();
        }

        public void FuelIncrease()
        {
            if (_onGround.IsOnGround)
            {
                StartCoroutine(FuelIncreaseAsync());
            }
        }

        private IEnumerator FuelIncreaseAsync()
        {
            yield return new WaitForSeconds(2.0f);

            if (_fuelController.FuelAmount >= 0) _fuelController.FuelAmount += Time.deltaTime * _fuelController.FuelDownSpeed;
            if (_fuelController.FuelAmount >= 100) _fuelController.FuelAmount = 100.0f;
           
            SetSlider();
        }

        private void SetSlider()
        {
            _slider.value = _fuelController.FuelAmount;
        }
    }
}
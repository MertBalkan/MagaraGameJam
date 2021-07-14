using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace MagaraGameJam.Concretes.UIs
{
    public class ClickCountSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        private void Update()
        {
            _slider.value = GameManager.Instance.ClickCount;
        }
    }
}
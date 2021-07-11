using MagaraGameJam.Abstracts.Combats;
using MagaraGameJam.Concretes.Combats;
using MagaraGameJam.Concretes.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace MagaraGameJam.Concretes.UIs
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        private Slider _slider;
        private IHealth _health;
    
        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _health = _player.GetComponent<Health>();
        }

        private void Update()
        {
            _slider.value = _health.CurrentHealth;
        }
    }
}
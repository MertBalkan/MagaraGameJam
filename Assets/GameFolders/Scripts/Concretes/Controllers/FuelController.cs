using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class FuelController : MonoBehaviour
    {
        [SerializeField] private float _fuelDownSpeed = 3.0f;

        private float _fuelAmount = 100.0f;
        private float _currentFuel = 100.0f;

        public float FuelAmount { get => _fuelAmount; set => _fuelAmount = value; }
        public float FuelDownSpeed => _fuelDownSpeed;
    }
}
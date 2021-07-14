using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Concretes.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Managers
{
    public class PressureBarManager : MonoBehaviour
    {
        [SerializeField] private PressureBarController[] _pressureBars;

        private void Awake()
        {
            _pressureBars = GetComponentsInChildren<PressureBarController>();
        }

        public void PressureBarChecker1()
        {
            _pressureBars[0].PressureChecker1();
        }
        public void PressureBarChecker2()
        {
            _pressureBars[1].PressureChecker2();
        }
        public void PressureBarChecker3()
        {
            _pressureBars[2].PressureChecker3();
        }
    }
}
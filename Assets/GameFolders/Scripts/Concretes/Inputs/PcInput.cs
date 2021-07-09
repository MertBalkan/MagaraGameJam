using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using UnityEngine;

namespace MagaraGameJam.Concretes.Inputs
{
    public class PcInput : IInputAction
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool JumpButtonDown => Input.GetButtonDown("Jump");
    }
}
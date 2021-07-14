using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using UnityEngine;

namespace MagaraGameJam.Concretes.Inputs
{
    public class PcInput : IInputAction
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public bool JumpButton => Input.GetButton("Jump");
        public bool InteractButton => Input.GetKeyDown(KeyCode.E);
        public bool IsLeftButtonClicked => Input.GetMouseButtonDown(0);
    }
}
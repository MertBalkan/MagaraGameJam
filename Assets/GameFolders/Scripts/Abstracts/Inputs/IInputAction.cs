using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Abstracts.Inputs
{
    public interface IInputAction
    {
        float Horizontal { get; }
        bool JumpButton { get; }
        bool InteractButton { get; }
        bool IsLeftButtonClicked { get; }
    }
}
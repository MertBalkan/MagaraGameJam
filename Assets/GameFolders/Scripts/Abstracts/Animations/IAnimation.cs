using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Abstracts.Animations
{
    public interface IAnimation
    {
        void MoveCharacter(float direction);
        void FlyCharacter(bool isFlying);
    }
}
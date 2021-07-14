using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Concretes.Animations;
using UnityEngine;

namespace MagaraGameJam.Abstracts.Combats
{
    public interface IHealth
    {
        void TakeHit(int damage, IAnimation animator);
        bool IsDead { get; }
        float CurrentHealth { get; }
    }
}
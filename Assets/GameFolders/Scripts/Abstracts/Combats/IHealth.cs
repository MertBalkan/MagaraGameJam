using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Abstracts.Combats
{
    public interface IHealth
    {
        void TakeHit(int damage);
        bool IsDead { get; }
        float CurrentHealth { get; }
    }
}
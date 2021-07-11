using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Movements;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class OnGround : MonoBehaviour, IOnGround
    {
        private bool _isOnGround;

        public bool IsOnGround { get => _isOnGround; set => _isOnGround = value; }
    }
}
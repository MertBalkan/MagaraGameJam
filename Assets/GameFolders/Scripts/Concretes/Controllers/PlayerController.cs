using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Concretes.Inputs;
using MagaraGameJam.Concretes.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float _moveSpeed;

        private IInputAction _input;
        private IMover _mover;
        private IFlip _flip;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new MoveWithTransform(this);
            _flip = new FlipWithTransform(this);
        }
        private void Update()
        {
            float hor = _input.Horizontal;

            _mover.Movement(hor);
            _flip.Flip(hor);
        }
    }
}

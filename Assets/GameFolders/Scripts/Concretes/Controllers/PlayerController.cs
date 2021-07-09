using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Concretes.Animations;
using MagaraGameJam.Concretes.Inputs;
using MagaraGameJam.Concretes.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce = 10;

        private IInputAction _input;
        private IMover _mover;
        private IFlip _flip;
        private IAnimation _animation;
        private IJump _jump;

        private float _hor;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _input = new PcInput();
            _mover = new MoveWithTransform(this);
            _flip = new FlipWithTransform(this);
            _animation = new CharacterAnimator(this);
            _jump = new JumpWithRigidBody(this, _input);
        }

        private void Update()
        {
            _hor = _input.Horizontal;

            _mover.Movement(_hor);
            _flip.Flip(_hor, 0.6f);
            _jump.Jump(_jumpForce);
        }

        private void LateUpdate()
        {
            _animation.MoveCharacter(_hor);
        }
    }
}

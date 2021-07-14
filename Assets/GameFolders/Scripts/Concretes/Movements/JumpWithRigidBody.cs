using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Concretes.Controllers;
using MagaraGameJam.Concretes.Managers;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class JumpWithRigidBody : IJump
    {
        private IEntityController _entity;
        private IInputAction _input;

        private FuelController _fuelController;

        private bool _isFlying;

        public bool IsFlying { get => _isFlying; set => _isFlying = value; }

        public JumpWithRigidBody(IEntityController entity, IInputAction input, FuelController fuelController)
        {
            _entity = entity;
            _input = input;
            _fuelController = fuelController;
        }

        public void Jump(float jumpForce)
        {
            Rigidbody2D rb2D = _entity.transform.GetComponent<Rigidbody2D>();

            if (_input.JumpButton && _fuelController.FuelAmount > 0)
            {
                rb2D.AddForce(Vector2.up * Time.deltaTime * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
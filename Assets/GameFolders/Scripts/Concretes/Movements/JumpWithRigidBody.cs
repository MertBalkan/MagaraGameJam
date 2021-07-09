using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class JumpWithRigidBody : IJump
    {
        private IEntityController _entity;
        private IInputAction _input;

        public JumpWithRigidBody(IEntityController entity, IInputAction input)
        {
            _entity = entity;
            _input = input;
        }

        public void Jump(float jumpForce)
        {
            Rigidbody2D rb2D = _entity.transform.GetComponent<Rigidbody2D>();

            if (_input.JumpButtonDown && Mathf.Abs(rb2D.velocity.y) < 0.001f)
                rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
}
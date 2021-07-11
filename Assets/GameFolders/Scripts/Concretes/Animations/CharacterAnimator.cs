using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Animations
{
    public class CharacterAnimator : IAnimation
    {
        private IEntityController _entity;

        public CharacterAnimator(IEntityController entity)
        {
            _entity = entity;
        }

        public void FlyCharacter(bool isFlying)
        {
            _entity.transform.GetComponent<Animator>().SetBool("isFlying", isFlying);
        }

        public void MoveCharacter(float direction)
        {
            direction = Mathf.Abs(direction);
            _entity.transform.GetComponent<Animator>().SetFloat("direction", direction);
        }
    }
}
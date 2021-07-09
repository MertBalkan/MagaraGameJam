using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class MoveWithTransform : IMover
    {
        private IEntityController _entity;
        public MoveWithTransform(IEntityController entity)
        {
            _entity = entity;
        }
        public void Movement(float direction)
        {
            if(direction == 0) return;

            _entity.transform.Translate(Vector3.right * direction * Time.deltaTime * _entity.MoveSpeed);
        }
    }
}
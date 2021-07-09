using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class FlipWithTransform : IFlip
    {
        private IEntityController _entity;
        public FlipWithTransform(IEntityController entity)
        {
            _entity = entity;
        }
        public void Flip(float direction, float scaleValue)
        {
            if(direction == 0) return;
            direction = Mathf.Sign(direction);

            Vector2 flipVector = new Vector2(direction * _entity.transform.localScale.x, _entity.transform.localScale.y);

            Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction - scaleValue, _entity.transform.localScale.y) : flipVector = new Vector2(direction + scaleValue, _entity.transform.localScale.y);

            _entity.transform.localScale = newFlipVector;
        }
    }
}
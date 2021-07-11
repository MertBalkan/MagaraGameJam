using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Concretes.Managers;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Movements
{
    public class MoveWithTransform : IMover
    {
        private IEntityController _entity;
        private AudioClip[] _clips;
        private OnGround _onGround;

        public MoveWithTransform(IEntityController entity, OnGround onGround, params AudioClip[] footstepSounds)
        {
            _entity = entity;
            _clips = footstepSounds;
            _onGround = onGround;

            foreach (var footstep in _clips)
                for (int i = 0; i < footstep.length; i++)
                    SoundManager.Instance.SoundControllers[i].SetClip(footstep);
        }
        public void Movement(float direction)
        {
            if (direction == 0) return;

            if (_onGround.IsOnGround)
            {
                SoundManager.Instance.FootstepSound();
            }
            
            _entity.transform.Translate(Vector3.right * direction * Time.deltaTime * _entity.MoveSpeed);
        }
    }
}
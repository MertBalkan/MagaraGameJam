using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Abstracts.Combats;
using MagaraGameJam.Concretes.Animations;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;
        private IEntityController _entity;

        public float CurrentHealth => _currentHealth;
        public bool IsDead => _currentHealth <= 0;

        public Health(IEntityController entity)
        {
            _entity = entity;
        }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeHit(int damage, IAnimation animator)
        {
            if(IsDead) animator.DieCharacter();
            if(IsDead) return;
            _currentHealth -= damage;

        }
    }
}
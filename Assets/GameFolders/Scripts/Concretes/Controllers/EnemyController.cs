using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Abstracts.Combats;
using MagaraGameJam.Concretes.Animations;
using MagaraGameJam.Concretes.Combats;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _arm;
        private IHealth _health;
        private IAnimation _animator;

        private EnemyArmController _armController;

        private float _moveSpeed;

        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

        public GameObject Arm => _arm;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = new CharacterAnimator(this);
            _armController = new EnemyArmController();
        }

        private void Update()
        {
            _armController.AimToPlayer(_target, _arm, this);
        }
    }
}
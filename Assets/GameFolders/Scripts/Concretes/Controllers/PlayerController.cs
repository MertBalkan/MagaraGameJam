using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Animations;
using MagaraGameJam.Abstracts.Combats;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Abstracts.Movements;
using MagaraGameJam.Concretes.Animations;
using MagaraGameJam.Concretes.Combats;
using MagaraGameJam.Concretes.Inputs;
using MagaraGameJam.Concretes.Managers;
using MagaraGameJam.Concretes.Movements;
using MagaraGameJam.Concretes.UIs;
using MagaraGameJam.Utilities.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private GameObject _dialogueObjects;
        [SerializeField] private AudioClip[] _footstepSounds;
        [SerializeField] private AudioClip _hitSound;

        private IInputAction _input;
        private IMover _mover;
        private IFlip _flip;
        private IAnimation _animation;
        private OnGround _onGround;
        private IHealth _health;
        private IJump _jump;
        private FuelController _fuelController;
        private CameraAnimator _cameraAnimator;

        private float _hor;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _fuelController = GetComponent<FuelController>();
            _cameraAnimator = FindObjectOfType<CameraAnimator>();
            _health = GetComponent<Health>();
            _onGround = GetComponent<OnGround>();

            _input = new PcInput();
            _mover = new MoveWithTransform(this, _onGround, _footstepSounds);
            _flip = new FlipWithTransform(this);
            _animation = new CharacterAnimator(this);
            _jump = new JumpWithRigidBody(this, _input, _fuelController);
        }

        private void Update()
        {
            if (_health.IsDead) return;
            _hor = _input.Horizontal;

            _mover.Movement(_hor);
            _flip.Flip(_hor, 0.6f);
            _jump.Jump(_jumpForce);

        }

        private void LateUpdate()
        {
            if (_health.IsDead) return;
            _animation.MoveCharacter(_hor);
            _animation.FlyCharacter(!_jump.IsFlying);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            ControlCollisions(other, true, true);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            ControlCollisions(other, false, false);
        }

        private void ControlCollisions(Collision2D other, bool canJump, bool isOnGround)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _jump.IsFlying = canJump;
                _onGround.IsOnGround = isOnGround;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                _health.TakeHit(5);
                Debug.Log(_health.CurrentHealth);
                SoundManager.Instance.SoundControllers[2].SetClip(_hitSound);
                SoundManager.Instance.HitSound();

                _cameraAnimator.ShakeCameraAnimation();
                GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }

            if (other.gameObject.CompareTag("Wife"))
            {
                _dialogueObjects.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                GetComponentInChildren<SpriteRenderer>().color = Color.white;
                Destroy(other.gameObject);
            }
        }
    }
}

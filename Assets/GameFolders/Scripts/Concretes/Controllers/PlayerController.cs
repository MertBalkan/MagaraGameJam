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
        [Header("----MOVEMENTS----")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce = 10;

        [Header("----UIs----")]
        [SerializeField] private GameObject _dieObjects;
        [SerializeField] private GameObject _dialogueObjects;
        [SerializeField] private GameObject _objectiveUIs;
        [SerializeField] private DialogueTrigger[] _allDialogues;
        [SerializeField] private DialogueSystem _dialogueSystem;

        [Header("----AUDIOS----")]
        [SerializeField] private AudioClip[] _footstepSounds;
        [SerializeField] private AudioClip _hitSound;
        [SerializeField] private AudioClip _alarmClip;


        [Header("----PARTICLE EFFECTS----")]
        [SerializeField] private GameObject _bloodParticle;

        [SerializeField] private GameObject _lever;
        [SerializeField] private GameObject _ladder;
        [SerializeField] private GameObject _closed;

        [Header("----CONTROLLERS----")]
        [SerializeField] private ValveController _valveController;
        [SerializeField] private LevelChangeController _levelChangeController;
        [SerializeField] private LeverController _leverController;
        [SerializeField] private PressureBarManager _pressureBarManager;

        private IInputAction _input;
        private IMover _mover;
        private IFlip _flip;
        private IAnimation _animation;
        private OnGround _onGround;
        private IHealth _health;
        private IJump _jump;
        private FuelController _fuelController;
        private CameraAnimator _cameraAnimator;
        private SpriteRenderer _spriteRenderer;

        private float _hor;
        private bool _isOnTrigger;


        public bool IsOnTrigger { get => _isOnTrigger; set => _isOnTrigger = value; }
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

        private void Awake()
        {
            _cameraAnimator = FindObjectOfType<CameraAnimator>();

            _fuelController = GetComponent<FuelController>();
            _health = GetComponent<Health>();
            _onGround = GetComponent<OnGround>();

            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            _input = new PcInput();
            _mover = new MoveWithTransform(this, _onGround, _footstepSounds);
            _flip = new FlipWithTransform(this);
            _animation = new CharacterAnimator(this);
            _jump = new JumpWithRigidBody(this, _input, _fuelController);
        }
        private void Update()
        {
            if (_health.IsDead)
            {
                _dieObjects.SetActive(true);
            }

            if (_health.IsDead) return;

            _hor = _input.Horizontal;

            _mover.Movement(_hor);
            _flip.Flip(_hor, 0.7f);
            _jump.Jump(_jumpForce);
        }

        private void LateUpdate()
        {
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

        /// <summary>
        /// Bullet, Dialog methods
        /// </summary>
        /// <param name="other">The other entity</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                _health.TakeHit(5, _animation);
                Debug.Log(_health.CurrentHealth);
                SoundManager.Instance.SoundControllers[2].SetClip(_hitSound);
                SoundManager.Instance.HitSound();

                GameObject blood = Instantiate(_bloodParticle, transform.position, Quaternion.identity) as GameObject;
                Destroy(blood, 3f);

                _cameraAnimator.ShakeCameraAnimation();
                _spriteRenderer.color = Color.red;

            }

            if (other.gameObject.CompareTag("Wife"))
            {
                //DİALOG BURAYA
                _dialogueObjects.SetActive(true);
                _allDialogues[0].TriggerDialogue(_dialogueSystem);
                _lever.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (other.gameObject.CompareTag("Man"))
            {
                SoundManager.Instance.MumblingSound();
            }

            if (other.gameObject.CompareTag("LevelChangeTrigger"))
            {
                GameManager.Instance.LoadScene(3);
            }

            if (other.gameObject.CompareTag("LevelChangeTrigger2"))
            {
                GameManager.Instance.LoadScene(4);
            }
            if (other.gameObject.CompareTag("LevelChangeTrigger3"))
            {
                GameManager.Instance.LoadScene(5);
            }
            if (other.gameObject.CompareTag("Zepline"))
            {
                GameManager.Instance.LoadScene(6);
            }

            if (other.gameObject.CompareTag("Valve"))
            {
                _allDialogues[2].TriggerDialogue(_dialogueSystem);
                _levelChangeController.GetComponent<BoxCollider2D>().isTrigger = true;
                _dialogueObjects.SetActive(true);
            }

            if (other.gameObject.CompareTag("Man"))
            {
                _dialogueObjects.SetActive(true);
                _allDialogues[0].TriggerDialogue(_dialogueSystem);
                _levelChangeController.gameObject.SetActive(true);
            }

            if (other.gameObject.CompareTag("Man2"))
            {
                _dialogueObjects.SetActive(true);
                _allDialogues[0].TriggerDialogue(_dialogueSystem);
                _levelChangeController.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }

            if (other.gameObject.CompareTag("Supplies"))
            {
                Destroy(other.gameObject);
                _levelChangeController.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Lever") && _input.InteractButton)
            {
                //DİALOG BURAYA

                _valveController.gameObject.SetActive(true);
                _allDialogues[1].TriggerDialogue(_dialogueSystem);
                _dialogueObjects.SetActive(true);
                _isOnTrigger = true;
                _closed.GetComponentInChildren<BoxCollider2D>().enabled = true;

                if (_leverController != null)
                    _leverController.ChangeColor();
            }

            if (other.gameObject.CompareTag("PressureBar") && _input.IsLeftButtonClicked)
            {
                _pressureBarManager.PressureBarChecker1();
            }

            if (other.gameObject.CompareTag("PressureBar2") && _input.IsLeftButtonClicked)
            {
                _pressureBarManager.PressureBarChecker2();
            }

            if (other.gameObject.CompareTag("PressureBar3") && _input.IsLeftButtonClicked)
            {
                _pressureBarManager.PressureBarChecker3();
            }
            if (other.gameObject.CompareTag("Closed") && _input.InteractButton)
            {
                other.gameObject.SetActive(false);
                _pressureBarManager.gameObject.SetActive(true);

                SoundManager.Instance.SoundControllers[4].SetClip(_alarmClip);
                SoundManager.Instance.AlarmSound();

                _objectiveUIs.gameObject.SetActive(true);

                _dialogueObjects.SetActive(true);
                _allDialogues[0].TriggerDialogue(_dialogueSystem);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                _spriteRenderer.color = Color.white;
                Destroy(other.gameObject);

            }
            if (other.gameObject.CompareTag("Wife"))
            {
                _dialogueObjects.SetActive(false);
            }
            if (other.gameObject.CompareTag("Lever"))
            {
                _dialogueObjects.SetActive(false);
            }
            if (other.gameObject.CompareTag("Valve"))
            {
                _dialogueObjects.SetActive(false);
            }
            if (other.gameObject.CompareTag("Man"))
            {
                _dialogueObjects.SetActive(false);
            }
            if (other.gameObject.CompareTag("Man2"))
            {
                _dialogueObjects.SetActive(false);
            }
            _isOnTrigger = false;
        }
    }
}
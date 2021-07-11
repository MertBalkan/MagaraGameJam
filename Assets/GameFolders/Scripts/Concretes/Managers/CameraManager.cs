using MagaraGameJam.Concretes.Controllers;
using MagaraGameJam.Utilities.Patterns;
using UnityEngine;

namespace MagaraGameJam.Concretes.Managers
{
    public class CameraManager : SingletonMonoBehaviour<CameraManager>
    {
        [SerializeField] private PlayerController _player;

        private void Awake()
        {
            SingletonObject(this);
            _player = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            FollowCamera();
        }

        private void FollowCamera()
        {
            if(_player != null)
                this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        }
    }
}
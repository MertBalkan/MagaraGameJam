using MagaraGameJam.Concretes.Controllers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _smoothSpeed = 5.0f;

        private void Update()
        {
            FollowCamera();
        }

        private void FollowCamera()
        {
            Vector3 targetPos = _player.transform.position + new Vector3(0, 3, -10);
            Vector3 newPos = Vector3.Lerp(transform.position, targetPos, _smoothSpeed * Time.deltaTime);

            if (_player != null)
                this.transform.position = newPos;
        }
    }
}
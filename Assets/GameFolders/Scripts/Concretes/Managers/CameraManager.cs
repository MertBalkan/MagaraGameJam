using MagaraGameJam.Utilities.Patterns;
using UnityEngine;

namespace MagaraGameJam.Concretes.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [Header("------CameraShake------")]
        [SerializeField] private float slowCameraShake = default;
        [SerializeField] private float startDuration = default;


        private bool _isCameraShake = false;
        private float _duration = default;

        public bool IsCameraShake { get => _isCameraShake; set => _isCameraShake = value; }

        private void Awake()
        {
            _duration = startDuration;
        }

        public void ShakeCamera()
        {
            if (IsCameraShake)
            {
                if (_duration > 0)
                {
                    transform.localPosition = transform.localPosition + Random.insideUnitSphere * 0.09f;
                    _duration -= Time.deltaTime * slowCameraShake;
                }
                else
                {
                    IsCameraShake = false;
                    _duration = startDuration;
                    transform.localPosition = transform.localPosition;
                }
            }
            if (!IsCameraShake) transform.localPosition = new Vector3(0, 0, -10);
        }
    }
}
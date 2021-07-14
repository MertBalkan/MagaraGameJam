using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagaraGameJam.Concretes.Controllers
{
    public class CutsceneSoundController : MonoBehaviour
    {
        [SerializeField] private GameObject _zepplinSound;
        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            StartCoroutine(Play());
        }
        private IEnumerator Play()
        {
            yield return new WaitForSeconds(6.1f);
            _audioSource.Play();
            _zepplinSound.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(2);
        }
    }
}
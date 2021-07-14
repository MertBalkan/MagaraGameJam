using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MagaraGameJam.Utilities.Patterns;

namespace MagaraGameJam.Concretes.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private AudioClip _desertClip;
        [SerializeField] private int _clickCount = 0;

        private int _barCount;

        public int BarCount { get => _barCount; set => _barCount = value; }
        public int ClickCount { get => _clickCount; set => _clickCount = value; }

        private void Awake()
        {
            SingletonObject(this);
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(sceneIndex);
        }

        public void ChangeFootstepSounds()
        {
            if (SceneManager.GetSceneByBuildIndex(3) == SceneManager.GetActiveScene())
            {
                SoundManager.Instance.SoundControllers[0].SetClip(_desertClip);
                SoundManager.Instance.DesertFootstepSound();
            }
        }
    }
}
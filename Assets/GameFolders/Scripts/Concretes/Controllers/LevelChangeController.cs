using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MagaraGameJam.Concretes.Controllers
{
    public class LevelChangeController : MonoBehaviour
    {
        private void Update()
        {
            if (SceneManager.GetSceneByBuildIndex(6) == SceneManager.GetActiveScene())
            {
                if (GameManager.Instance.BarCount >= 3)
                {
                    GameManager.Instance.LoadScene(7);
                    SoundManager.Instance.StopSound();
                }
            }
        }
    }
}
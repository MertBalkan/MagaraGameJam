using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagaraGameJam.Concretes.UIs
{
    public class DieObjectUI : MonoBehaviour
    {
        public void TryAgainButton(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
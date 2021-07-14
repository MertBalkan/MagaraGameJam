using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Inputs;
using MagaraGameJam.Concretes.Inputs;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MagaraGameJam.Concretes.Managers;

namespace MagaraGameJam.Concretes.Controllers
{
    public class PressureBarController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private IInputAction _input;

        private void Awake()
        {
            _input = new PcInput();
        }

        public void PressureChecker1()
        {
            GameManager.Instance.ClickCount++;

            Debug.Log("Click Count:" + GameManager.Instance.ClickCount);

            if (GameManager.Instance.ClickCount >= 10)
            {
                GameManager.Instance.ClickCount = 0;
                GameManager.Instance.BarCount++;
                _text.text = (GameManager.Instance.BarCount).ToString();
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.SetActive(false);
            }
        }

        public void PressureChecker2()
        {
            GameManager.Instance.ClickCount++;

            Debug.Log("Click Count:" + GameManager.Instance.ClickCount);

            if (GameManager.Instance.ClickCount >= 10)
            {
                GameManager.Instance.ClickCount = 0;
                GameManager.Instance.BarCount++;
                _text.text = (GameManager.Instance.BarCount).ToString();
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.SetActive(false);
            }
        }

        public void PressureChecker3()
        {
            GameManager.Instance.ClickCount++;

            Debug.Log("Click Count:" + GameManager.Instance.ClickCount);

            if (GameManager.Instance.ClickCount >= 10)
            {
                GameManager.Instance.ClickCount = 0;
                GameManager.Instance.BarCount++;
                _text.text = (GameManager.Instance.BarCount).ToString();
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
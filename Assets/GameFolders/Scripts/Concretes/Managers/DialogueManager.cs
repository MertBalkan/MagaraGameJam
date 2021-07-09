using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MagaraGameJam.Utilities.Patterns;

namespace MagaraGameJam.Concretes.Managers
{
    public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
    {
        [SerializeField] private TextMeshProUGUI _textDisplay;
        [SerializeField] private List<string> _sentences;
        [SerializeField] private float _typingSpeed;
        [SerializeField] private GameObject _countinueButton;

        private int _index;
        
        private void Awake()
        {
            SingletonObject(this);
        }
        
        private void Start()
        {
            StartCoroutine(Type());
        }

        private void Update()
        {
            if (_textDisplay.text == _sentences[_index])
            {
                _countinueButton.SetActive(true);
            }
        }

        private IEnumerator Type()
        {
            foreach (char letter in _sentences[_index].ToCharArray())
            {
                _textDisplay.text += letter;
                yield return new WaitForSeconds(_typingSpeed);
            }
        }

        public void NextSentence()
        {
            _countinueButton.SetActive(false);
            if (_index < _sentences.Count - 1)
            {
                _index++;
                _textDisplay.text = "";
                StartCoroutine(Type());
            }
            else
            {
                _textDisplay.text = "";
                _countinueButton.SetActive(false);
            }
        }
    }
}
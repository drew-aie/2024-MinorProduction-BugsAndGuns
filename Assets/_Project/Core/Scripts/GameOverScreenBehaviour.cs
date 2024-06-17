using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreenBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private PlayerLifeBehaviour _playerLifeBehaviour;

    private void Start()
    {
        _text.text = "";
    }
    private void Update()
    {
        if(_playerLifeBehaviour.Lives <= 0)
            _text.text = "You Goofed Up. Press Esc to quit or restart";
    }
}

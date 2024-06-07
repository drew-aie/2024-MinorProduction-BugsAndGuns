using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    static ScoreCounterBehaviour _instance = null;

    private int _currentScore = 0;

    private void Awake()
    {
        if (_instance == null)
            _instance = new ScoreCounterBehaviour();

        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    private void Update()
    {
        _text.text = "Current Score: " + _instance._currentScore;
    }

    public void AddScore(int value)
    {
        _instance._currentScore += value;
    }

}

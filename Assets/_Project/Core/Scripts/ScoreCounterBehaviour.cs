using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _currentScore = 0;

    private void Update()
    {
        _text.text = "Current Score: " + _currentScore;
    }

    public void AddScore(int value)
    {
        _currentScore += value;
    }
}

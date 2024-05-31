using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private int _currentScore;

    public void Start()
    {
        _text.text = "Current Score:" + _currentScore;
    }

    public void AddScore(int value)
    {
        _currentScore += value;
    }
}

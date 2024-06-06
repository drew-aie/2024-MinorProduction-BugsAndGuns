using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField] private int _pointValue;

    [SerializeField] static ScoreCounterBehaviour _scoreCounter;

    private void OnDestroy()
    {
        _scoreCounter.AddScore(_pointValue);
    }
}

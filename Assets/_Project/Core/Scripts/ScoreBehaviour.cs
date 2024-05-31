using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    [SerializeField] private int _pointValue;

    [SerializeField] private ScoreCounterBehaviour _scoreCounter;

    private void OnDestroy()
    {
        _scoreCounter.AddScore(_pointValue);
    }
}

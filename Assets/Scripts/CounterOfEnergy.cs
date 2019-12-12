using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterOfEnergy : MonoBehaviour
{
    int _score = 0;

    [SerializeField]
    Text _textScore;

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            if(value>0)
                _score = value;
            else
            {
                _score = 0;
            }
        }
    }
    
    private void Start()
    {
        Meteor.gainScore += GainScore;
        Meteor.loseScore += LoseScore;
        _textScore.text = Score.ToString();
    }

    public void GainScore(int score)
    {
        Score += score;
        _textScore.text = Score.ToString();
    }

    void LoseScore(int score)
    {
        Score -= score;
        _textScore.text = Score.ToString();
    }
}

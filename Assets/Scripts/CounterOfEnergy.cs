using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterOfEnergy : MonoBehaviour
{
    int _score;
    
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
        
    }

    public void GainScore(int score)
    {
        Score += score;
    }

    void LoseScore(int score)
    {
        Score -= score;
    }
}

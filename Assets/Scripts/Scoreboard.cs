using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
  
    public void IncreaseScore(int scoreToIncrease)
    {
        score += scoreToIncrease;
        Debug.Log(score);
    }
}

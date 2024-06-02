using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int ScoreValue {get; private set;}
    public void ResetScore(){
        ScoreValue = 0;
    }
    public void IncrementScore(){
        ScoreValue++;
    }
}

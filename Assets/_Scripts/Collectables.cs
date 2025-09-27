using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public string nameCollectable;
    public int score;
    public int restoreHP;

    public Collectables (string name, int scoreValue, int restoreHPValue)
    {
        this.nameCollectable = name;
        this.score = scoreValue;
    }

    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

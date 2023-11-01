using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreUI;
    int totalscore = 0;

    private void Awake()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }
        scoreUI.text = "Score: 0";
    }

    public void UpdateScore(int score)
    {
        totalscore += score;
        scoreUI.text = "Score: " + totalscore.ToString();
        if(totalscore == 10)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var enemyNum = enemies.Length;
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
   

        }
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

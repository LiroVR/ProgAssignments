using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int score;
    Collectables point;

    private void Awake()
    {
        point = new Collectables("Point", 1, 0);
    }

    [SerializeField] private Text _text;
    private void OnCollisionEnter(Collision collision) //This will run upon collision
    {
        if (collision.gameObject.tag == "Player")
        {
            point.UpdateScore();
            Destroy(gameObject);
        }
        //Destroy(this.gameObject); //Gets rid of the game object upon collision
        //score += 1; //Adds one to the score
        //_text.text = $"Score: {score}"; //Outputs the score to the UI
        //if(score == 10)
        //{
            //var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //var enemyNum = enemies.Length;
            //foreach (var enemy in enemies)
            //{
                //Destroy(enemy);
            //}
   

        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int score;
    [SerializeField] private Text _text;
    private void OnCollisionEnter(Collision collision) //This will run upon collision
    {
        Destroy(this.gameObject); //Gets rid of the game object upon collision
        score += 1; //Adds one to the score
        _text.text = $"Score: {score}"; //Outputs the score to the UI
    }
}

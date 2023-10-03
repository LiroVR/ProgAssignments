using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public static int score;
    [SerializeField] private Text _text;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        score += 1;
        _text.text = $"Score: {score}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class writeLine : MonoBehaviour
{
    [SerializeField] private int age = 21;
    [SerializeField] private string name = "Lucas";
    // Start is called before the first frame update
    void Start()
    {
        var outputString = ("Hi {0}, you are {1} years old", name, age);
        Debug.Log(outputString);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

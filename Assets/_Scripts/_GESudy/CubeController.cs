using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    private Color startColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    public void ToggleRed()
    {
        rend.material.color = Color.red;
    }
    public void ToggleBlue()
    {
        rend.material.color = Color.blue;
    }
    public void ToggleGreen()
    {
        rend.material.color = Color.green;
    }

    public void ResetColor()
    {
        rend.material.color = startColor;
    }
}

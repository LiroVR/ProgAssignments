using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetColor : GECommand
{
    private CubeController cubeController;
    public ResetColor(CubeController controller)
    {
        cubeController = controller;
    }
    public override void Execute()
    {
        cubeController.ResetColor();
    }
    
}

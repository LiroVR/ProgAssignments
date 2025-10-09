using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGreen : GECommand
{
    private CubeController cubeController;
    public ToggleGreen(CubeController controller)
    {
        cubeController = controller;
    }
    public override void Execute()
    {
        cubeController.ToggleGreen();
    }
    
}

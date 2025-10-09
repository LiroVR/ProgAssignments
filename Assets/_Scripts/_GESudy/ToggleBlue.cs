using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBlue : GECommand
{
    private CubeController cubeController;
    public ToggleBlue(CubeController controller)
    {
        cubeController = controller;
    }
    public override void Execute()
    {
        cubeController.ToggleBlue();
    }
    
}

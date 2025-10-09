using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRed : GECommand
{
    private CubeController cubeController;
    public ToggleRed(CubeController controller)
    {
        cubeController = controller;
    }
    public override void Execute()
    {
        cubeController.ToggleRed();
    }
    public override void Undo()
    {
    }
    
}

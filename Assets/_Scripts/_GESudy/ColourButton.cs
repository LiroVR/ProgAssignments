using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourButton : MonoBehaviour
{
    private CubeController cubeController;
    private GEInvoker invoker;
    private Command toggleRedCommand, toggleBlueCommand, toggleGreenCommand;
    void Start()
    {
        toggleRedCommand = new ToggleRed(cubeController);
        toggleBlueCommand = new ToggleBlue(cubeController);
        toggleGreenCommand = new ToggleGreen(cubeController);
        invoker = findObjectOfType<GEInvoker>();
    }

    public void RedButton()
    {
        invoker.ExecuteCommand(toggleRedCommand);
    }
    public void BlueButton()
    {
        invoker.ExecuteCommand(toggleBlueCommand);
    }
    public void GreenButton()
    {
        invoker.ExecuteCommand(toggleGreenCommand);
    }

    public void UndoButton()
    {
        invoker.UndoCommand();
    }
}

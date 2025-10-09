using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GEInvoker : MonoBehaviour
{

    private Stack<GECommand> commandList = new Stack<GECommand>();
    private GECommand resetColor;

    void Start()
    {
        CubeController cubeController = GetComponent<CubeController>();
        resetColor = new ResetColor(cubeController);
    }


    public void ExecuteCommand(GECommand command)
    {
        commandList.Push(command);
        command.Execute();
    }

    public void UndoCommand()
    {
        if (commandList.Count > 0)
        {
            commandList.Pop();
            if (commandList.Count == 0)
            {
                resetColor.Execute();
                return;
            }
            GECommand command = commandList.Peek();
            command.Execute();
        }
    }
}

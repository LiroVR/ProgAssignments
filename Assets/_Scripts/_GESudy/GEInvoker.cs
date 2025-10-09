using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GEInvoker : MonoBehaviour
{

    private SortedSet<GECommand> commandList = new SortedSet<GECommand>();


    public void ExecuteCommand(GECommand command)
    {
        commandList.Add(command);
        command.Execute();
    }

    public void UndoCommand()
    {
        if (commandList.Count > 0)
        {
            commandList.pop();
            GECommand command = commandList.Last();
            command.Execute();
        }
    }
}

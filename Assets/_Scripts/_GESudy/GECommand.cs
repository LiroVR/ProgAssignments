using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GECommand
{
    public abstract void Execute();
    public abstract void Undo();

}

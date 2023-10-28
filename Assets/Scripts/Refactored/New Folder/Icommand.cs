using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Icommand
{
    public abstract void Execute(Vector3 point);
}
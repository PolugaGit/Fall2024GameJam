using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFlying : IState
{
    private FishReferences fR;

    public FFlying(FishReferences fishReferences)
    {
        this.fR = fishReferences;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }

    public bool To_Swimming()
    {
        // TODO Implement to swimming logic
        return false;
    }
}

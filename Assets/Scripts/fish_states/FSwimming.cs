using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSwimming : IState
{
    private FishReferences fR;

    public FSwimming(FishReferences fishReferences) {
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

    public bool To_Flying() {
        // TODO Implement to swimming logic
        return false;
    }
}

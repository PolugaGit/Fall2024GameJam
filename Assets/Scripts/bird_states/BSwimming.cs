using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSwimming : IState
{
    private BirdReferences bR;

    public BSwimming(BirdReferences birdReferences)
    {
        this.bR = birdReferences;
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

    public bool To_Flying()
    {
        // TODO Implement to swimming logic
        return false;
    }
}

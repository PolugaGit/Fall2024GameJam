using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFlying : IState
{
    private BirdReferences bR;

    public BFlying(BirdReferences birdReferences) {
        this.bR = birdReferences;
    }

    public void OnEnter() {

    }

    public void OnExit() {

    }

    public void Tick() {

    }

    public bool To_Swimming() {
        // TODO Implement to swimming logic
        return false;
    }
}

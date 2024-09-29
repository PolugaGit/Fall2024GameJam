using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAirCombo : IState
{
    private FishReferences fR;

    public FAirCombo(FishReferences fishReferences)
    {
        this.fR = fishReferences;
    }

    public void OnEnter()
    {
        fR.rb.velocity = new Vector2(0, fR.rb.velocity.y + 1/2);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }

    public bool To_Flying() {
        return true;
    }
}

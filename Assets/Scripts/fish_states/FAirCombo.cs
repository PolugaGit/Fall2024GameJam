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
        fR.rb.velocity = new Vector2(0, 6);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y - (Time.deltaTime * fR.air_deceleration * 3), -fR.max_vertical_velocity, fR.max_vertical_velocity));
        }
        fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y - (Time.deltaTime * fR.air_deceleration), -fR.max_vertical_velocity, fR.max_vertical_velocity));
    }

    public bool To_Swimming()
    {
        if (fR.transform.position.y < 0)
        {
            return true;
        }
        return false;
    }
}

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
        bR.ChangeAnimationState("Swimming");
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.W))
        {
            bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y + (Time.deltaTime * bR.water_deceleration * 2), -bR.max_vertical_velocity, bR.max_vertical_velocity));
        }
        bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y + (Time.deltaTime * bR.water_deceleration), -bR.max_vertical_velocity, bR.max_vertical_velocity));
    }

    public bool To_Flying()
    {
        if (bR.transform.position.y > 0)
        {
            return true;
        }
        return false;
    }

    public bool To_Combo_Water()
    {
        if (bR.can_combo == true && Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }
}

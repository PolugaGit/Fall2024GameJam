using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWaterCombo : IState
{
    private BirdReferences bR;

    public BWaterCombo(BirdReferences birdReferences)
    {
        this.bR = birdReferences;
    }

    public void OnEnter()
    {
        bR.rb.velocity = new Vector2(0, -7);
        UnityEngine.Debug.Log("Entered Bird Combo");
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y + (Time.deltaTime * bR.water_deceleration * 3), -bR.max_vertical_velocity, bR.max_vertical_velocity));
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
    public bool To_Damaged() {
        if (bR.is_damaged)
        {
            return true;
        }
        return false;
    }
}

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
        fR.rb.velocity = new Vector2(0, 7);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        if (fR.transform.position.x < -5)
        {
            fR.transform.position += new Vector3(2 * Time.deltaTime, 0f, 0f);
        }
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

    public bool To_Damaged()
    {
        if (fR.is_damaged)
        {
            return true;
        }
        return false;
    }
}

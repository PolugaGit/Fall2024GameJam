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
      fR.ChangeAnimationState("F_Swimming");
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (fR.rb.velocity.y < 0)
            {
                fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y + (fR.vertical_acceleration * Time.deltaTime) + fR.deceleration * Time.deltaTime, -fR.max_vertical_velocity, fR.max_vertical_velocity));
            }
            else
            {
                fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y + (fR.vertical_acceleration * Time.deltaTime), -fR.max_vertical_velocity, fR.max_vertical_velocity));
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (fR.rb.velocity.y > 0)
            {
                fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y - (fR.vertical_acceleration * Time.deltaTime) - fR.deceleration * Time.deltaTime, -fR.max_vertical_velocity, fR.max_vertical_velocity));
            }
            else
            {
                fR.rb.velocity = new Vector2(0, Mathf.Clamp(fR.rb.velocity.y - (fR.vertical_acceleration * Time.deltaTime), -fR.max_vertical_velocity, fR.max_vertical_velocity));
            }
        }
        else
        {
            if (fR.rb.velocity.y > 0.2)
            {
                fR.rb.velocity = new Vector2(0, fR.rb.velocity.y - (fR.deceleration * Time.deltaTime));

            }
            else if (fR.rb.velocity.y < -0.2)
            {
                fR.rb.velocity = new Vector2(0, fR.rb.velocity.y + (fR.deceleration * Time.deltaTime));
            }
            else
            {
                fR.rb.velocity = new Vector2(0, 0);
            }
        }
    }

    public bool To_Flying() {
        if (fR.transform.position.y > 0)
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

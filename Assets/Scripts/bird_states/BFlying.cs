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
        bR.ChangeAnimationState("Flying");
    }

    public void OnExit() {

    }

    public void Tick() {
        if (bR.transform.position.x < -5)
        {
            bR.transform.position += new Vector3(2 * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (bR.rb.velocity.y < 0) {
                bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y + (bR.vertical_acceleration * Time.deltaTime) + bR.deceleration * Time.deltaTime, -bR.max_vertical_velocity, bR.max_vertical_velocity));
            } else {
                bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y + (bR.vertical_acceleration * Time.deltaTime), -bR.max_vertical_velocity, bR.max_vertical_velocity));
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (bR.rb.velocity.y > 0)
            {
                bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y - (bR.vertical_acceleration * Time.deltaTime) - bR.deceleration * Time.deltaTime, -bR.max_vertical_velocity, bR.max_vertical_velocity));
            }
            else
            {
                bR.rb.velocity = new Vector2(0, Mathf.Clamp(bR.rb.velocity.y - (bR.vertical_acceleration * Time.deltaTime), -bR.max_vertical_velocity, bR.max_vertical_velocity));
            }
        }
        else
        {
            if (bR.rb.velocity.y > 0.2)
            {
                bR.rb.velocity = new Vector2(0, bR.rb.velocity.y - (bR.deceleration * Time.deltaTime));

            }
            else if (bR.rb.velocity.y < -0.2)
            {
                bR.rb.velocity = new Vector2(0, bR.rb.velocity.y + (bR.deceleration * Time.deltaTime));
            }
            else
            {
                bR.rb.velocity = new Vector2(0,0);
            }
        }
    }

    public bool To_Swimming() {
        if (bR.transform.position.y < 0)
        {
            return true;
        }
        return false;
    }

    public bool To_Damaged() {
        if (bR.is_damaged) {
            return true;
        }
        return false;
    }
}

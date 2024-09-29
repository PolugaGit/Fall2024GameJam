using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFlying : IState
{
    private FishReferences fR;

    public FFlying(FishReferences fishReferences) {
        this.fR = fishReferences;
    }

    public void OnEnter()
    {
      fR.ChangeAnimationState("F_Flying");
    }

    public void OnExit()
    {

    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.DownArrow)) {
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

    public bool To_Combo_Air() {
        if (fR.can_combo == true && Input.GetKey(KeyCode.Return)) {
            return true;
        }
        return false;
    }
}

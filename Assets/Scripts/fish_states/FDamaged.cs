using UnityEngine;
using System.Collections;

public class FDamaged : IState
{
    private float timer;
    private FishReferences fR;

    public FDamaged(FishReferences fishReferences)
    {
        this.fR = fishReferences;
    }

    public void OnEnter()
    {
        timer = 0;
        fR.rb.velocity = new Vector2(-8, 0);
        if (fR.transform.position.y < 0)
        {
            fR.ChangeAnimationState("Damaged_Swimming");
        }
        else
        {
            fR.ChangeAnimationState("Damaged_Flying");
        }
    }

    public void OnExit()
    {
        fR.is_damaged = false;
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (fR.rb.velocity.x < 0)
        {
            fR.rb.velocity = new Vector2(fR.rb.velocity.x + 16 * Time.deltaTime, 0);
        }
        else
        {
            fR.rb.velocity = new Vector2(0, 0);
        }
    }

    public bool To_Swimming()
    {
        if (timer > 0.5 && fR.transform.position.y < 0)
        {
            return true;
        }
        return false;
    }

    public bool To_Flying()
    {
        if (timer > 0.5 && fR.transform.position.y > 0)
        {
            return true;
        }
        return false;
    }
}

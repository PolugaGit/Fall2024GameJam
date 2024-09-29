using UnityEngine;
using System.Collections;

public class BDamaged : IState
{
    private float timer;
    private BirdReferences bR;

    public BDamaged(BirdReferences birdReferences) {
        this.bR = birdReferences;
    }

    public void OnEnter() {
        bR.rb.velocity = new Vector2(-8, 0);
        if (bR.transform.position.y < 0) {
            bR.ChangeAnimationState("Damaged_Swimming");
        } else {
            bR.ChangeAnimationState("Damaged_Flying");
        }
    }

    public void OnExit() {

    }

    public void Tick() {
        timer += Time.deltaTime;
        if (bR.rb.velocity.x < 0) {
            bR.rb.velocity = new Vector2(bR.rb.velocity.x + 16 * Time.deltaTime, 0);
        }
        else {
            bR.rb.velocity = new Vector2(0,0);
        }
    }

    public bool To_Swimming() {
        if (timer > 0.5 && bR.transform.position.y < 0) {
            return true;
        }
        return false;
    }

    public bool To_Flying() {
        if (timer > 0.5 && bR.transform.position.y > 0)
        {
            return true;
        }
        return false;
    }
}

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
        bR.rb.velocity = new Vector2(-4, 0);
    }

    public void OnExit() {

    }

    public void Tick() {
        timer += Time.deltaTime;
        if (bR.rb.velocity.x < 0) {
            bR.rb.velocity = new Vector2(bR.rb.velocity.x + 4 * Time.deltaTime, 0);
        }
        else {
            bR.rb.velocity = new Vector2(0,0);
        }
        UnityEngine.Debug.Log(timer);
    }

    public bool To_Swimming() {
        if (timer > 0.3 && bR.transform.position.y < 0) {
            return true;
        }
        return false;
    }

    public bool To_Flying() {
        if (timer > 0.3 && bR.transform.position.y > 0)
        {
            return true;
        }
        return false;
    }
}

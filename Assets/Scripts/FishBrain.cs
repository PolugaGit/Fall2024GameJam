using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishBrain : MonoBehaviour
{
    private FishReferences fR;
    private StateMachine _stateMachine;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        fR = GetComponent<FishReferences>();
        _stateMachine = new StateMachine();

        // STATES
        var Swimming = new FSwimming(fR);
        var Flying = new FFlying(fR);
        var AirCombo = new FAirCombo(fR);

        // TRANSITIONS
        At(Flying, Swimming, () => Flying.To_Swimming());
        At(Flying, AirCombo, () => Flying.To_Combo_Air());
        At(AirCombo, Swimming, () => AirCombo.To_Swimming());
        At(Swimming, Flying, () => Swimming.To_Flying());

        //START STATE
        _stateMachine.SetState(Swimming);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        // void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        angle = fR.rb.velocity.y * (45 / fR.max_vertical_velocity);
        fR.transform.eulerAngles = new Vector3(0, 0, angle);
        _stateMachine.Tick();
    }
}

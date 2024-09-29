using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BirdBrain : MonoBehaviour
{
    private BirdReferences bR;
    private StateMachine _stateMachine;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        bR = GetComponent<BirdReferences>();
        _stateMachine = new StateMachine();

        // STATES
        var Flying = new BFlying(bR);
        var Swimming = new BSwimming(bR);
        var WaterCombo = new BWaterCombo(bR);
        var Damaged = new BDamaged(bR);

        // TRANSITIONS
        At(Flying, Swimming, () => Flying.To_Swimming());
        At(Swimming, WaterCombo, () => Swimming.To_Combo_Water());
        At(WaterCombo, Swimming, () => WaterCombo.To_Flying());
        At(Swimming, Flying, () => Swimming.To_Flying());
        At(Swimming, Damaged, () => Swimming.To_Damaged());
        At(Flying, Damaged, () => Flying.To_Damaged());
        At(WaterCombo, Damaged, () => WaterCombo.To_Damaged());
        At(Damaged, Swimming, () => Damaged.To_Swimming());
        At(Damaged, Flying, () => Damaged.To_Flying());

        // START STATE
        _stateMachine.SetState(Flying);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        // void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        angle = bR.rb.velocity.y * (45 / bR.max_vertical_velocity);
        bR.transform.eulerAngles = new Vector3(0,0,angle);

        _stateMachine.Tick();
    }
}
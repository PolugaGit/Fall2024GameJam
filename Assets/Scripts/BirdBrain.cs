using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BirdBrain : MonoBehaviour
{
    private BirdReferences bR;
    private StateMachine _stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        bR = GetComponent<BirdReferences>();
        _stateMachine = new StateMachine();

        // STATES
        var Flying = new BFlying(bR);
        var Swimming = new BSwimming(bR);

        // TRANSITIONS
        At(Flying, Swimming, () => Flying.To_Swimming());
        At(Swimming, Flying, () => Swimming.To_Flying());

        // START STATE
        _stateMachine.SetState(Flying);

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        // void Any(IState to, Func<bool> condition) => stateMachine.AddAnyTransition(to, condition);
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }
}

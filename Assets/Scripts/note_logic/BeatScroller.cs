using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float tempo;
    public bool hasStarted;
    public float beatsPerSecond;
    public float noteSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        beatsPerSecond = tempo / 60f; // TODO: Have dependecy injected by song or level/game manager?. Constant for scaling
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(noteSpeed * beatsPerSecond * Time.deltaTime, 0f, 0f);
        }
    }
}

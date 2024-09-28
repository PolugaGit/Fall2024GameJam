using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float tempo;
    public bool hasStarted;
    public float beatsPerFrame;

    // Start is called before the first frame update
    void Start()
    {
        beatsPerFrame = tempo / 60f; // TODO: Have dependecy injected by song. Constant for scaling
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(beatsPerFrame * Time.deltaTime, 0f, 0f);
        }
        else
        {
            // TODO: Replace with menu button implement. For testing only
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasStarted = true;
            }
        }
    }
}

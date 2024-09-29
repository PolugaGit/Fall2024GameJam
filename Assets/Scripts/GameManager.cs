using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasStarted;
    public BeatScroller theBS;
    public NoteSpawner theNS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            theBS.hasStarted = true;
            theNS.hasStarted = true;

        }
    }
}

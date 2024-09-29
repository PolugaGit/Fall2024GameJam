using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool hasStarted;
    public BeatScroller theBS;
    public NoteSpawner theNS;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;

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

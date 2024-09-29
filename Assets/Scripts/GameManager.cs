using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool hasStarted;
    public BeatScroller theBS;
    public NoteSpawner theNS;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasStarted;

    public AudioSource music;
    public BeatScroller theBS;
    public NoteSpawner theNS;

    public int scorePerNote = 100;
    public int[] multiplierThresholds;

    public int birdScore;
    public int fishScore;
    public int birdMultiplier;
    public int fishMultiplier;

    public int birdMultTracker;
    public int fishMultTracker;

    public TextMeshProUGUI birdScoreText;
    public TextMeshProUGUI fishScoreText;
    public TextMeshProUGUI birdMultText;
    public TextMeshProUGUI fishMultText;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        birdMultiplier = 1;
        fishMultiplier = 1;

        birdScoreText.text = "Score: 0";
        fishScoreText.text = "Score: 0";
        birdMultText.text = "Mult: 1x";
        fishMultText.text = "Mult: 1x";
    }

    // Update is called once per frame
    void Update()
    {

        // Remove to make autostart when button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            theBS.hasStarted = true;
            theNS.hasStarted = true;

        }
    }

    public void NoteHit(string player)
    {
        Debug.Log("Hit!"); // REMOVE: When score text is implemented
        player = player.Substring(0, 4);
        if (player.Equals("Bird"))
        {
            if (birdMultiplier < multiplierThresholds.Length + 1)
            {
                birdMultTracker++;

                if (birdMultTracker >= multiplierThresholds[birdMultiplier - 1])
                {
                    birdMultTracker = 0;
                    birdMultiplier++;
                    birdMultText.text = getMultText(birdMultiplier);
                }
            }

            birdScore += scorePerNote * birdMultiplier;
            birdScoreText.text = "Score: " + birdScore;
        }

        if (player.Equals("Fish"))
        {
            if (fishMultiplier < multiplierThresholds.Length + 1)
            {
                fishMultTracker++;

                if (fishMultTracker >= multiplierThresholds[fishMultiplier - 1])
                {
                    fishMultTracker = 0;
                    fishMultiplier++;
                    fishMultText.text = getMultText(fishMultiplier);
                }
            }

            fishScore += scorePerNote * fishMultiplier;
            fishScoreText.text = "Score: " + fishScore;
        }
    }

    public void NoteMiss(string player)
    {
        //Debug.Log("Miss");
        player = player.Substring(0, 4); // Determines if Bird or Fish

        if (player.Equals("Bird"))
        {
            birdMultiplier = 1; // May change to drop instead of 1x
            fishMultTracker = 0;
            birdMultText.text = getMultText(birdMultiplier);
        }

        if (player.Equals("Fish"))
        {
            fishMultiplier = 1; // Ditto
            fishMultTracker = 0;
            fishMultText.text = getMultText(fishMultiplier);
        }
    }

    private string getMultText(int multiplier)
    {
        return "Mult: " + multiplier + "x";
    }
}

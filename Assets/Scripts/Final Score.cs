using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI birdScore1;
    public TextMeshProUGUI birdScore2;
    public TextMeshProUGUI birdScore3;

    public TextMeshProUGUI fishScore1;
    public TextMeshProUGUI fishScore2;
    public TextMeshProUGUI fishScore3;

    public TextMeshProUGUI finalScore;

    // Start is called before the first frame update
    void Start()
    {
        int[] scores = GameManager.persistenceScore;
        birdScore1.text = "1: " + scores[0];
        birdScore2.text = "2: " + scores[2];
        birdScore3.text = "3: " + scores[4];

        fishScore1.text = "1: " + scores[1];
        fishScore2.text = "2: " + scores[3];
        fishScore3.text = "3: " +  scores[5];

        finalScore.text = "Final Score: " + (scores[0] + scores[1] + scores[2] + scores[3] + scores[4] + scores[5]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    private int beat; // Currently int, but implement sub quarter notes as TODO
    private ArrayList beatMap;
    public TextAsset level;
    private int testindex; // TEST: remove later
    private int totalBeats;

    // Start is called before the first frame update
    void Start()
    {
        beatMap = new ArrayList();
        parseMap(level.text);
        totalBeats = beatMap.Count; // Used for testing right now, but can be useful for other

        //TEST: Checking parsing of level.txt file
        //if (testindex < totalBeats)
        //{
        //    HashSet<NotePosition> positions = (HashSet<NotePosition>)beatMap[testindex];
        //    Debug.Log(positions);
        //    foreach (NotePosition position in positions)
        //    {
        //        Debug.Log(position.ToString());
        //    }
        //    testindex++;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Create note based on beat
    }

    private void parseMap(string level)
    {
        string[] beats = level.Split("\n"); // Splits by beat

        foreach (string beat in beats)
        {   
            string[] notes = beat.Split(','); // Splits to read each pitch of a beat
            HashSet<NotePosition>  pitches = new HashSet<NotePosition>();

            foreach (string note in notes)
            {
                if (note.Equals("none"))
                {
                    pitches.Add(NotePosition.None);
                    break;
                }
                // Unsafe. Not checking for None + NotePosition
                switch(note)
                {
                    case "Top":
                        pitches.Add(NotePosition.Top);
                        break;
                    case "BirdMidTop":
                        pitches.Add(NotePosition.BirdMid);
                        break;
                    case "BirdMidBottom":
                        pitches.Add(NotePosition.BirdMid);
                        break;
                    case "FishMidTop":
                        pitches.Add(NotePosition.FishMid);
                        break;
                    case "FishMidBottom":
                        pitches.Add(NotePosition.FishMid);
                        break;
                    case "Bottom":
                        pitches.Add(NotePosition.Bottom);
                        break;
                }
            }

            beatMap.Add(pitches);
        }
    }
}

enum NotePosition
{
    Top,
    BirdMidTop,
    BirdMidBottom,
    FishMidTop,
    FishMidBottom,
    Bottom,
    None
}

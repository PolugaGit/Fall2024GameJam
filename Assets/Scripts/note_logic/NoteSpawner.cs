using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject NoteHolderObject;
    private BeatScroller beatScroller;
    private Transform noteHolder;
    public bool hasStarted;

    public GameObject birdNotePrefab;
    public GameObject fishNotePrefab;
    public float spawnDistance;

    public float topHeight;
    public float midTopHeight;
    public float midBottomHeight;
    public float bottomHeight;

    private float time;
    private int beat; // Currently int, but implement sub quarter notes as TODO
    private float beatTime;

    private ArrayList beatMap;
    public TextAsset level;

    private int testindex; // TEST: remove later
    private int totalBeats;

    // Start is called before the first frame update
    void Start()
    {
        beatScroller = NoteHolderObject.GetComponent<BeatScroller>();
        noteHolder = beatScroller.transform;

        time = 0f;
        beat = 0;
        beatMap = new ArrayList();
        parseMap(level.text);
        totalBeats = beatMap.Count;

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
        beatTime = 1f / beatScroller.beatsPerSecond;
        if (hasStarted) { 
            time += Time.deltaTime;
            //Debug.Log(beatTime);
            if (time >= beatTime && beat < totalBeats)
            {
                spawnNote(beat);
                beat++;
                time = 0f;
            }
        }
    }

    // Mark Bird or Fish
    private void spawnNote(int beat)
    {
        HashSet<NotePosition> notesToSpawn = (HashSet<NotePosition>) beatMap[beat];

        foreach (NotePosition notePosition in notesToSpawn)
        {
            switch (notePosition)
            {
                case NotePosition.Top:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, topHeight, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.BirdMidTop:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, midTopHeight, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.BirdMidBottom:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, midBottomHeight, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishMidTop:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, midTopHeight, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishMidBottom:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, midBottomHeight, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.Bottom:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, bottomHeight, 0f), Quaternion.identity, noteHolder);
                    break;
            }
        }
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
                // Unsafe. Not checking for None + NotePosition so assume not an issue
                switch (note)
                {
                    case "Top":
                        pitches.Add(NotePosition.Top);
                        break;
                    case "BirdMidTop":
                        pitches.Add(NotePosition.BirdMidTop);
                        break;
                    case "BirdMidBottom":
                        pitches.Add(NotePosition.BirdMidBottom);
                        break;
                    case "FishMidTop":
                        pitches.Add(NotePosition.FishMidTop);
                        break;
                    case "FishMidBottom":
                        pitches.Add(NotePosition.FishMidBottom);
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

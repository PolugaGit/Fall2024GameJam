using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject NoteHolderObject;
    private BeatScroller beatScroller;
    private Transform noteHolder;
    public bool hasStarted;

    public GameObject birdNotePrefab;
    public GameObject fishNotePrefab;
    public GameObject waterObstaclePrefab;
    public GameObject airObstaclePrefab;
    public float spawnDistance;

    public float skyTop;
    public float skyMid;
    public float skyBottom;
    public float seaTop;
    public float seaMid;
    public float seaBottom;

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
        ParseMap(level.text);
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
                case NotePosition.BirdSkyTop:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, skyTop, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishSkyTop:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, skyTop, 0f), Quaternion.identity, noteHolder); // New prefab? Special Note
                    break;
                case NotePosition.BirdSkyMid:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, skyMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishSkyMid:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, skyMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.BirdSkyBottom:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, skyBottom, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishSkyBottom:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, skyBottom, 0f), Quaternion.identity, noteHolder);
                    break;

                case NotePosition.BirdSeaTop:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, seaTop, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishSeaTop:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, seaTop, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.BirdSeaMid:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, seaMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.FishSeaMid:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, seaMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.BirdSeaBottom:
                    Instantiate(birdNotePrefab, new Vector3(spawnDistance, seaBottom, 0f), Quaternion.identity, noteHolder); // New prefab? Special Note
                    break;
                case NotePosition.FishSeaBottom:
                    Instantiate(fishNotePrefab, new Vector3(spawnDistance, seaBottom, 0f), Quaternion.identity, noteHolder);
                    break;

                case NotePosition.ObstacleSkyTop:
                    Instantiate(airObstaclePrefab, new Vector3(spawnDistance, skyTop, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.ObstacleSkyMid:
                    Instantiate(airObstaclePrefab, new Vector3(spawnDistance, skyMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.ObstacleSkyBottom:
                    Instantiate(airObstaclePrefab, new Vector3(spawnDistance, skyBottom, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.ObstacleSeaTop:
                    Instantiate(waterObstaclePrefab, new Vector3(spawnDistance, seaTop, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.ObstacleSeaMid:
                    Instantiate(waterObstaclePrefab, new Vector3(spawnDistance, seaMid, 0f), Quaternion.identity, noteHolder);
                    break;
                case NotePosition.ObstacleSeaBottom:
                    Instantiate(waterObstaclePrefab, new Vector3(spawnDistance, seaBottom, 0f), Quaternion.identity, noteHolder);
                    break;
            }
        }
    }

    private void ParseMap(string level)
    {
        string[] beats = level.Split("\n"); // Splits by beat

        foreach (string beat in beats)
        {   
            string[] notes = beat.Split(','); // Splits to read each pitch of a beat
            HashSet<NotePosition>  pitches = new HashSet<NotePosition>();

            foreach (string note in notes)
            {
                if (note.Equals("R"))
                {
                    pitches.Add(NotePosition.Rest);
                    break;
                }
                if (note.Contains("o"))
                {
                    Debug.Log("obstacle detect");
                    pitches.Add(ObstaclePosition(note));
                }
                // Unsafe. Not checking for None + NotePosition so assume not an issue
                switch (note)
                {
                    case "bst":
                    case "BirdSkyTop":
                        pitches.Add(NotePosition.BirdSkyTop);
                        break;
                    case "bsm":
                    case "BirdSkyMid":
                        pitches.Add(NotePosition.BirdSkyMid);
                        break;
                    case "bsb":
                    case "BirdSkyBottom":
                        pitches.Add(NotePosition.BirdSkyBottom);
                        break;
                    case "fst":
                    case "FishSkyTop":
                        pitches.Add(NotePosition.FishSkyTop);
                        break;
                    case "fsm":
                    case "FishSkyMid":
                        pitches.Add(NotePosition.FishSkyMid);
                        break;
                    case "fsb":
                    case "FishSkyBottom":
                        pitches.Add(NotePosition.FishSkyBottom);
                        break;

                    case "bct":
                    case "BirdSeaTop":
                        pitches.Add(NotePosition.BirdSeaTop);
                        break;
                    case "bcm":
                    case "BirdSeaMid":
                        pitches.Add(NotePosition.BirdSeaMid);
                        break;
                    case "bcb":
                    case "BirdSeaBottom":
                        pitches.Add(NotePosition.BirdSeaBottom);
                        break;
                    case "fct":
                    case "FishSeaTop":
                        pitches.Add(NotePosition.FishSeaTop);
                        break;
                    case "fcm":
                    case "FishSeaMid":
                        pitches.Add(NotePosition.FishSeaMid);
                        break;
                    case "fcb":
                    case "FishSeaBottom":
                        pitches.Add(NotePosition.FishSeaBottom);
                        break;
                }
            }

            beatMap.Add(pitches);
        }
    }

    private NotePosition ObstaclePosition(string obstacle)
    {
        string level = obstacle.Substring(1, 1);
        switch (level)
        {
            case "1":
                return NotePosition.ObstacleSkyTop;
            case "2":
                return NotePosition.ObstacleSkyMid;
            case "3":
                return NotePosition.ObstacleSkyBottom;
            case "4":
                return NotePosition.ObstacleSeaTop;
            case "5":
                return NotePosition.ObstacleSeaMid;
            case "6":
                return NotePosition.ObstacleSeaBottom;
            default:
                Debug.Log("Object Level not available");
                return NotePosition.Rest; // Bandaid. Up to level designer to not violate cases
        }

    }
}


enum NotePosition
{
    BirdSkyTop,
    BirdSkyMid,
    BirdSkyBottom,
    BirdSeaTop,
    BirdSeaMid,
    BirdSeaBottom,
    FishSkyTop,
    FishSkyMid,
    FishSkyBottom,
    FishSeaTop,
    FishSeaMid,
    FishSeaBottom,
    ObstacleSkyTop,
    ObstacleSkyMid,
    ObstacleSkyBottom,
    ObstacleSeaTop,
    ObstacleSeaMid,
    ObstacleSeaBottom,
    Rest,

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    private int beat; // Currently int, but implement sub quarter notes as TODO
    public int[] beatMap; // Mapping note spawn as enum

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

enum NotePosition
{
    Top,
    BirdMid,
    FishMid,
    Bottom,
    None
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //private KeyCode rhythmKey;
    //public bool isClearable;
    //public string playerTag;
    public float clearLine = -8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        if (transform.position.x < clearLine)
        {
            Destroy(gameObject);
            Debug.Log("Miss!");
        }

    }
}

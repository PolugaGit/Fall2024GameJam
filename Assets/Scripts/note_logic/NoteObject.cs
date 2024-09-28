using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private KeyCode rhythmKey;
    public bool isClearable;
    public string playerTag;

    // Start is called before the first frame update
    void Start()
    {
        if (playerTag.Equals("BirdPlayer"))
        {
            rhythmKey = KeyCode.D;
        }
        if (playerTag.Equals("FishPlayer"))
        {
            rhythmKey = KeyCode.RightArrow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rhythmKey))
        {
            if (isClearable)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Note hittable");
            isClearable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Note misssed");
            isClearable = false;
        }
    }
}

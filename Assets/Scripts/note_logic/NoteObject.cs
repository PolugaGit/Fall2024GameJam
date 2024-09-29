using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    private KeyCode rhythmKey;
    public bool isClearable;
    public string playerTag;
    public float clearLine = -2f;

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
                Debug.Log("Hit!");
            }
        }
        
        if (transform.position.x < clearLine)
        {
            Destroy(gameObject);
            Debug.Log("Miss!");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isClearable = true;
        }
    }

    // TODO: Replace with a destroy method that counts a miss and destroys the note
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isClearable = false;
        }
    }
}

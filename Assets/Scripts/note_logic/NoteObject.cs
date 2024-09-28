using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public KeyCode rhythmKey;
    public bool isClearable;
    public string playerTag; // TODO: Replace with generic or make two classes inheriting from NoteObject or implement from playerside
                                            // Probably best to refactor and implement from player side as Destroy(other.gameObject)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rhythmKey))
        {
            if (isClearable)
            {
                gameObject.SetActive(false);
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

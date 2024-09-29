using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "fish")
        {
            GameManager.instance.fishMultiplier = 1;
            GameManager.instance.fishMultTracker = 0;
            FishReferences R = other.GetComponent<FishReferences>();
            R.is_damaged = true;
        }
        else if (other.name == "bird")
        {
            GameManager.instance.birdMultiplier = 1;
            GameManager.instance.birdMultTracker = 0;
            BirdReferences R = other.GetComponent<BirdReferences>();
            R.is_damaged = true;
        }
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "fish")
        {
            FishReferences R = other.GetComponent<FishReferences>();
            R.is_damaged = false;
        }
        else if (other.name == "bird")
        {
            BirdReferences R = other.GetComponent<BirdReferences>();
            R.is_damaged = false;
        }
    }
}

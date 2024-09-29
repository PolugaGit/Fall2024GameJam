using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(10 * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "fish")
        {
            FishReferences R = other.GetComponent<FishReferences>();
            R.is_damaged = true;
        }
        else if (other.name == "bird")
        {
            BirdReferences R = other.GetComponent<BirdReferences>();
            R.is_damaged = true;
        }
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

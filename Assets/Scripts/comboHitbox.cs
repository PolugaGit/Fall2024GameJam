using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "fish") {
            FishReferences R = other.GetComponent<FishReferences>();
            R.can_combo = true;
            UnityEngine.Debug.Log("Fish can Combo");
        }
        else if (other.name == "bird") {
            BirdReferences R = other.GetComponent<BirdReferences>();
            R.can_combo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name == "fish")
        {
            FishReferences R = other.GetComponent<FishReferences>();
            R.can_combo = false;
        }
        else if (other.name == "bird")
        {
            BirdReferences R = other.GetComponent<BirdReferences>();
            R.can_combo = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReferences : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Transform transform;
    public float vertical_acceleration;
    public float max_vertical_velocity;
    [HideInInspector] public Animator animator;
    public float deceleration;
    public float air_deceleration;
    [HideInInspector] public string currentAnimation;
    public bool can_combo;

    private KeyCode rhythmKey;
    private string noteTag;
    private bool touchingNote;
    private GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        this.vertical_acceleration = 20;
        this.max_vertical_velocity = 7;
        this.deceleration = 20;
        this.air_deceleration = 10;
        this.can_combo = false;

        rhythmKey = KeyCode.RightArrow;
        noteTag = "FishNote";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rhythmKey))
        {
            if (touchingNote)
            {
                Destroy(note);
                Debug.Log("Hit!");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(noteTag)) // TODO: Implement tag & bool. Implement fish
        {
            touchingNote = true;
            note = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(noteTag))
        {
            touchingNote = false;
            note = null;
        }
    }

    public void ChangeAnimationState(string newAnimation)
     {
         if (currentAnimation == newAnimation) return;

         animator.Play(newAnimation);
         currentAnimation = newAnimation;
     }
}

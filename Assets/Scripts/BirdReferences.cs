using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdReferences : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Transform transform;
    [HideInInspector] public Animator animator;
    public float vertical_acceleration;
    public float max_vertical_velocity;
    public float deceleration;
    public float water_deceleration;
    public bool can_combo;
    [HideInInspector] public string currentAnimation;

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
        this.water_deceleration = 10;
        this.can_combo = false;

        rhythmKey = KeyCode.D;
        noteTag = "BirdNote";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rhythmKey))
        {
            if (touchingNote)
            {
                Destroy(note);
                GameManager.instance.NoteHit();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(noteTag))
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

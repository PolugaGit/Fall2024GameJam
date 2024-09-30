using UnityEngine;
using System.Collections;

public class DelayedAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public float delay = 5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayAudioAfterDelay());

     
    }

    IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        audioSource.Play();
    }
    
    
        

}

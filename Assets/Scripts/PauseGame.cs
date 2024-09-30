using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject PauseAudio;
    public AudioSource audioSource;  

    public void Start()
    {
        audioSource = PauseAudio.GetComponent<AudioSource>();
        
    }

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        audioSource.Play();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        audioSource.Pause();
    }

    public void LoadMenu()
    {

        Debug.Log("Quitting to Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }

    


}

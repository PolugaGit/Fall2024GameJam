using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public float delay = 5f;

    public string nextSceneName;

    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        GameManager.instance.saveScore(gameObject.scene.name);
        SceneManager.LoadScene(nextSceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private LevelTimer timer;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (CompareTag("Player"))
        {
            Debug.Log("Checkpoint reached");
            timer.ReachCheckpoint();
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}   
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelTimer timer = Object.FindAnyObjectByType<LevelTimer>();

            if (timer != null)
            {
                timer.ReachCheckpoint();
            }

            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }
}
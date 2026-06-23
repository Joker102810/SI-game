using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 30f;
    private bool checkpointReached = false;

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (checkpointReached)
            return;

        timeLimit -= Time.deltaTime;

        timerText.text = timeLimit.ToString("F3");

        if (timeLimit <= 0)
        {
            timerText.text = "0.000";
            RestartLevel();
        }
    }

    public void ReachCheckpoint()
    {
        checkpointReached = true;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
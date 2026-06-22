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
        if (checkpointReached)
            return;

        timeLimit -= Time.deltaTime;

        // Update the timer display
        timerText.text = Mathf.CeilToInt(timeLimit).ToString();

        if (timeLimit <= 0)
        {
            timerText.text = "0";
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
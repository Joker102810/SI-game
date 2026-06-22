using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    public int CurrentLife;
    public int MaxLife;
    public bool overlapping = false;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapping = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (overlapping)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            CurrentLife++;
        }
    }
}

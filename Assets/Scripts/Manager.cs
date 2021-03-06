using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject deathScreen;

    public int playerScore;

    private void Start()
    {
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        //Simple pause toggle on pressing the escape key
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf)
        {
            Debug.Log("Escape pressed!");
            pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
            return;
        }
    }

    public void GameOver()
    {
        deathScreen.GetComponent<GameOverScreen>().Setup(playerScore);
    }
}

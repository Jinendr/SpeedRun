using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool Ended = false;

    public float RestartDelay = 2f;

    public GameObject gameOverUI;

    public void EndGame  ()
    {
        if(Ended == false)
        {
            Ended = true;
            Invoke("gameOver", 0.5f);
            //Invoke("Restart", RestartDelay);
		}
	}

    void gameOver()
    {
        gameOverUI.SetActive(true);
	}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

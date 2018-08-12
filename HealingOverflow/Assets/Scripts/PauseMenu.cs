using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool isGamePaused = false;
    public GameObject PauseCanvas;
    private void Update()
    {
        if (PauseCanvas.activeSelf == false)
        {
            isGamePaused = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
               
                Resume();
            }else
            {
                GameManager.PauseGame();
                Pause();
            }
        }
    }

    void Resume()
    {
        isGamePaused = false;
        PauseCanvas.SetActive(false);
    }
    void Pause()
    {
        PauseCanvas.SetActive(true);
        isGamePaused = true;
    }
}

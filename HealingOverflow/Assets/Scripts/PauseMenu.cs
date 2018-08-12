using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isGamePaused = false;

    private void Update()
    {
        
    }

    void Resume()
    {
        isGamePaused = false;
    }
}

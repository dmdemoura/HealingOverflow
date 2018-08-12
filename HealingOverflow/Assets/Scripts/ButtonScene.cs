using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScene : MonoBehaviour {
    public string NextScene;
public void PlayGame()
    {
        //SceneManager.LoadScene(NextScene);
        GameManager.instance.StartGame();
    }
public void QuitGame()
    {
        GameManager.DespauseGame();
        Application.Quit();
    }
}

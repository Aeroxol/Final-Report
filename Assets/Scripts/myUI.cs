using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myUI:MonoBehaviour
{
     public void ToLobbyScene()
    {
        Debug.Log("ToLobbyScene");
        SceneManager.LoadScene("Lobby");
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToReadyScene()
    {
        //SceneManager.LoadScene("Ready");
    }

    public void ToPlayScene()
    {
        Debug.Log("ToPlayScene");
        SceneManager.LoadScene("Play");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}

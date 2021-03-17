using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myUI:MonoBehaviour
{
     public void ToLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ToReadyScene()
    {
        SceneManager.LoadScene("Ready");
    }
}

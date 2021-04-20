using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myUI:MonoBehaviour
{
    public Hero hero;
    public StrikerUnit striker_unit;
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

    public void Testasdfasdf()
    {
        hero.SetStrikerUnit(striker_unit);
    }
}
